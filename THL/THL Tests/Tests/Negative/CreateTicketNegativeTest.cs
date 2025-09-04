using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using THL_Tests.Tests;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class CreateTicketNegativeTest : BaseTest
{
    private CreateTicketNegativePage _newTicketPage;

    [SetUp]
    public void SetUp()
    {
        // BaseTest handles driver setup, login, and navigation to baseUrl
        _newTicketPage = new CreateTicketNegativePage(driver);
    }
    [Test]
    public void Test_NewTicketLink_No404Error()
    {
        _newTicketPage.ClickNewTicketLink();
        Assert.That(driver.Url.Contains("404"), Is.False,
            "The page should not lead to a 404 error.");
    }

    [Test]
    public void Test_NewTicketLink_WhenNotLoggedIn()
    {
        // Simulate user not logged in
        _newTicketPage.ClickNewTicketLink();
        Assert.That(driver.Url.Contains("login"), Is.True,
            "The user should be redirected to the login page.");
    }

    [Test]
    public void Test_NewTicketLink_ClickRapidly()
    {
        for (int i = 0; i < 10; i++)
        {
            _newTicketPage.ClickNewTicketLink();
        }
        Assert.That(driver.Url.Contains("error"), Is.False,
            "The application should not crash or hang.");
    }

    [Test]
    public void Test_NewTicketLink_JavaScriptDisabled()
    {
        var options = new ChromeOptions();
        options.AddArgument("--disable-javascript");
        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(baseUrl);
        _newTicketPage = new CreateTicketNegativePage(driver);

        _newTicketPage.ClickNewTicketLink();
        Assert.That(driver  .Url.Contains("error"), Is.True,
            "The link should not work with JavaScript disabled.");
    }
}
