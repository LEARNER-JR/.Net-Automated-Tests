using OpenQA.Selenium;

public class SendMoneyPositivePage
{
    private readonly IWebDriver _driver;

    public SendMoneyPositivePage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement SendMoneyLink => _driver.FindElement(By.CssSelector("a[href='/money-transfer']"));

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
    public bool IsSendMoneyLinkKeyboardAccessible()
    {
        SendMoneyLink.SendKeys(Keys.Tab);
        return SendMoneyLink.Equals(_driver.SwitchTo().ActiveElement());
    }
}
