using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class AddUserNegativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public AddUserNegativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement FirstNameInput => _wait.Until(d => d.FindElement(By.Name("firstName")));
    public IWebElement LastNameInput => _wait.Until(d => d.FindElement(By.Name("lastName")));
    public IWebElement EmailInput => _wait.Until(d => d.FindElement(By.Name("email")));
    public IWebElement PhoneInput => _wait.Until(d => d.FindElement(By.CssSelector("input[type='tel']")));
    public IWebElement DateOfBirthInput => _wait.Until(d => d.FindElement(By.CssSelector("input[placeholder='Select Date']")));
    public IWebElement GenderButton => _wait.Until(d => d.FindElement(By.CssSelector("button[aria-haspopup='listbox']")));
    public IWebElement RegisterButton => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Register User']")));
    public IWebElement CancelButton => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Cancel']")));
    public IWebElement ErrorMessage => _wait.Until(d => d.FindElement(By.ClassName("rizzui-input-error-text")));

    public void EnterFirstName(string firstName)
    {
        FirstNameInput.Clear();
        FirstNameInput.SendKeys(firstName);
    }

    public void EnterLastName(string lastName)
    {
        LastNameInput.Clear();
        LastNameInput.SendKeys(lastName);
    }

    public void EnterEmail(string email)
    {
        EmailInput.Clear();
        EmailInput.SendKeys(email);
    }

    public void EnterPhone(string phone)
    {
        PhoneInput.Clear();
        PhoneInput.SendKeys(phone);
    }

    public void EnterDateOfBirth(string dob)
    {
        DateOfBirthInput.Clear();
        DateOfBirthInput.SendKeys(dob);
    }

    public void SelectGender(string gender)
    {
        GenderButton.Click();
        var genderOption = _wait.Until(d => d.FindElement(By.XPath($"//span[text()='{gender}']")));
        genderOption.Click();
    }

    public void SubmitForm()
    {
        RegisterButton.Click();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }

    internal void NavigateToUserManagementPage()
    {
        throw new NotImplementedException();
    }

    internal void ClickAddNewUserButton()
    {
        throw new NotImplementedException();
    }

    internal void WaitForPageLoad()
    {
        throw new NotImplementedException();
    }
}