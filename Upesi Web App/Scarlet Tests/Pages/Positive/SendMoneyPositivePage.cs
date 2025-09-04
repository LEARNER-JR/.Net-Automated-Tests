using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

public class SendMoneyPositivePage
{
    private readonly IWebDriver _driver;

    public SendMoneyPositivePage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.CssSelector, Using = "a[href='/money-transfer']")]
    public IWebElement SendMoneyLink { get; set; }

    public void ClickSendMoneyLink()
    {
        SendMoneyLink.Click();
    }

    public string GetSendMoneyLinkText()
    {
        return SendMoneyLink.Text;
    }

    public bool IsSendMoneyLinkDisplayed()
    {
        return SendMoneyLink.Displayed;
    }

    public void NavigateToMoneyTransferPage()
    {
        _driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/money-transfer");
    }
}