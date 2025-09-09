using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class UserManagementPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public UserManagementPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement FirstNameInput => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("firstName")));
    public IWebElement MiddleNameInput => driver.FindElement(By.Name("middleName"));
    public IWebElement LastNameInput => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("lastName")));
    public IWebElement EmailInput => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("email")));
    public IWebElement PhoneNumberInput => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='tel']")));
    public IWebElement DateOfBirthInput => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[placeholder='Select Date']")));
    public IWebElement GenderDropdown => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("headlessui-listbox-button-:r1v:")));
    public IWebElement CompanyInput => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("react-select-4-input")));
    public IWebElement CreateUserButton => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Create User']")));

    //elements
    public void FillFirstName(string firstName) => FirstNameInput.SendKeys(firstName);
    public void FillMiddleName(string middleName) => MiddleNameInput.SendKeys(middleName);
    public void FillLastName(string lastName) => LastNameInput.SendKeys(lastName);
    public void FillEmail(string email) => EmailInput.SendKeys(email);
    public void FillPhoneNumber(string phoneNumber) => PhoneNumberInput.SendKeys(phoneNumber);
    public void FillDateOfBirth(string dob) => DateOfBirthInput.SendKeys(dob);


    public void NavigateToUserManagementPage()
    {

        driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/user-management/system-users");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("user-management/system-users"));
       // wait.Until(d => d.Url.Contains("user-management/system-users"));
    }
    public void ClickAddNewUserButton()
    {
        var addNewUserButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/main/div/div/div/div[1]/div[3]/button")));
        addNewUserButton.Click();
    }
    public void WaitForPageLoad()
    {
        wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }
    public void SelectGender(string gender)
    {
        GenderDropdown.Click();
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[text()='{gender}']"))).Click();
    }

    public void FillCompany(string company) => CompanyInput.SendKeys(company);

    public void SubmitForm() => CreateUserButton.Click();
}