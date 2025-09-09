using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TariffNegativeTests
{
    private IWebDriver driver;
    private TariffNegativePage tariffsPage;
    private const string baseUrl = "https://sit-ui.upesimts.com/tariffs";

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(baseUrl);
        tariffsPage = new TariffNegativePage(driver);
    }

    [Test]
    public void Test_ClickLink_Offline()
    {
        // Simulate offline mode by navigating to a blank offline page
        driver.Navigate().GoToUrl("data:text/html,<html><body></body></html>");
        Assert.Throws<NoSuchElementException>(() => tariffsPage.ClickTariffsLink());
    }

    [Test]
    public void Test_ClickLink_JavaScriptDisabled()
    {
        driver.Quit(); // close old driver before starting a new one

        var options = new ChromeOptions();
        options.AddArgument("--disable-javascript");
        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(baseUrl);
        tariffsPage = new TariffNegativePage(driver);

        tariffsPage.ClickTariffsLink();
        Assert.That(driver.PageSource, Does.Contain("JavaScript is disabled"), "Expected fallback message not found.");
    }

    [Test]
    public void Test_ClickLink_NonexistentPage()
    {
        driver.Navigate().GoToUrl(baseUrl + "123");
        Assert.That(driver.Title, Does.Contain("404"), "Expected 404 title not found.");
    }

    [Test]
    public void Test_BrokenLink()
    {
        ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].setAttribute('href', 'http://invalid-url.com');", tariffsPage.TariffsLink);

        tariffsPage.ClickTariffsLink();
        Assert.That(driver.Url, Does.Contain("about:blank").Or.Contain("invalid-url.com"),
            "Expected to remain on the current or broken page.");
    }

    [Test]
    public void Test_ClickLink_WhileLoading()
    {
        driver.Navigate().GoToUrl(baseUrl);
        var loadingIndicator = driver.FindElement(By.ClassName("loading")); // Assuming a loading indicator exists
        Assert.That(loadingIndicator.Displayed, Is.True, "Loading indicator not displayed.");

        Assert.Throws<ElementClickInterceptedException>(() => tariffsPage.ClickTariffsLink());
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
