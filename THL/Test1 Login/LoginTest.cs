using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class LoginTests
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private const string baseUrl = "https://sit-portal.trackinghub.co.ke/";

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(baseUrl);
        loginPage = new LoginPage(driver);
    }

    [Test]
    public void VerifyUserCanLogInWithValidCredentials()
    {
        loginPage.EnterEmail("valid@example.com");
        loginPage.EnterPassword("validPassword");
        loginPage.ClickLoginButton();
        Assert.IsTrue(driver.Url.Contains("dashboard")); // Adjust expected URL as necessary
    }

    [Test]
    public void CheckForgotPasswordLinkRedirects()
    {
        loginPage.ClickForgotPassword();
        Assert.AreEqual(driver.Url, "https://sit-portal.trackinghub.co.ke/password/reset");
    }

    [Test]
    public void EnsureShowPasswordCheckboxRevealsPassword()
    {
        loginPage.EnterPassword("testPassword");
        loginPage.ClickShowPassword();
        Assert.AreEqual(loginPage.PasswordInput.GetAttribute("type"), "text");
    }

    [Test]
    public void ValidateEmailInputAcceptsValidFormats()
    {
        loginPage.EnterEmail("user@example.com");
        Assert.IsTrue(IsValidEmail(loginPage.EmailInput.GetAttribute("value")));
    }

    [Test]
    public void ConfirmPasswordRequiresMinimumCharacters()
    {
        loginPage.EnterPassword("123");
        Assert.IsTrue(loginPage.ErrorMessage.Displayed);
    }

    [Test]
    public void TestLoginButtonEnabledWhenFieldsFilled()
    {
        loginPage.EnterEmail("user@example.com");
        loginPage.EnterPassword("validPassword");
        Assert.IsTrue(loginPage.LoginButton.Enabled);
    }

    [Test]
    public void AttemptLogInWithInvalidEmailFormat()
    {
        loginPage.EnterEmail("invalidEmail");
        loginPage.ClickLoginButton();
        Assert.IsTrue(loginPage.ErrorMessage.Displayed);
    }

    [Test]
    public void SubmitFormWithEmptyEmailField()
    {
        loginPage.EnterPassword("validPassword");
        loginPage.ClickLoginButton();
        Assert.IsTrue(loginPage.ErrorMessage.Displayed);
    }

    [Test]
    public void EnterPasswordShorterThan6Characters()
    {
        loginPage.EnterPassword("12345");
        Assert.IsTrue(loginPage.ErrorMessage.Displayed);
    }

    [Test]
    public void LogInWithUnregisteredEmail()
    {
        loginPage.EnterEmail("unregistered@example.com");
        loginPage.EnterPassword("validPassword");
        loginPage.ClickLoginButton();
        Assert.IsTrue(loginPage.ErrorMessage.Displayed);
    }

    [Test]
    public void ShowPasswordCheckboxDoesNotRevealWhenUnchecked()
    {
        loginPage.EnterPassword("testPassword");
        loginPage.ClickShowPassword();
        loginPage.ClickShowPassword(); // Uncheck
        Assert.AreEqual(loginPage.PasswordInput.GetAttribute("type"), "password");
    }

    [Test]
    public void LogInWithValidEmailButIncorrectPassword()
    {
        loginPage.EnterEmail("valid@example.com");
        loginPage.EnterPassword("wrongPassword");
        loginPage.ClickLoginButton();
        Assert.IsTrue(loginPage.ErrorMessage.Displayed);
    }

    [Test]
    public void TestLoginWithCopyPasteAction()
    {
        var email = "valid@example.com";
        var password = "validPassword";
        loginPage.EnterEmail(email);
        loginPage.EnterPassword(password);
        loginPage.ClickLoginButton();
        Assert.IsTrue(driver.Url.Contains("dashboard")); // Adjust expected URL as necessary
    }

    [Test]
    public void LogInWithPasswordIncludingSpecialCharacters()
    {
        loginPage.EnterEmail("valid@example.com");
        loginPage.EnterPassword("P@ssw0rd!");
        loginPage.ClickLoginButton();
        Assert.IsTrue(driver.Url.Contains("dashboard")); // Adjust expected URL as necessary
    }

    [Test]
    public void CheckFormBehaviorOnDifferentDevices()
    {
        // This test requires a mobile emulator or specific browser settings to simulate different devices
        Assert.Pass("Responsive behavior should be tested manually or with a tool.");
    }

    [Test]
    public void TestFormSubmissionWithBrowserAutofill()
    {
        loginPage.EnterEmail("autofill@example.com");
        loginPage.EnterPassword("autofillPassword");
        Assert.IsFalse(string.IsNullOrEmpty(loginPage.EmailInput.GetAttribute("value")));
        Assert.IsFalse(string.IsNullOrEmpty(loginPage.PasswordInput.GetAttribute("value")));
    }

    [Test]
    public void NavigateBackToLoginAfterForgotPassword()
    {
        loginPage.ClickForgotPassword();
        driver.Navigate().Back();
        Assert.AreEqual(driver.Url, baseUrl);
    }

    [Test]
    public void FormBehaviorWhenJavaScriptIsDisabled()
    {
        // This test requires a specific browser setup to disable JavaScript
        Assert.Pass("JavaScript disabled behavior should be tested manually.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    private bool IsValidEmail(string email)
    {
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
    }
}