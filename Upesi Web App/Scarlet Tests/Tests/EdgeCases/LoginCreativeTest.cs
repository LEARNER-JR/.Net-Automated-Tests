//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//[TestFixture]
//public class LoginCreativeTests
//{
//    private IWebDriver _driver;
//    private LoginCreativePage _loginPage;
//    private const string BaseUrl = "https://sitwebapp.upesimts.com/login?unauthorized";

//    [SetUp]
//    public void Setup()
//    {
//        _driver = new ChromeDriver();
//        _driver.Navigate().GoToUrl(BaseUrl);
//        _loginPage = new LoginCreativePage(_driver);
//    }

//    [Test]
//    public void TestLoginDuringTimer()
//    {
//        _loginPage.EnterEmail("test@example.com");
//        _loginPage.EnterPassword("validpassword");
//        _loginPage.EnterOTP("6FUP55");
//        _loginPage.ClickSubmit();

//        Assert.That(IsLoginSuccessful(), Is.False,
//            "Login should not be successful while timer is running.");
//    }

//    [Test]
//    public void TestChangingCredentialsBeforeSubmission()
//    {
//        _loginPage.EnterEmail("test@example.com");
//        _loginPage.EnterPassword("validpassword");
//        _loginPage.EnterEmail("changed@example.com");
//        _loginPage.EnterPassword("changedpassword");
//        _loginPage.ClickSubmit();

//        Assert.That(IsLoginSuccessful(), Is.True,
//            "Login should process the latest inputs correctly.");
//    }

//    [Test]
//    public void TestRapidLoginClicks()
//    {
//        _loginPage.EnterEmail("test@example.com");
//        _loginPage.EnterPassword("validpassword");

//        for (int i = 0; i < 10; i++)
//        {
//            _loginPage.ClickSubmit();
//        }

//        Assert.That(CheckForErrors(), Is.True,
//            "System should handle rapid clicks without crashing.");
//    }

//    [Test]
//    public void TestAccessibilityWithKeyboard()
//    {
//        _loginPage.EmailInput.SendKeys(Keys.Tab);
//        Assert.That(_loginPage.PasswordInput.Displayed, Is.True,
//            "Password field should be reachable via Tab key.");

//        _loginPage.PasswordInput.SendKeys(Keys.Tab);
//        Assert.That(_loginPage.OTPInput.Displayed, Is.True,
//            "OTP field should be reachable via Tab key.");

//        _loginPage.OTPInput.SendKeys(Keys.Tab);
//        Assert.That(_loginPage.SubmitButton.Displayed, Is.True,
//            "Submit button should be reachable via Tab key.");
//    }

//    [Test]
//    public void TestMultipleLoginAttempts()
//    {
//        for (int i = 0; i < 5; i++)
//        {
//            _loginPage.EnterEmail("test@example.com");
//            _loginPage.EnterPassword("validpassword");
//            _loginPage.ClickSubmit();
//        }

//        Assert.That(CheckForBruteForceProtection(), Is.True,
//            "System should handle multiple login attempts gracefully.");
//    }

//    [TearDown]
//    public void TearDown()
//    {
//        _driver.Quit();
//    }

//    private bool IsLoginSuccessful()
//    {
//        // Stub: Replace with actual verification logic (URL, element, etc.)
//        return false;
//    }

//    private bool CheckForErrors()
//    {
//        // Stub: Replace with actual logic (look for error banner, console logs, etc.)
//        return true;
//    }

//    private bool CheckForBruteForceProtection()
//    {
//        // Stub: Replace with actual logic (look for lockout message, captcha, etc.)
//        return true;
//    }
//}
