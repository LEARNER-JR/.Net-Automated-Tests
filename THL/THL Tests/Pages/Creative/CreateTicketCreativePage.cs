using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class CreateTicketCreativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public CreateTicketCreativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private By NewTicketLink => By.CssSelector("a.nav-link");

    public void NavigateToNewTicket()
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(NewTicketLink)).Click();
    }

    public string GetNewTicketLinkText()
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(NewTicketLink)).Text;
    }

    public bool IsNewTicketLinkDisplayed()
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(NewTicketLink)).Displayed;
    }
}
