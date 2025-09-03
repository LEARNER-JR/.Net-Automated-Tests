using NUnit.Framework;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class CreateTicketNegativeTest : BaseTest
{
    private IWebDriver _driver;
    private CreateTicketNegativePage _newTicketPage;
    private const string BaseUrl = "https://sit-portal.trackinghub.co.ke/home2";

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(BaseUrl);
        _newTicketPage = new NewTicketPage(_driver);
    }

    [Test]
    public void Test_NewTicketLink_No404Error()
    {
        _newTicketPage.ClickNewTicketLink();
        Assert.IsFalse(_driver.Url.Contains("404"), "The page should not lead to a 404 error.");
    }

    [Test]
    public void Test_NewTicketLink_WhenNotLoggedIn()
    {
        // Simulate user not logged in
        _newTicketPage.ClickNewTicketLink();
        Assert.IsTrue(_driver.Url.Contains("login"), "The user should be redirected to the login page.");
    }

    [Test]
    public void Test_NewTicketLink_ClickRapidly()
    {
        for (int i = 0; i < 10; i++)
        {
            _newTicketPage.ClickNewTicketLink();
        }
        Assert.IsFalse(_driver.Url.Contains("error"), "The application should not crash or hang.");
    }

    [Test]
    public void Test_NewTicketLink_JavaScriptDisabled()
    {
        var options = new ChromeOptions();
        options.AddArgument("--disable-javascript");
        _driver = new ChromeDriver(options);
        _driver.Navigate().GoToUrl(BaseUrl);
        _newTicketPage = new NewTicketPage(_driver);
        
        _newTicketPage.ClickNewTicketLink();
        Assert.IsTrue(_driver.Url.Contains("error"), "The link should not work with JavaScript disabled.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
