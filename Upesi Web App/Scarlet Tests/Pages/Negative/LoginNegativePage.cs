//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;

//public class LoginNegativePage
//{
//    private IWebDriver driver;
//    private WebDriverWait wait;

//    public LoginNegativePage(IWebDriver driver)
//    {
//        this.driver = driver;
//        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//    }

//    public IWebElement EmailInput => wait.Until(d => d.FindElement(By.Name("email")));
//    public IWebElement PasswordInput => wait.Until(d => d.FindElement(By.Name("password")));
//    public IWebElement OTPInput => wait.Until(d => d.FindElement(By.Name("OTP")));
//    public IWebElement SubmitButton => wait.Until(d => d.FindElement(By.ClassName("reset-btn-submit")));
//    public IWebElement ErrorText => wait.Until(d => d.FindElement(By.ClassName("login-error")));

//    public void EnterEmail(string email)
//    {
//        EmailInput.Clear();
//        EmailInput.SendKeys(email);
//    }

//    public void EnterPassword(string password)
//    {
//        PasswordInput.Clear();
//        PasswordInput.SendKeys(password);
//    }

//    public void EnterOTP(string otp)
//    {
//        OTPInput.Clear();
//        OTPInput.SendKeys(otp);
//    }

//    public void SubmitForm()
//    {
//        SubmitButton.Click();
//    }
//}
