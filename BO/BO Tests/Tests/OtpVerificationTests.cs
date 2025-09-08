//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using Assert = NUnit.Framework.Assert;

//[TestFixture]
//public class OtpVerificationTests
//{
//    private IWebDriver _driver;
//    private OTPVerificationPage _otpVerificationPage;
//    private const string BaseUrl = "https://sit-ui.upesimts.com/auth/otp";

//    [SetUp]
//    public void SetUp()
//    {
//        _driver = new ChromeDriver();
//        _driver.Navigate().GoToUrl(BaseUrl);
//        _otpVerificationPage = new OTPVerificationPage(_driver);
//    }

//    [Test]
//    public void VerifyOtpVerificationScreenTitle()
//    {
//        Assert.That(_otpVerificationPage.Title, Is.EqualTo("OTP Verification"));
//    }

//    [Test]
//    public void ConfirmOtpSentMessage()
//    {
//        Assert.That(_otpVerificationPage.OtpMessage.Text, Does.Contain("+*********12"));
//    }

//    [Test]
//    public void CheckOtpInputFieldsDisplayedCorrectly()
//    {
//        Assert.That(_otpVerificationPage.OtpInputFields.Displayed, Is.True);
//    }

//    [Test]
//    public void EnsureOtpInputFieldsAcceptCharacters()
//    {
//        _otpVerificationPage.EnterOtp("4Y27KJ");
//        var inputs = _driver.FindElements(By.ClassName("rizzui-pin-code-field"));

//        Assert.That(inputs[0].GetAttribute("value"), Is.EqualTo("4"));
//        Assert.That(inputs[1].GetAttribute("value"), Is.EqualTo("Y"));
//        Assert.That(inputs[2].GetAttribute("value"), Is.EqualTo("2"));
//        Assert.That(inputs[3].GetAttribute("value"), Is.EqualTo("7"));
//        Assert.That(inputs[4].GetAttribute("value"), Is.EqualTo("K"));
//    }

//    [Test]
//    public void VerifyOtpButtonEnabledWhenAllFieldsFilled()
//    {
//        _otpVerificationPage.EnterOtp("4Y27KJ");
//        Assert.That(_otpVerificationPage.VerifyOtpButton.Enabled, Is.True);
//    }

//    [Test]
//    public void ValidateResendOtpButtonInitiallyDisabled()
//    {
//        Assert.That(_otpVerificationPage.ResendOtpButton.Enabled, Is.False);
//    }

//    [Test]
//    public void ConfirmCountdownTimerDisplayedAndCountsDown()
//    {
//        Assert.That(_otpVerificationPage.CountdownTimer.Displayed, Is.True);
//        // TODO: Add logic to verify countdown decreasing.
//    }

//    [Test]
//    public void SubmitWithEmptyFieldsShowsErrorMessage()
//    {
//        _otpVerificationPage.ClickVerifyOtpButton();
//        // TODO: Assert error message displayed.
//    }

//    [Test]
//    public void EnterIncorrectOtpShowsErrorMessage()
//    {
//        _otpVerificationPage.EnterOtp("INVALID");
//        _otpVerificationPage.ClickVerifyOtpButton();
//        // TODO: Assert error message displayed.
//    }

//    [Test]
//    public void VerifyOtpButtonNotClickableBeforeFillingFields()
//    {
//        Assert.That(_otpVerificationPage.VerifyOtpButton.Enabled, Is.False);
//    }

//    [Test]
//    public void ResendOtpButtonRemainsDisabledDuringCountdown()
//    {
//        Assert.That(_otpVerificationPage.ResendOtpButton.Enabled, Is.False);
//        // TODO: Add logic to wait until countdown expires and check enabled state.
//    }

//    [Test]
//    public void SpecialCharactersAndSpacesNotAccepted()
//    {
//        _otpVerificationPage.EnterOtp("4Y27 KJ");
//        var inputs = _driver.FindElements(By.ClassName("rizzui-pin-code-field"));

//        foreach (var input in inputs)
//        {
//            Assert.That(input.GetAttribute("value"), Is.Not.EqualTo(" "));
//        }
//    }

//    [Test]
//    public void HandleMultipleOtpsCorrectly()
//    {
//        // TODO: Simulate multiple OTPs being sent and assert last OTP is handled correctly.
//    }

//    [Test]
//    public void StatePreservedOnNavigationAwayAndBack()
//    {
//        // TODO: Navigate away and return, then assert OTP state and timer preserved.
//    }

//    [Test]
//    public void UserExperienceOnSuccessfulVerification()
//    {
//        _otpVerificationPage.EnterOtp("4Y27KJ");
//        _otpVerificationPage.ClickVerifyOtpButton();
//        // TODO: Assert redirect to correct page.
//    }

//    [Test]
//    public void LockoutPeriodAfterMultipleIncorrectOtps()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            _otpVerificationPage.EnterOtp("INVALID");
//            _otpVerificationPage.ClickVerifyOtpButton();
//        }
//        // TODO: Assert lockout period applied.
//    }

//    [Test]
//    public void HandleMultipleResendOtpRequests()
//    {
//        _otpVerificationPage.ClickResendOtpButton();
//        // TODO: Assert multiple resend requests handled correctly.
//    }

//    [TearDown]
//    public void TearDown()
//    {
//        _driver.Quit();
//    }
//}
