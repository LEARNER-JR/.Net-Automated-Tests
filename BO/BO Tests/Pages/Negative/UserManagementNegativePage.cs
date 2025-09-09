using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class UserManagementNegativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public UserManagementNegativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public string Url => "https://sit-ui.upesimts.com/user-management/system-users";

    public IWebElement FirstNameField => _wait.Until(d => d.FindElement(By.Name("first_name")));
    public IWebElement EmailField => _wait.Until(d => d.FindElement(By.Name("email")));
    public IWebElement PhoneField => _wait.Until(d => d.FindElement(By.Name("phone")));
    public IWebElement DateOfBirthField => _wait.Until(d => d.FindElement(By.Name("dob")));
    public IWebElement GenderField => _wait.Until(d => d.FindElement(By.Name("gender")));
    public IWebElement SubmitButton => _wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));
    public IWebElement ErrorMessage => _wait.Until(d => d.FindElement(By.ClassName("error-message")));

    public void NavigateTo()
    {
        _driver.Navigate().GoToUrl(Url);
    }

    public void EnterFirstName(string firstName)
    {
        FirstNameField.Clear();
        FirstNameField.SendKeys(firstName);
    }

    public void EnterEmail(string email)
    {
        EmailField.Clear();
        EmailField.SendKeys(email);
    }

    public void EnterPhone(string phone)
    {
        PhoneField.Clear();
        PhoneField.SendKeys(phone);
    }

    public void EnterDateOfBirth(string dob)
    {
        DateOfBirthField.Clear();
        DateOfBirthField.SendKeys(dob);
    }

    public void SelectGender(string gender)
    {
        // Assuming gender is a dropdown
        new SelectElement(GenderField).SelectByText(gender);
    }

    public void SubmitForm()
    {
        SubmitButton.Click();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }
}
