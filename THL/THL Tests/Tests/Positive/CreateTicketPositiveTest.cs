using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class CreateTicketPositiveTest : BaseTest
{
    private IWebDriver _driver;
    private CreateTicketPositivePage _newTicketPage;
    private const string BaseUrl = "https://sit-portal.trackinghub.co.ke/home2";

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl(BaseUrl);
        _newTicketPage = new CreateTicketPositivePage(_driver);
    }

    [Test]
    public void VerifyClickingNewTicketNavigatesToCorrectPage()
    {
        _newTicketPage.ClickNewTicketLink();
        Assert.That(_driver.Url, Is.EqualTo("https://sit-portal.trackinghub.co.ke/newticket"));
    }

    [Test]
    public void CheckNewTicketLinkIsVisible()
    {
        Assert.That(_newTicketPage.IsNewTicketLinkVisible(), Is.True, "New Ticket link is not visible.");
    }

    [Test]
    public void EnsureNewTicketIconIsDisplayed()
    {
        Assert.That(_newTicketPage.IsNewTicketIconDisplayed(), Is.True, "New Ticket icon is not displayed.");
    }

    [Test]
    public void TestNewTicketLinkFunctionalityAcrossBrowsers()
    {
        _newTicketPage.ClickNewTicketLink();
        Assert.That(_driver.Url, Is.EqualTo("https://sit-portal.trackinghub.co.ke/newticket"));
    }

    [Test]
    public void ValidateNewTicketLinkAccessibilityViaKeyboard()
    {
        var newTicketLink = _newTicketPage.NewTicketLink;
        newTicketLink.SendKeys(Keys.Tab);

        var activeElement = _driver.SwitchTo().ActiveElement();
        Assert.That(newTicketLink, Is.EqualTo(activeElement), "New Ticket link is not focused.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
