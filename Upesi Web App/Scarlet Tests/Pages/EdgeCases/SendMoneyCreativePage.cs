using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

public class SendMoneyCreativePage
{
    private IWebDriver driver;

    public SendMoneyCreativePage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.CssSelector, Using = "a[href='/money-transfer']")]
    public IWebElement SendMoneyLink { get; set; }

    public void HoverOverSendMoneyLink()
    {
        var actions = new OpenQA.Selenium.Interactions.Actions(driver);
        actions.MoveToElement(SendMoneyLink).Perform();
    }

    public void ClickSendMoneyLink()
    {
        SendMoneyLink.Click();
    }

    public string GetLinkStyle()
    {
        return SendMoneyLink.GetAttribute("style");
    }
}