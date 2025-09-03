using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class CreateTicketNegativePage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public CreateTicketNegativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Locators
    public IWebElement NewTicketLink => wait.Until(driver => driver.FindElement(By.LinkText("newticket")));
    public IWebElement EmailInput => wait.Until(driver => driver.FindElement(By.Id("email")));
    public IWebElement LoanAmtInput => wait.Until(driver => driver.FindElement(By.Id("loanAmt")));
    public IWebElement SubmitButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@type='submit']")));
    public void EnterInvalidEmail(string invalidEmail = "invalid-email")
    {
        EmailInput.Clear();
        EmailInput.SendKeys(invalidEmail);
    }
    public void ClickNewTicketLink()
    {
        NewTicketLink.Click();
    }
    public void EnterInvalidLoanAmt(string amt = "ABC123")
    {
        LoanAmtInput.Clear();
        LoanAmtInput.SendKeys(amt);
    }

    public void SubmitFormWithoutRequiredFields()
    {
        SubmitButton.Click();
    }

    public void SubmitForm() => SubmitButton.Click();
}
