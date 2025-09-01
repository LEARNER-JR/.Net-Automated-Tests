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

        Assert.IsTrue(loginPage.GetErrorMessage().Contains("Please enter a valid email address.")); // Adjust message as necessary
    }

    [Test]
    public void Test_IncorrectPassword()
    {
        loginPage.EnterEmail("valid@example.com");
        loginPage.EnterPassword("wrongPassword");
        loginPage.ClickSubmit();

        Assert.IsTrue(loginPage.GetErrorMessage().Contains("These credentials do not match our records.")); // Adjust message as necessary
    }

    [Test]
    public void Test_EmptyFields()
    {
        loginPage.ClickSubmit();

        Assert.IsTrue(loginPage.GetErrorMessage().Contains("The email field is required.")); // Adjust message as necessary
        Assert.IsTrue(loginPage.GetErrorMessage().Contains("The password field is required.")); // Adjust message as necessary
    }

    [Test]
    public void Test_ShortPassword()
    {
        loginPage.EnterEmail("valid@example.com");
        loginPage.EnterPassword("123");
        loginPage.ClickSubmit();

        Assert.IsTrue(loginPage.GetErrorMessage().Contains("The password must be at least 6 characters.")); // Adjust message as necessary
    }

    [Test]
    public void Test_ShowPasswordWithoutInput()
    {
        loginPage.ToggleShowPassword();

        Assert.AreEqual("", loginPage.PasswordInput.GetAttribute("value"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
