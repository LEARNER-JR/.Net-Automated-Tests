using OpenQA.Selenium;

public class NewTicketPage
{
    private IWebDriver driver;

    public NewTicketPage(IWebDriver driver)
    {
        this.driver = driver;
        // Removed: PageFactory.InitElements(driver, this);
    }

    public string Url => "https://sit-portal.trackinghub.co.ke/newticket";

    public IWebElement NewTicketLink => driver.FindElement(By.CssSelector("a[href='/newticket']"));

    public void ClickNewTicketLink()
    {
        NewTicketLink.Click();
    }

    public string GetCurrentUrl()
    {
        return driver.Url;
    }
}