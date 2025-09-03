//using NUnit.Framework;
//using OpenQA.Selenium;
//using Assert = NUnit.Framework.Assert;

//[TestFixture]
//public class CreateTicketPositiveTest : BaseTest
//{
//    private CreateTicketPositivePage _newTicketPage;

//    [SetUp]
//    public void SetUp()
//    {
//        // BaseTest handles driver setup, login, and navigation to baseUrl
//        _newTicketPage = new CreateTicketPositivePage(driver);
//    }

//    [Test]
//    public void VerifyClickingNewTicketNavigatesToCorrectPage()
//    {
//        wait.Until(d => _newTicketPage.IsNewTicketLinkVisible());
//        _newTicketPage.ClickNewTicketLink();
//        wait.Until(d => d.Url.Contains("/newticket"));
//        Assert.AreEqual("https://sit-portal.trackinghub.co.ke/newticket", driver.Url);
//    }

//    [Test]
//    public void CheckNewTicketLinkIsVisible()
//    {
//        wait.Until(d => _newTicketPage.IsNewTicketLinkVisible());
//        Assert.IsTrue(_newTicketPage.IsNewTicketLinkVisible(), "New Ticket link is not visible.");
//    }

//    [Test]
//    public void EnsureNewTicketIconIsDisplayed()
//    {
//        wait.Until(d => _newTicketPage.IsNewTicketIconDisplayed());
//        Assert.IsTrue(_newTicketPage.IsNewTicketIconDisplayed(), "New Ticket icon is not displayed.");
//    }

//    [Test]
//    public void TestNewTicketLinkFunctionalityAcrossBrowsers()
//    {
//        // Note: To test across browsers, modify BaseTest to use different driver
//        wait.Until(d => _newTicketPage.IsNewTicketLinkVisible());
//        _newTicketPage.ClickNewTicketLink();
//        wait.Until(d => d.Url.Contains("/newticket"));
//        Assert.AreEqual("https://sit-portal.trackinghub.co.ke/newticket", driver.Url);
//    }

//    [Test]
//    public void ValidateNewTicketLinkAccessibilityViaKeyboard()
//    {
//        var newTicketLink = wait.Until(d => d.FindElement(_newTicketPage.NewTicketLink));
//        // Assuming the link is tabbable; if not, may need to adjust
//        newTicketLink.SendKeys(Keys.Tab);
//        System.Threading.Thread.Sleep(500); // Small wait for focus to settle
//        Assert.IsTrue(driver.SwitchTo().ActiveElement() == newTicketLink, "New Ticket link is not focused.");
//    }

//    // TearDown is handled by BaseTest
//}
