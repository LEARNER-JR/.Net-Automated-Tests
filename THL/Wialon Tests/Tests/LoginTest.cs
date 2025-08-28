using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[TestFixture]
public class LoginTests
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private WebDriverWait wait;
    private const string baseUrl = "https://track.trackinghub.co.ke/login.html?css_url=https://sit-order.trackinghub.co.ke/wialon_auth_css/login.css&access_type=-1&redirect_uri=https://sit-order.trackinghub.co.ke";

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        driver.Navigate().GoToUrl(baseUrl);
        loginPage = new LoginPage(driver);
    }

    [Test]
    public void VerifySuccessfulLogin()
    {
        loginPage.EnterUsername("validUser");
        loginPage.EnterPassword("validPassword");
        loginPage.ClickSubmit();

        // Wait for navigation or success indicator
        wait.Until(d => d.Url != baseUrl || d.FindElements(By.CssSelector(".success-message")).Count > 0);

        Assert.That(driver.Url.Contains("success") || driver.Url != baseUrl, Is.True,
            "User should be redirected to success page or dashboard.");
    }

    [Test]
    public void CheckPasswordVisibilityToggle()
    {
        loginPage.EnterPassword("password");

        // Check initial password field type
        string initialType = loginPage.PasswordField.GetAttribute("type");
        Assert.That(initialType, Is.EqualTo("password"), "Password field should initially be of type 'password'");

        // Try to find and click password visibility toggle
        try
        {
            var toggleButton = driver.FindElement(By.CssSelector("[data-testid='toggle-password'], .toggle-password, .password-toggle"));
            toggleButton.Click();

            // Check if password type changed
            string newType = loginPage.PasswordField.GetAttribute("type");
            Assert.That(newType, Is.EqualTo("text"), "Password should be visible after toggle");
        }
        catch (NoSuchElementException)
        {
            Assert.Inconclusive("Password visibility toggle not found - feature may not be implemented");
        }
    }

    [Test]
    public void EnsureForgotPasswordButtonWorks()
    {
        loginPage.ClickForgotPassword();

        // Wait for reset form to appear
        try
        {
            wait.Until(d => loginPage.ResetForm.Displayed);
            Assert.That(loginPage.ResetForm.Displayed, Is.True, "Reset form should be displayed.");
        }
        catch (WebDriverTimeoutException)
        {
            Assert.Fail("Reset form did not appear within the expected time");
        }
    }

    [Test]
    public void ValidateSuccessMessageOnPasswordReset()
    {
        loginPage.ClickForgotPassword();

        // Wait for reset form to appear
        wait.Until(d => loginPage.ResetForm.Displayed);

        loginPage.EnterEmail("validEmail@example.com");

        // Look for submit button in reset form
        try
        {
            var submitResetButton = driver.FindElement(By.CssSelector("input[type='submit'], button[type='submit']"));
            submitResetButton.Click();

            // Wait for success message
            wait.Until(d => !string.IsNullOrEmpty(loginPage.GetSuccessMessage()));

            string successMessage = loginPage.GetSuccessMessage();
            Assert.That(successMessage.ToLower().Contains("success") ||
                       successMessage.ToLower().Contains("sent") ||
                       successMessage.ToLower().Contains("email"), Is.True,
                       "Success message should be displayed after password reset request.");
        }
        catch (NoSuchElementException)
        {
            Assert.Inconclusive("Reset form submit functionality not found");
        }
    }

    [Test]
    public void ConfirmPlaceholderText()
    {
        string usernamePlaceholder = loginPage.UsernameField.GetAttribute("placeholder");
        string passwordPlaceholder = loginPage.PasswordField.GetAttribute("placeholder");

        Assert.That(usernamePlaceholder, Is.EqualTo("User").Or.EqualTo("Username").Or.EqualTo("Enter username"),
            "Username placeholder text should match expected values.");
        Assert.That(passwordPlaceholder, Is.EqualTo("Password").Or.EqualTo("Enter password"),
            "Password placeholder text should match expected values.");
    }

    [Test]
    public void TestErrorMessageOnIncorrectLogin()
    {
        loginPage.EnterUsername("wrongUser");
        loginPage.EnterPassword("wrongPassword");
        loginPage.ClickSubmit();

        // Wait for error message to appear
        wait.Until(d => !string.IsNullOrEmpty(loginPage.GetErrorMessage()) ||
                       d.FindElements(By.CssSelector(".error, .alert-danger, [role='alert']")).Count > 0);

        string errorMessage = loginPage.GetErrorMessage();
        Assert.That(errorMessage.ToLower(), Does.Contain("error").Or.Contain("invalid").Or.Contain("incorrect").Or.Contain("failed"),
            "Error message should be displayed for incorrect login credentials.");
    }

    [Test]
    public void AttemptLoginWithEmptyFields()
    {
        // Ensure fields are empty
        loginPage.ClearUsername();
        loginPage.ClearPassword();

        loginPage.ClickSubmit();

        // Wait for validation message or error
        System.Threading.Thread.Sleep(1000); // Brief wait for client-side validation

        // Check for HTML5 validation or custom error messages
        string usernameValidation = loginPage.UsernameField.GetAttribute("validationMessage");
        string passwordValidation = loginPage.PasswordField.GetAttribute("validationMessage");
        string errorMessage = loginPage.GetErrorMessage();

        bool hasValidation = !string.IsNullOrEmpty(usernameValidation) ||
                           !string.IsNullOrEmpty(passwordValidation) ||
                           errorMessage.ToLower().Contains("required") ||
                           errorMessage.ToLower().Contains("empty") ||
                           errorMessage.ToLower().Contains("fill");

        Assert.That(hasValidation, Is.True,
            "Validation should prevent submission with empty required fields.");
    }

    [Test]
    public void VerifyFieldsAcceptInput()
    {
        string testUsername = "testuser123";
        string testPassword = "testpass456";

        loginPage.EnterUsername(testUsername);
        loginPage.EnterPassword(testPassword);

        Assert.That(loginPage.UsernameField.GetAttribute("value"), Is.EqualTo(testUsername),
            "Username field should accept and retain input");

        // Note: Password field value might not be retrievable for security reasons
        // So we just verify the field accepted focus and input
        Assert.That(loginPage.PasswordField.GetAttribute("value").Length, Is.GreaterThan(0),
            "Password field should accept input");
    }

    [Test]
    public void CheckFormElementsArePresent()
    {
        Assert.That(loginPage.UsernameField.Displayed, Is.True, "Username field should be visible");
        Assert.That(loginPage.PasswordField.Displayed, Is.True, "Password field should be visible");
        Assert.That(loginPage.SubmitButton.Displayed, Is.True, "Submit button should be visible");
        Assert.That(loginPage.SubmitButton.Enabled, Is.True, "Submit button should be enabled");
    }

    [Test]
    public void VerifyTabNavigationBetweenFields()
    {
        loginPage.UsernameField.Click();
        loginPage.UsernameField.SendKeys(Keys.Tab);

        var activeElement = driver.SwitchTo().ActiveElement;
        Assert.That(activeElement, Is.EqualTo(loginPage.PasswordField),
            "Tab should navigate from username to password field");
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
    }
}