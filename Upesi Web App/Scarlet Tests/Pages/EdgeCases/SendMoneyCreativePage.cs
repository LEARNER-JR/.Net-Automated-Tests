using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public class SendMoneyCreativePage
{
    private readonly IWebDriver driver;

    // Locator for Send Money link — adjust if the selector changes
    private readonly By sendMoneyLinkLocator = By.CssSelector("a[href='/money-transfer']");

    public SendMoneyCreativePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Property to return the element when needed
    public IWebElement SendMoneyLink => driver.FindElement(sendMoneyLinkLocator);

    public void HoverOverSendMoneyLink()
    {
        var actions = new Actions(driver);
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
