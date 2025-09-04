using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class SendMoneyNegativeTest
{
    private IWebDriver driver;
    private SendMoneyNegativeTest moneyTransferPage;
    private const string baseUrl = "https://sitwebapp.upesimts.com/money-transfer";

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(baseUrl);
        moneyTransferPage = new SendMoneyNegativePage(driver);
    }

    [Test]
    public void Test_ClickLink_NotLoggedIn_RedirectsToLogin()
    {
        // Simulate user not logged in
        moneyTransferPage.ClickSendMoneyLink();
        Assert.IsTrue(driver.Url.Contains("login"), "User was not redirected to the login page.");
    }

    [Test]
    public void Test_ClickLink_WhileOffline_ErrorMessageDisplayed()
    {
        // Simulate offline mode (you may need to implement this based on your testing framework)
        moneyTransferPage.ClickSendMoneyLink();
        Assert.IsTrue(driver.PageSource.Contains("You are offline"), "No error message displayed when offline.");
    }

    [Test]
    public void Test_ClickLink_BrokenUrl_ErrorPageShown()
    {
        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/broken-link");
        moneyTransferPage.ClickSendMoneyLink();
        Assert.IsTrue(driver.Title.Contains("Error"), "Error page was not displayed for the broken link.");
    }

    [Test]
    public void Test_ClickLink_NoUnexpectedPopups()
    {
        moneyTransferPage.ClickSendMoneyLink();
        // Check for alerts or popups
        IAlert alert = null;
        try
        {
            alert = driver.SwitchTo().Alert();
        }
        catch (NoAlertPresentException) { }

        Assert.IsNull(alert, "An unexpected alert was triggered.");
    }

    [Test]
    public void Test_ClickLink_JavaScriptDisabled_LinkDoesNotFunction()
    {
        // Disable JavaScript (you may need to implement this based on your testing framework)
        moneyTransferPage.ClickSendMoneyLink();
        Assert.IsFalse(driver.Url.Contains("money-transfer"), "Link functioned with JavaScript disabled.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}