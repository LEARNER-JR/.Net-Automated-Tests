using NUnit.Framework;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class CreateTicketPositiveTest : BaseTest
{
    private CreateTicketPositivePage _newTicketPage;
    //private const string BaseUrl = "https://sit-portal.trackinghub.co.ke/home2";

    [SetUp]
    public void SetUp()
    {
        // BaseTest handles driver setup, login, and navigation to baseUrl
        _newTicketPage = new CreateTicketPositivePage(driver);
    }

    [Test]
    public void VerifyClickingNewTicketNavigatesToCorrectPage()
    {
        wait.Until(d => _newTicketPage.IsNewTicketLinkVisible());
        _newTicketPage.ClickNewTicketLink();
        wait.Until(d => d.Url.Contains("/newticket"));
        Assert.That(driver.Url, Is.EqualTo("https://sit-portal.trackinghub.co.ke/newticket"));
    }

    [Test]
    public void CheckNewTicketLinkIsVisible()
    {
        wait.Until(d => _newTicketPage.IsNewTicketLinkVisible());
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
        Assert.That(driver.Url, Is.EqualTo("https://sit-portal.trackinghub.co.ke/newticket"));
    }

    [Test]
    public void ValidateNewTicketLinkAccessibilityViaKeyboard()
    {
        var newTicketLink = _newTicketPage.NewTicketLink;
        newTicketLink.SendKeys(Keys.Tab);

        var activeElement = driver.SwitchTo().ActiveElement();
        Assert.That(newTicketLink, Is.EqualTo(activeElement), "New Ticket link is not focused.");
    }
}
