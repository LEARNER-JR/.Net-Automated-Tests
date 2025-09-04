using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Assert = NUnit.Framework.Assert;


[TestFixture]
public class LoginPositveTest
{
    private IWebDriver driver;
    private LoginPositivePage loginPage;
    private const string baseUrl = "https://sitwebapp.upesimts.com/login?country=/login";

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver(); // Change to FirefoxDriver() or other for different browsers
        driver.Navigate().GoToUrl(baseUrl);
        loginPage = new LoginPositivePage(driver);
    }

    [Test]
    public void VerifyLoginLinkNavigation()
    {
        loginPage.ClickLoginLink();
        Assert.AreEqual(driver.Url, "https://sitwebapp.upesimts.com/login?country=/login", "Navigation to login page failed.");
    }

    [Test]
    public void ConfirmLoginLinkAccessibleViaKeyboard()
    {
        var actions = new OpenQA.Selenium.Interactions.Actions(driver);
        actions.MoveToElement(loginPage.GetLoginLinkHref()).SendKeys(Keys.Enter).Perform();
        Assert.AreEqual(driver.Url, "https://sitwebapp.upesimts.com/login?country=/login", "Login link not accessible via keyboard.");
    }

    [Test]
    public void CheckLoginLinkVisibilityAndLabel()
    {
        Assert.IsTrue(loginPage.IsLoginLinkVisible(), "Login link is not visible.");
        Assert.AreEqual(loginPage.GetLoginLinkHref(), "Login", "Login link label is incorrect.");
    }

    [Test]
    public void EnsureLoginLinkWorksInDifferentBrowsers()
    {
        // This test would be run in different browser instances (e.g., Chrome, Firefox, Safari)
        loginPage.ClickLoginLink();
        Assert.AreEqual(driver.Url, "https://sitwebapp.upesimts.com/login?country=/login", "Login link does not work in the current browser.");
    }

    [Test]
    public void ValidateLoginLinkUrlStructureWithCountryChange()
    {
        string newCountry = "/us";
        driver.Navigate().GoToUrl($"https://sitwebapp.upesimts.com/login?country={newCountry}");
        Assert.AreEqual(driver.Url, $"https://sitwebapp.upesimts.com/login?country={newCountry}", "URL structure with country change is incorrect.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}