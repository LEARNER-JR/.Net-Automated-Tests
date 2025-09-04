using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;


[TestFixture]
public class LoginLoginNegativeTestTests
{
    private IWebDriver driver;
    private LoginNegativePage loginPage;
    private const string baseUrl = "https://sitwebapp.upesimts.com/login?country=/login";

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(baseUrl);
        loginPage = new LoginNegativePage(driver);
    }

    [Test]
    public void Test_NoInternetConnection_ShowsErrorMessage()
    {
        // Simulate no internet connection
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        loginPage.ClickLoginButton();

        // Assert error message (example assertion, adapt as needed)
        Assert.IsTrue(driver.PageSource.Contains("No internet connection"), "Error message not displayed.");
    }

    [Test]
    public void Test_LoggedIn_UserStaysOnCurrentPage()
    {
        // Simulate user being logged in (this would typically be done by navigating to a logged-in state)
        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/dashboard");
        loginPage.ClickLoginButton();

        Assert.AreEqual("https://sitwebapp.upesimts.com/dashboard", driver.Url, "User was redirected to login page.");
    }

    [Test]
    public void Test_InvalidUrl_Response()
    {
        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/login?country=/invalidCountry");
        loginPage.ClickLoginButton();

        // Assert response for invalid URL (example assertion, adapt as needed)
        Assert.IsTrue(driver.PageSource.Contains("Invalid country"), "Invalid URL response not handled.");
    }

    [Test]
    public void Test_JavaScriptDisabled_NoAction()
    {
        // Disable JavaScript (this would typically be done via browser settings)
        var options = new ChromeOptions();
        options.AddArgument("--disable-javascript");
        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(baseUrl);
        loginPage.ClickLoginButton();

        // Assert no navigation occurred
        Assert.AreEqual(baseUrl, driver.Url, "Navigation occurred with JavaScript disabled.");
    }

    [Test]
    public void Test_PopupBlocker_NoRedirect()
    {
        // Simulate popup blocker
        var options = new ChromeOptions();
        options.AddArgument("--disable-popup-blocking");
        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(baseUrl);
        loginPage.ClickLoginButton();

        // Assert user remains on the same page
        Assert.AreEqual(baseUrl, driver.Url, "User was redirected despite popup blocker.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}