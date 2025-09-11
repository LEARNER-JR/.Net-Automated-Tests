using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class AddUserPositivePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public AddUserPositivePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement UserTypeDropdown => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("headlessui-listbox-button-:r2u:")));
    private IWebElement FirstNameInput => driver.FindElement(By.Name("firstName"));
    private IWebElement MiddleNameInput => driver.FindElement(By.Name("middleName"));
    private IWebElement LastNameInput => driver.FindElement(By.Name("lastName"));
    private IWebElement EmailInput => driver.FindElement(By.Name("email"));
    private IWebElement PhoneNumberInput => driver.FindElement(By.XPath("//input[@type='tel']"));
    private IWebElement DateOfBirthInput => driver.FindElement(By.XPath("//input[@placeholder='Select Date']"));
    private IWebElement GenderDropdown => driver.FindElement(By.Id("headlessui-listbox-button-:r32:"));
    private IWebElement RegisterUserButton => driver.FindElement(By.XPath("//button[text()='Register User']"));

    public void SelectUserType(string userType)
    {
        UserTypeDropdown.Click();
        var userTypeOption = driver.FindElement(By.XPath($"//span[text()='{userType}']"));
        userTypeOption.Click();
    }

    public void EnterFirstName(string firstName)
    {
        FirstNameInput.SendKeys(firstName);
    }

    public void EnterMiddleName(string middleName)
    {
        MiddleNameInput.SendKeys(middleName);
    }

    public void EnterLastName(string lastName)
    {
        LastNameInput.SendKeys(lastName);
    }

    public void EnterEmail(string email)
    {
        EmailInput.SendKeys(email);
    }

    public void EnterPhoneNumber(string phoneNumber)
    {
        PhoneNumberInput.SendKeys(phoneNumber);
    }

    public void SelectDateOfBirth(string dateOfBirth)
    {
        DateOfBirthInput.SendKeys(dateOfBirth);
    }

    public void SelectGender(string gender)
    {
        GenderDropdown.Click();
        var genderOption = driver.FindElement(By.XPath($"//span[text()='{gender}']"));
        genderOption.Click();
    }

    public void ClickRegisterUser()
    {
        RegisterUserButton.Click();
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
