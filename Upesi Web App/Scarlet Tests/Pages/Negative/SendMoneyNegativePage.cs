using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class SendMoneyNegativePage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public SendMoneyNegativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public By SendMoneyLink => By.XPath("//a[contains(text(),'Send Money')]");

    public void ClickSendMoneyLink()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(SendMoneyLink)).Click();
    }
}