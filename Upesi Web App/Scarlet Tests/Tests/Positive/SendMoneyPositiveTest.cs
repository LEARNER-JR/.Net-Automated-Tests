using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class SendMoneyPositiveTest
{
    private IWebDriver _driver;
    private SendMoneyPositivePage _moneyTransferPage;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _moneyTransferPage = new SendMoneyPositivePage(_driver);
        _moneyTransferPage.NavigateToMoneyTransferPage();
    }

    [Test]
    public void VerifySendMoneyLinkNavigation()
    {
        _moneyTransferPage.ClickSendMoneyLink();
        Assert.That(_driver.Url,
            Is.EqualTo("https://sitwebapp.upesimts.com/money-transfer"),
            "Send Money link did not navigate to the expected URL.");
    }

    [Test]
    public void CheckSendMoneyLinkTextVisibility()
    {
        Assert.That(_moneyTransferPage.IsSendMoneyLinkDisplayed(),
            Is.True, "Send Money link is not displayed.");

        Assert.That(_moneyTransferPage.GetSendMoneyLinkText(),
            Is.EqualTo("Send Money"), "Send Money link text does not match.");
    }

    [Test]
    public void EnsureLinkIsAccessibleViaKeyboardNavigation()
    {
        Assert.That(_moneyTransferPage.IsSendMoneyLinkKeyboardAccessible(),
            Is.True, "Send Money link is not reachable via keyboard navigation.");
    }

    [Test]
    public void TestLinkFunctionalityOnDifferentDevices()
    {
        _moneyTransferPage.ClickSendMoneyLink();
        Assert.That(_driver.Url,
            Is.EqualTo("https://sitwebapp.upesimts.com/money-transfer"),
            "Send Money link did not function correctly on simulated device.");
    }

    [Test]
    public void ValidateLinkOpensInSameTab()
    {
        string originalWindow = _driver.CurrentWindowHandle;
        _moneyTransferPage.ClickSendMoneyLink();
        Assert.That(_driver.CurrentWindowHandle,
            Is.EqualTo(originalWindow),
            "Send Money link opened in a new tab instead of the same one.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
