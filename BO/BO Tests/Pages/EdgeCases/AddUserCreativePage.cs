using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class AddUserCreativePage
{
    private readonly IWebDriver _driver;
    private WebDriverWait _wait;

    public AddUserCreativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement UserTypeButton => _driver.FindElement(By.Id("headlessui-listbox-button-:r2u:"));
    public IWebElement UserTypeOptionOrganization => _driver.FindElement(By.XPath("//li[text()='Organization']"));
    public IWebElement FirstNameInput => _driver.FindElement(By.Name("firstName"));
    public IWebElement MiddleNameInput => _driver.FindElement(By.Name("middleName"));
    public IWebElement LastNameInput => _driver.FindElement(By.Name("lastName"));
    public IWebElement EmailInput => _driver.FindElement(By.Name("email"));
    public IWebElement PhoneNumberInput => _driver.FindElement(By.XPath("//input[@type='tel']"));
    public IWebElement DateOfBirthInput => _driver.FindElement(By.XPath("//input[@placeholder='Select Date']"));
    public IWebElement GenderButton => _driver.FindElement(By.Id("headlessui-listbox-button-:r32:"));
    public IWebElement GenderOptionMale => _driver.FindElement(By.XPath("//li[text()='Male']"));
    public IWebElement GenderOptionFemale => _driver.FindElement(By.XPath("//li[text()='Female']"));
    public IWebElement RegisterButton => _driver.FindElement(By.XPath("//button[text()='Register User']"));
    public IWebElement CancelButton => _driver.FindElement(By.XPath("//button[text()='Cancel']"));

    public void SelectUserType(string userType)
    {
        UserTypeButton.Click();
        if (userType == "Organization")
        {
            UserTypeOptionOrganization.Click();
        }
    }

    public void FillPersonalDetails(string firstName, string middleName, string lastName, string email, string phoneNumber, string dateOfBirth)
    {
        FirstNameInput.SendKeys(firstName);
        MiddleNameInput.SendKeys(middleName);
        LastNameInput.SendKeys(lastName);
        EmailInput.SendKeys(email);
        PhoneNumberInput.SendKeys(phoneNumber);
        DateOfBirthInput.SendKeys(dateOfBirth);
    }

    public void SelectGender(string gender)
    {
        GenderButton.Click();
        if (gender == "Male")
        {
            GenderOptionMale.Click();
        }
        else if (gender == "Female")
        {
            GenderOptionFemale.Click();
        }
    }

    public void SubmitForm()
    {
        RegisterButton.Click();
    }

    public void CancelRegistration()
    {
        CancelButton.Click();
    }

    public void ResizeBrowser(int width, int height)
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(width, height);
    }
}