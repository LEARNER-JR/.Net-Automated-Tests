using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class LoginNegativeTests
{
    private IWebDriver driver;
    private LoginNegativePage loginPage;
    private string baseUrl = "https://sit-portal.trackinghub.co.ke/";

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(baseUrl);
        loginPage = new LoginNegativePage(driver);
    }

    [Test]
    public void Test_InvalidEmailFormat()
    {
        loginPage.EnterEmail("invalid-email");
        loginPage.EnterPassword("anyPassword");
        loginPage.ClickSubmit();

        Assert.That(loginPage.GetErrorMessage(),
            Does.Contain("Please enter a valid email address."),
            "The system should show an error for invalid email format.");
    }

    [Test]
    public void Test_IncorrectPassword()
    {
        loginPage.EnterEmail("valid@example.com");
        loginPage.EnterPassword("wrongPassword");
        loginPage.ClickSubmit();

        Assert.That(loginPage.GetErrorMessage(),
            Does.Contain("These credentials do not match our records."),
            "The system should show an error for incorrect password.");
    }

    [Test]
    public void Test_EmptyFields()
    {
        loginPage.ClickSubmit();

        Assert.That(loginPage.GetErrorMessage(),
            Does.Contain("The email field is required."),
            "The system should show an error when email is missing.");
        Assert.That(loginPage.GetErrorMessage(),
            Does.Contain("The password field is required."),
            "The system should show an error when password is missing.");
    }

    [Test]
    public void Test_ShortPassword()
    {
        loginPage.EnterEmail("valid@example.com");
        loginPage.EnterPassword("123");
        loginPage.ClickSubmit();

        Assert.That(loginPage.GetErrorMessage(),
            Does.Contain("The password must be at least 6 characters."),
            "The system should show an error for too short password.");
    }

    [Test]
    public void Test_ShowPasswordWithoutInput()
    {
        loginPage.ToggleShowPassword();

        Assert.That(loginPage.PasswordInput.GetAttribute("value"),
            Is.EqualTo(""),
            "Password field should remain empty when toggling show without input.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
