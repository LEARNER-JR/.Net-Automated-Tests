using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class NewTicketTests
{
    private IWebDriver _driver;
    private CreateTicketPositivePage _newTicketPage;
    private const string BaseUrl = "https://sit-portal.trackinghub.co.ke/home2";

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver(); // Change to FirefoxDriver or SafariDriver as needed
        _driver.Navigate().GoToUrl(BaseUrl);
        _newTicketPage = new CreateTicketPositivePage(_driver);
    }

    [Test]
    public void VerifyClickingNewTicketNavigatesToCorrectPage()
    {
        _newTicketPage.ClickNewTicketLink();
        Assert.AreEqual("https://sit-portal.trackinghub.co.ke/newticket", _driver.Url);
    }

    [Test]
    public void CheckNewTicketLinkIsVisible()
    {
        Assert.IsTrue(_newTicketPage.IsNewTicketLinkVisible(), "New Ticket link is not visible.");
    }

    [Test]
    public void EnsureNewTicketIconIsDisplayed()
    {
        Assert.IsTrue(_newTicketPage.IsNewTicketIconDisplayed(), "New Ticket icon is not displayed.");
    }

    [Test]
    public void TestNewTicketLinkFunctionalityAcrossBrowsers()
    {
        // This test can be run in different browsers by changing the driver initialization in SetUp method.
        _newTicketPage.ClickNewTicketLink();
        Assert.AreEqual("https://sit-portal.trackinghub.co.ke/newticket", _driver.Url);
    }

    [Test]
    public void ValidateNewTicketLinkAccessibilityViaKeyboard()
    {
        var newTicketLink = _driver.FindElement(_newTicketPage.NewTicketLink);
        newTicketLink.SendKeys(Keys.Tab);
        Assert.IsTrue(newTicketLink.Equals(_driver.SwitchTo().ActiveElement()), "New Ticket link is not focused.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
