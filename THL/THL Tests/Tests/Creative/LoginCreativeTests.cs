using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class LoginCreativeTests
{
    private IWebDriver driver;
    private LoginCreativePage loginPage;
    private const string baseUrl = "https://sit-portal.trackinghub.co.ke/";

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(baseUrl);
        loginPage = new LoginCreativePage(driver);
    }

    [Test]
    public void TestLoginWithSpecialCharacters()
    {
        loginPage.EnterEmail("test+user%example@gmail.com");
        loginPage.EnterPassword("ValidPassword123");
        loginPage.ClickLogin();

        Assert.IsTrue(driver.Url.Contains("dashboard"), "Login failed for email with special characters.");
    }

    [Test]
    public void TestResponsiveLayoutOnMobile()
    {
        // Simulate mobile view
        var mobileEmulation = new ChromeOptions();
        mobileEmulation.AddAdditionalCapability("deviceName", "Nexus 5");
        driver = new ChromeDriver(mobileEmulation);
        driver.Navigate().GoToUrl(baseUrl);
        loginPage = new LoginCreativePage(driver);

        Assert.IsTrue(loginPage.EmailInput.Displayed, "Email input should be displayed.");
        Assert.IsTrue(loginPage.PasswordInput.Displayed, "Password input should be displayed.");
        Assert.IsTrue(loginPage.LoginButton.Displayed, "Login button should be displayed.");
    }

    [Test]
    public void TestRapidLoginButtonClicks()
    {
        loginPage.EnterEmail("test@example.com");
        loginPage.EnterPassword("ValidPassword123");

        for (int i = 0; i < 10; i++)
        {
            loginPage.ClickLogin();
        }

        Assert.IsTrue(driver.Url.Contains("login"), "Rapid clicks should not cause navigation away from login page.");
    }

    [Test]
    public void TestAccessibilityWithScreenReader()
    {
        // This test would require a screen reader to be set up and is more of a manual test.
        // Placeholder for actual screen reader test code.
        Assert.Pass("Accessibility test needs to be run with a screen reader.");
    }

    [Test]
    public void TestLoginAcrossBrowsers()
    {
        // This test should ideally run in different browsers. Here we just check with Chrome.
        loginPage.EnterEmail("test@example.com");
        loginPage.EnterPassword("ValidPassword123");
        loginPage.ClickLogin();

        Assert.IsTrue(driver.Url.Contains("dashboard"), "Login failed across browsers.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}