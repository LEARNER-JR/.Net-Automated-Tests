//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using Assert = NUnit.Framework.Assert;

//[TestFixture]
//public class OTPVerificationTests
//{
//    private IWebDriver driver;
//    private OTPVerificationPage otpPage;
//    private const string baseUrl = "https://sit-ui.upesimts.com/auth/otp";

//    [SetUp]
//    public void Setup()
//    {
//        driver = new ChromeDriver();
//        driver.Navigate().GoToUrl(baseUrl);
//        otpPage = new OTPVerificationPage(driver);
//    }

//    [Test]
//    public void VerifyOTPFieldsAcceptValidCharacters()
//    {
//        var otp = otpPage.GetDisplayedOTP();
//        otpPage.EnterOTP(otp);

//        var fields = driver.FindElements(By.CssSelector(".rizzui-pin-code-field"));
//        for (int i = 0; i < otp.Length; i++)
//        {
//            Assert.That(fields[i].GetAttribute("value"), Is.EqualTo(otp[i].ToString()));
//        }
//    }

//    [Test]
//    public void VerifyButtonIsClickableWithValidOTP()
//    {
//        var otp = otpPage.GetDisplayedOTP();
//        otpPage.EnterOTP(otp);

//        Assert.That(otpPage.IsVerifyButtonClickable(), Is.True);
//    }

//    [Test]
//    public void VerifyOTPDisplayedCorrectly()
//    {
//        var otp = otpPage.GetDisplayedOTP();
//        otpPage.EnterOTP(otp);

//        var fields = driver.FindElements(By.CssSelector(".rizzui-pin-code-field"));
//        for (int i = 0; i < otp.Length; i++)
//        {
//            Assert.That(fields[i].GetAttribute("value"), Is.EqualTo(otp[i].ToString()));
//        }
//    }

//    [Test]
//    public void ResendButtonIsDisabledInitially()
//    {
//        Assert.That(otpPage.IsResendButtonDisabled(), Is.True);
//    }

//    [Test]
//    public void CountdownTimerFunctionality()
//    {
//        var countdownText = otpPage.GetCountdownText();
//        Assert.That(countdownText, Does.Contain("Resend in:"));
//    }

//    [Test]
//    public void VerifyMutualExclusivityOfResendAndVerifyButtons()
//    {
//        // Case 1: Immediately after page load
//        Assert.That(otpPage.IsVerifyButtonEnabled(), Is.True, "Verify button should be enabled while timer is running");
//        Assert.That(otpPage.IsResendButtonEnabled(), Is.False, "Resend button should be disabled while timer is running");

//        // Case 2: After countdown finishes, Verify becomes disabled & Resend becomes enabled
//        var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(60));
//        wait.Until(d => otpPage.IsResendButtonEnabled());

//        Assert.That(otpPage.IsResendButtonEnabled(), Is.True, "Resend button should be enabled after countdown finishes");
//        Assert.That(otpPage.IsVerifyButtonEnabled(), Is.False, "Verify button should be disabled if OTP not entered after countdown");
//    }
//    [TearDown]
//    public void TearDown()
//    {
//        driver.Quit();
//    }
//}
