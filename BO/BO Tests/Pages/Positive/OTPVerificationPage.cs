//using OpenQA.Selenium;

//public class OTPVerificationPage
//{
//    private readonly IWebDriver driver;

//    public OTPVerificationPage(IWebDriver driver)
//    {
//        this.driver = driver;
//    }

//    // Selectors
//    private By otpFields => By.CssSelector(".rizzui-pin-code-field");
//    private By verifyButton => By.XPath("//button[contains(text(),'Verify OTP')]");
//    private By resendButton => By.XPath("//button[contains(text(),'Resend OTP')]");
//    private By countdownTimer => By.XPath("//strong[contains(text(), 'Resend in:')]");
//    private By otpDisplay => By.XPath("//h4[contains(text(),'TEST OTP:')]");

//    // Actions
//    public void EnterOTP(string otp)
//    {
//        var fields = driver.FindElements(otpFields);
//        for (int i = 0; i < otp.Length && i < fields.Count; i++)
//        {
//            fields[i].Clear();
//            fields[i].SendKeys(otp[i].ToString());
//        }
//    }

//    public string GetDisplayedOTP()
//    {
//        var otpText = driver.FindElement(otpDisplay).Text;
//        return otpText.Replace("TEST OTP:", "").Trim();
//    }

//    public bool IsVerifyButtonClickable()
//    {
//        return driver.FindElement(verifyButton).Enabled;
//    }

//    public bool IsResendButtonDisabled()
//    {
//        return !driver.FindElement(resendButton).Enabled;
//    }

//    public string GetCountdownText()
//    {
//        return driver.FindElement(countdownTimer).Text;
//    }
//    public bool IsResendButtonEnabled()
//    {
//        return driver.FindElement(resendButton).Enabled;
//    }

//    public bool IsVerifyButtonEnabled()
//    {
//        return driver.FindElement(verifyButton).Enabled;
//    }

//}
