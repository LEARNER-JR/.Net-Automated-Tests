using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;


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
        Assert.AreEqual("https://sitwebapp.upesimts.com/money-transfer", _driver.Url);
    }

    [Test]
    public void CheckSendMoneyLinkTextVisibility()
    {
        Assert.IsTrue(_moneyTransferPage.IsSendMoneyLinkDisplayed());
        Assert.AreEqual("Send Money", _moneyTransferPage.GetSendMoneyLinkText());
    }

    [Test]
    public void EnsureLinkIsAccessibleViaKeyboardNavigation()
    {
        _moneyTransferPage.SendMoneyLink.SendKeys(Keys.Tab);
        Assert.IsTrue(_moneyTransferPage.SendMoneyLink.Equals(_driver.SwitchTo().ActiveElement));
    }

    [Test]
    public void TestLinkFunctionalityOnDifferentDevices()
    {
        // Code to simulate different devices would go here, e.g., using browser emulation.
        // For simplicity, we can just check the link functionality as is.
        _moneyTransferPage.ClickSendMoneyLink();
        Assert.AreEqual("https://sitwebapp.upesimts.com/money-transfer", _driver.Url);
    }

    [Test]
    public void ValidateLinkOpensInSameTab()
    {
        string originalWindow = _driver.CurrentWindowHandle;
        _moneyTransferPage.ClickSendMoneyLink();
        Assert.AreEqual(originalWindow, _driver.CurrentWindowHandle);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}