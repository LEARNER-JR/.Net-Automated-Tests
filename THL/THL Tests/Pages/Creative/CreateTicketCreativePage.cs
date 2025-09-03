using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class CreateTicketCreativePage : BaseTest
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public CreateTicketCreativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Locators
    public IWebElement NewTicketLink => wait.Until(driver => driver.FindElement(By.LinkText("newticket")));
    public IWebElement SubjectInput => wait.Until(driver => driver.FindElement(By.Id("subject")));
    public IWebElement SubmitButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@type='submit']")));

    public void EnterVeryLongSubject(string longSubject)
    {
        SubjectInput.Clear();
        SubjectInput.SendKeys(longSubject);
    }

    public bool IsNewTicketLinkDisplayed()
    {
        try
        {
            var newTicketLink = wait.Until(driver => driver.FindElement(By.XPath("/html/body/div[1]/aside[1]/div/div[4]/div/div/nav/ul/li[9]/a")));
            return newTicketLink.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
    public string GetNewTicketLinkText()
    {
        try
        {
            var newTicketLink = wait.Until(driver => driver.FindElement(By.LinkText("New Ticket")));
            return newTicketLink.Text;
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
    }

    public void RapidFieldEntries(Dictionary<IWebElement, string> fields)
    {
        foreach (var field in fields)
        {
            field.Key.Clear();
            field.Key.SendKeys(field.Value);
        }
    }

    public void SubmitForm() => SubmitButton.Click();
}
