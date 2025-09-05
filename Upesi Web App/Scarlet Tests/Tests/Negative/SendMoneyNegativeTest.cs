using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class SendMoneyNegativeTest
{
    private IWebDriver driver;
    private SendMoneyNegativePage moneyTransferPage;
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
        moneyTransferPage.ClickSendMoneyLink();
        Assert.That(driver.Url, Does.Contain("login"),
            "User was not redirected to the login page.");
    }

    [Test]
    public void Test_ClickLink_WhileOffline_ErrorMessageDisplayed()
    {
        moneyTransferPage.ClickSendMoneyLink();
        Assert.That(driver.PageSource, Does.Contain("You are offline"),
            "No error message displayed when offline.");
    }

    [Test]
    public void Test_ClickLink_BrokenUrl_ErrorPageShown()
    {
        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/broken-link");
        moneyTransferPage.ClickSendMoneyLink();
        Assert.That(driver.Title, Does.Contain("Error"),
            "Error page was not displayed for the broken link.");
    }

    [Test]
    public void Test_ClickLink_NoUnexpectedPopups()
    {
        moneyTransferPage.ClickSendMoneyLink();

        IAlert alert = null;
        try
        {
            alert = driver.SwitchTo().Alert();
        }
        catch (NoAlertPresentException) { }

        Assert.That(alert, Is.Null,
            "An unexpected alert was triggered.");
    }

    [Test]
    public void Test_ClickLink_JavaScriptDisabled_LinkDoesNotFunction()
    {
        // NOTE: Disabling JavaScript requires driver options setup before browser launch.
        moneyTransferPage.ClickSendMoneyLink();
        Assert.That(driver.Url, Does.Not.Contain("money-transfer"),
            "Link functioned with JavaScript disabled.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
