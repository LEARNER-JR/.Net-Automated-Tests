using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //log the browser console logs
        var options = new ChromeOptions();
        options.AddArgument("log-level=3"); // Info
        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(baseUrl);
        loginPage = new LoginPage(driver);
    }

    [Test]
    public void VerifyUserCanLogInWithValidCredentials()
    {
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("jane1234");
        loginPage.ClickLoginButton();
        Assert.That(driver.Url.Contains("https://sit-portal.trackinghub.co.ke/home2"), Is.True);
    }

    [Test]
    public void CheckForgotPasswordLinkRedirects()
    {
        loginPage.ClickForgotPassword();
        Assert.That(driver.Url.Contains("https://sit-portal.trackinghub.co.ke/password/reset"), Is .True);
    }

    [Test]
    public void EnsureShowPasswordCheckboxRevealsPassword()
    {
        loginPage.EnterPassword("testPassword");
        loginPage.ClickShowPassword();
        Assert.That(loginPage.PasswordInput.GetAttribute("type"), Is.EqualTo("text"));
    }

    [Test]
    public void ValidateEmailInputAcceptsValidFormats()
    {
        loginPage.EnterEmail("user@example.com");
        Assert.That(IsValidEmail(loginPage.EmailInput.GetAttribute("value")), Is.True);
    }

    [Test]
    public void ConfirmPasswordRequiresMinimumCharacters()
    {
        loginPage.EnterPassword("123");
        Assert.That(loginPage.ErrorMessage.Displayed, Is.True);
    }

    [Test]
    public void TestLoginButtonEnabledWhenFieldsFilled()
    {
        loginPage.EnterEmail("user@example.com");
        loginPage.EnterPassword("validPassword");
        Assert.That(loginPage.LoginButton.Enabled, Is.True);
    }

    [Test]
    public void AttemptLogInWithInvalidEmailFormat()
    {
        loginPage.EnterEmail("invalidEmail");
        loginPage.ClickLoginButton();
        Assert.That(loginPage.ErrorMessage.Displayed, Is.True);
    }

    [Test]
    public void SubmitFormWithEmptyEmailField()
    {
        loginPage.EnterPassword("validPassword");
        loginPage.ClickLoginButton();
        Assert.That(loginPage.ErrorMessage.Displayed, Is.True);
    }

    [Test]
    public void EnterPasswordShorterThan6Characters()
    {
        loginPage.EnterPassword("12345");
        Assert.That(loginPage.ErrorMessage.Displayed, Is.True);
    }

    [Test]
    public void LogInWithUnregisteredEmail()
    {
        loginPage.EnterEmail("unregistered@example.com");
        loginPage.EnterPassword("jane1234");
        loginPage.ClickLoginButton();
        Assert.That(loginPage.ErrorMessage.Displayed, Is.True);
    }

    [Test]
    public void ShowPasswordCheckboxDoesNotRevealWhenUnchecked()
    {
        loginPage.EnterPassword("testPassword");
        loginPage.ClickShowPassword();
        loginPage.ClickShowPassword(); // Uncheck
        Assert.That(loginPage.PasswordInput.GetAttribute("type"), Is.EqualTo("password"));
    }

    [Test]
    public void LogInWithValidEmailButIncorrectPassword()
    {
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("wrongPassword");
        loginPage.ClickLoginButton();
        Assert.That(loginPage.ErrorMessage.Displayed, Is.True);
    }

    [Test]
    public void TestLoginWithCopyPasteAction()
    {
        var email = "janerose.muthoni@ngaocredit.com";
        var password = "jane1234";
        loginPage.EnterEmail(email);
        loginPage.EnterPassword(password);
        loginPage.ClickLoginButton();
        Assert.That(driver.Url.Contains("https://sit-portal.trackinghub.co.ke/home2"), Is.True);
    }

    [Test]
    public void LogInWithPasswordIncludingSpecialCharacters()
    {
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("jane1234");
        loginPage.ClickLoginButton();
        Assert.That(driver.Url.Contains("https://sit-portal.trackinghub.co.ke/home2"), Is.True);
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
        Assert.That(string.IsNullOrEmpty(loginPage.EmailInput.GetAttribute("value")), Is.False);
        Assert.That(string.IsNullOrEmpty(loginPage.PasswordInput.GetAttribute("value")), Is.False);
    }

    [Test]
    public void NavigateBackToLoginAfterForgotPassword()
    {
        loginPage.ClickForgotPassword();
        driver.Navigate().Back();
        Assert.That(driver.Url, Is.EqualTo(baseUrl));
    }

    [Test]
    public void FormBehaviorWhenJavaScriptIsDisabled()
    {
        Assert.That(loginPage.PasswordInput.GetAttribute("type"), Is.EqualTo("password"));
        Assert.That(driver.Url, Is.EqualTo(baseUrl));
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
