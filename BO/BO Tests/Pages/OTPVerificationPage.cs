//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;

//public class OTPVerificationPage
//{
//    private readonly IWebDriver _driver;
//    private readonly WebDriverWait _wait;

//    public OTPVerificationPage(IWebDriver driver)
//    {
//        _driver = driver;
//        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//    }

//    public string Title => _driver.Title;

//    public IWebElement OtpTitle => _wait.Until(d => d.FindElement(By.XPath("//h2[text()='OTP Verification']")));
//    public IWebElement OtpMessage => _wait.Until(d => d.FindElement(By.XPath("//p[contains(text(), 'OTP has been sent to')]")));
//    public IWebElement OtpInputFields => _wait.Until(d => d.FindElement(By.ClassName("rizzui-pin-code-container")));
//    public IWebElement VerifyOtpButton => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Verify OTP']")));
//    public IWebElement ResendOtpButton => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Resend OTP']")));
//    public IWebElement CountdownTimer => _wait.Until(d => d.FindElement(By.XPath("//p[contains(text(), 'Resend in:')]")));

//    public void EnterOtp(string otp)
//    {
//        var inputs = _driver.FindElements(By.ClassName("rizzui-pin-code-field"));
//        for (int i = 0; i < otp.Length; i++)
//        {
//            inputs[i].Clear();
//            inputs[i].SendKeys(otp[i].ToString());
//        }
//    }

//    public void ClickVerifyOtpButton()
//    {
//        VerifyOtpButton.Click();
//    }

//    public void ClickResendOtpButton()
//    {
//        ResendOtpButton.Click();
//    }
//}

