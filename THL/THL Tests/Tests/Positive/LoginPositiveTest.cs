using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class LoginPositiveTest
{
    private IWebDriver _driver;
    private LoginPositivePage _loginPositivePage;
    private const string BaseUrl = "https://sit-portal.trackinghub.co.ke/";

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(BaseUrl);
        _loginPositivePage = new LoginPositivePage(_driver);
    }

    [Test]
    public void TestSuccessfulLogin()
    {
        _loginPositivePage.EnterEmail("janerose.muthoni@ngaocredit.com");
        _loginPositivePage.EnterPassword("jane1234");
        _loginPositivePage.ClickLogin();

        Assert.That(_driver.Url, Does.Contain("https://sit-portal.trackinghub.co.ke/home2"));
    }

    [Test]
    public void TestShowPasswordFeature()
    {
        _loginPositivePage.EnterPassword("jane1234");
        _loginPositivePage.ClickShowPassword();

        Assert.That(_loginPositivePage.PasswordInput.GetAttribute("type"), Is.EqualTo("text"));
    }

    [Test]
    public void TestForgotPasswordRedirect()
    {
        _loginPositivePage.ClickForgotPassword();

        Assert.That(_driver.Url, Does.Contain("https://sit-portal.trackinghub.co.ke/password/reset"));
    }

    [Test]
    public void TestEmailInputValidation()
    {
        _loginPositivePage.EnterEmail("invalid-email");

        Assert.That(IsElementVisible(By.CssSelector(".was-validated")), Is.False,
            "Expected '.was-validated' class to be absent for invalid email input.");
    }

    [Test]
    public void TestPasswordMinimumLength()
    {
        _loginPositivePage.EnterPassword("123");

        Assert.That(IsElementVisible(By.CssSelector(".was-validated")), Is.False,
            "Expected no validation feedback for too-short password.");
    }

    private bool IsElementVisible(By by)
    {
        try
        {
            return _driver.FindElement(by).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
