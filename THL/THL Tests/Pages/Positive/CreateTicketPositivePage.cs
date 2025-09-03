using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class CreateTicketPositivePage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public CreateTicketPositivePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Locators
    public IWebElement NewTicketLink => wait.Until(driver => driver.FindElement(By.LinkText("newticket")));
    public IWebElement NewTicketIcon => wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/newticket'] .fa-plus")));
    public IWebElement JobTypeDropdown => wait.Until(driver => driver.FindElement(By.Id("jobtype")));
    public IWebElement SubjectInput => wait.Until(driver => driver.FindElement(By.Id("subject")));
    public IWebElement RegNoInput => wait.Until(driver => driver.FindElement(By.Id("regno")));
    public IWebElement CustomerNameInput => wait.Until(driver => driver.FindElement(By.Id("customername")));
    public IWebElement EmailInput => wait.Until(driver => driver.FindElement(By.Id("email")));
    public IWebElement CustomerPhoneInput => wait.Until(driver => driver.FindElement(By.Id("customerphone")));
    public IWebElement ContactPhoneInput => wait.Until(driver => driver.FindElement(By.Id("contactphone")));
    public IWebElement VehicleMakeDropdown => wait.Until(driver => driver.FindElement(By.Id("make")));
    public IWebElement ModelInput => wait.Until(driver => driver.FindElement(By.Id("model")));
    public IWebElement ColorInput => wait.Until(driver => driver.FindElement(By.Id("color")));
    public IWebElement VehicleLocInput => wait.Until(driver => driver.FindElement(By.Id("vehicleloc")));
    public IWebElement LoanAmtInput => wait.Until(driver => driver.FindElement(By.Id("loanAmt")));
    public IWebElement SubmitButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@type='submit']")));

    public bool IsNewTicketLinkVisible()
    {
        try
        {
            return NewTicketLink.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public void ClickNewTicketLink()
    {
        NewTicketLink.Click();
    }

    public bool IsNewTicketIconDisplayed()
    {
        try
        {
            return NewTicketIcon.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
    public void SelectJobType(string jobType)
    {
        var selectElement = new SelectElement(JobTypeDropdown);
        selectElement.SelectByText(jobType);
    }

    public void EnterSubject(string subject) => SetInput(SubjectInput, subject);
    public void EnterRegNo(string regNo) => SetInput(RegNoInput, regNo);
    public void EnterCustomerName(string name) => SetInput(CustomerNameInput, name);
    public void EnterEmail(string email) => SetInput(EmailInput, email);
    public void EnterCustomerPhone(string phone) => SetInput(CustomerPhoneInput, phone);
    public void EnterContactPhone(string phone) => SetInput(ContactPhoneInput, phone);

    public void SelectVehicleMake(string make)
    {
        var selectElement = new SelectElement(VehicleMakeDropdown);
        selectElement.SelectByText(make);
    }

    public void EnterModel(string model) => SetInput(ModelInput, model);
    public void EnterColor(string color) => SetInput(ColorInput, color);
    public void EnterVehicleLoc(string loc) => SetInput(VehicleLocInput, loc);
    public void EnterLoanAmt(string amt) => SetInput(LoanAmtInput, amt);

    public void SubmitForm() => SubmitButton.Click();

    // Helper
    private void SetInput(IWebElement element, string value)
    {
        element.Clear();
        element.SendKeys(value);
    }
}
