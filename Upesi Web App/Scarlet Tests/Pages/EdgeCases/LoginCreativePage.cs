//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using System;

//public class LoginCreativePage
//{
//    private readonly IWebDriver _driver;
//    private readonly WebDriverWait _wait;

//    public LoginCreativePage(IWebDriver driver)
//    {
//        _driver = driver;
//        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//    }

//    public IWebElement EmailInput =>
//        _wait.Until(d => d.FindElement(By.Name("email")));

//    public IWebElement PasswordInput =>
//        _wait.Until(d => d.FindElement(By.Name("password")));

//    public IWebElement OTPInput =>
//        _wait.Until(d => d.FindElement(By.Name("OTP")));

//    public IWebElement SubmitButton =>
//        _wait.Until(d =>
//        {
//            var el = d.FindElement(By.ClassName("reset-btn-submit"));
//            return (el != null && el.Enabled) ? el : null;
//        });

//    public IWebElement Timer =>
//        _wait.Until(d => d.FindElement(By.ClassName("time")));

//    public void EnterEmail(string email)
//    {
//        var input = EmailInput;
//        input.Clear();
//        input.SendKeys(email);
//    }

//    public void EnterPassword(string password)
//    {
//        var input = PasswordInput;
//        input.Clear();
//        input.SendKeys(password);
//    }

//    public void EnterOTP(string otp)
//    {
//        var input = OTPInput;
//        input.Clear();
//        input.SendKeys(otp);
//    }

//    public void ClickSubmit()
//    {
//        SubmitButton.Click();
//    }

//    public string GetTimerText()
//    {
//        return Timer.Text;
//    }
//}

