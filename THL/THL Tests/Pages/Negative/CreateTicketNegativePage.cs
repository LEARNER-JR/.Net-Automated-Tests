using OpenQA.Selenium;

public class CreateTicketNegativePage
{
    private readonly IWebDriver _driver;

    public CreateTicketNegativePage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.CssSelector, Using = "a.nav-link[href='/newticket']")]
    public IWebElement NewTicketLink { get; set; }

    public void ClickNewTicketLink()
    {
        NewTicketLink.Click();
    }

    public string GetCurrentUrl()
    {
        return _driver.Url;
    }
}


