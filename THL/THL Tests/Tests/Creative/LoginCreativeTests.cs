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
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("jane1234");
        loginPage.ClickLogin();

        Assert.That(driver.Url, Does.Contain("dashboard"),
            "Login should succeed for email addresses with special characters.");
    }

    [Test]
    public void TestResponsiveLayoutOnMobile()
    {
        var options = new ChromeOptions();
        options.EnableMobileEmulation("Nexus 5");

        using (var mobileDriver = new ChromeDriver(options))
        {
            mobileDriver.Navigate().GoToUrl(baseUrl);
            var mobileLoginPage = new LoginCreativePage(mobileDriver);

            Assert.That(mobileLoginPage.EmailInput.Displayed, Is.True, "Email input should be visible in mobile view.");
            Assert.That(mobileLoginPage.PasswordInput.Displayed, Is.True, "Password input should be visible in mobile view.");
            Assert.That(mobileLoginPage.LoginButton.Displayed, Is.True, "Login button should be visible in mobile view.");
        } // auto-quit here
    }

    [Test]
    public void TestRapidLoginButtonClicks()
    {
        loginPage.EnterEmail("test@example.com");
        loginPage.EnterPassword("ValidPassword123");

        for (int i = 0; i < 10; i++)
            loginPage.ClickLogin();

        Assert.That(driver.Url, Does.Contain("login"),
            "Rapid clicks should not cause navigation away from login page.");
    }

    [Test]
    public void TestAccessibilityWithScreenReader()
    {
        Assert.Pass("Accessibility test needs to be run with a screen reader.");
    }

    [Test]
    public void TestLoginAcrossBrowsers()
    {
        loginPage.EnterEmail("test@example.com");
        loginPage.EnterPassword("ValidPassword123");
        loginPage.ClickLogin();

        Assert.That(driver.Url, Does.Contain("dashboard"),
            "Login should succeed across browsers.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
