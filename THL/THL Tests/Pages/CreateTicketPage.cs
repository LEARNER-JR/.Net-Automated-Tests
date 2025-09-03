//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;

//public class CreateTicketPage
//{
//    private IWebDriver driver;
//    private WebDriverWait wait;

//    public CreateTicketPage(IWebDriver driver)
//    {
//        this.driver = driver;
//        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//    }

//    public IWebElement JobTypeDropdown => wait.Until(driver => driver.FindElement(By.Id("jobtype")));
//    public IWebElement SubjectInput => wait.Until(driver => driver.FindElement(By.Id("subject")));
//    public IWebElement RegNoInput => wait.Until(driver => driver.FindElement(By.Id("regno")));
//    public IWebElement CustomerNameInput => wait.Until(driver => driver.FindElement(By.Id("customername")));
//    public IWebElement EmailInput => wait.Until(driver => driver.FindElement(By.Id("email")));
//    public IWebElement CustomerPhoneInput => wait.Until(driver => driver.FindElement(By.Id("customerphone")));
//    public IWebElement ContactPhoneInput => wait.Until(driver => driver.FindElement(By.Id("contactphone")));
//    public IWebElement VehicleMakeDropdown => wait.Until(driver => driver.FindElement(By.Id("make")));
//    public IWebElement ModelInput => wait.Until(driver => driver.FindElement(By.Id("model")));
//    public IWebElement ColorInput => wait.Until(driver => driver.FindElement(By.Id("color")));
//    public IWebElement VehicleLocInput => wait.Until(driver => driver.FindElement(By.Id("vehicleloc")));
//    public IWebElement LoanAmtInput => wait.Until(driver => driver.FindElement(By.Id("loanAmt")));
//    public IWebElement SubmitButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@type='submit']")));

//    public void SelectJobType(string jobType)
//    {
//        var selectElement = new SelectElement(JobTypeDropdown);
//        selectElement.SelectByText(jobType);
//    }

//    public void EnterSubject(string subject)
//    {
//        SubjectInput.Clear();
//        SubjectInput.SendKeys(subject);
//    }

//    public void EnterRegNo(string regNo)
//    {
//        RegNoInput.Clear();
//        RegNoInput.SendKeys(regNo);
//    }

//    public void EnterCustomerName(string name)
//    {
//        CustomerNameInput.Clear();
//        CustomerNameInput.SendKeys(name);
//    }

//    public void EnterEmail(string email)
//    {
//        EmailInput.Clear();
//        EmailInput.SendKeys(email);
//    }

//    public void EnterCustomerPhone(string phone)
//    {
//        CustomerPhoneInput.Clear();
//        CustomerPhoneInput.SendKeys(phone);
//    }

//    public void EnterContactPhone(string phone)
//    {
//        ContactPhoneInput.Clear();
//        ContactPhoneInput.SendKeys(phone);
//    }

//    public void SelectVehicleMake(string make)
//    {
//        var selectElement = new SelectElement(VehicleMakeDropdown);
//        selectElement.SelectByText(make);
//    }

//    public void EnterModel(string model)
//    {
//        ModelInput.Clear();
//        ModelInput.SendKeys(model);
//    }

//    public void EnterColor(string color)
//    {
//        ColorInput.Clear();
//        ColorInput.SendKeys(color);
//    }

//    public void EnterVehicleLoc(string loc)
//    {
//        VehicleLocInput.Clear();
//        VehicleLocInput.SendKeys(loc);
//    }

//    public void EnterLoanAmt(string amt)
//    {
//        LoanAmtInput.Clear();
//        LoanAmtInput.SendKeys(amt);
//    }

//    public void SubmitForm()
//    {
//        SubmitButton.Click();
//    }

//    public async Task<IWebElement> WaitForElementAsync(By by, int timeoutInSeconds = 10)
//    {
//        return await Task.Run(() =>
//        {
//            WebDriverWait asyncWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
//            return asyncWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
//        });
//    }

//}