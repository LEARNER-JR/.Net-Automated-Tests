using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class LoginPositiveTests
{
    private IWebDriver driver;
    private LoginPositivePage loginPage;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/auth/login");
        loginPage = new LoginPositivePage(driver);
    }

    [Test]
    public void Test_ValidEmail_AllowsLogin()
    {
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        Assert.That(loginPage.EmailInput.GetAttribute("value"), Is.EqualTo("janerose.muthoni@ngaocredit.com"));
    }

    [Test]
    public void Test_ValidPassword_AllowsLogin()
    {
        loginPage.EnterPassword("RJane@321");
        Assert.That(loginPage.PasswordInput.GetAttribute("value"), Is.EqualTo("RJane@321"));
    }

    [Test]
    public void Test_ForgotPassword_LinkIsVisibleAndClickable()
    {
        Assert.That(loginPage.ForgotPasswordLink.Displayed, Is.True);
        loginPage.ClickForgotPassword();
        Assert.That(driver.Url, Is.EqualTo("https://sit-ui.upesimts.com/auth/forgot-password"));
    }

    [Test]
    public void Test_LoginButton_Enabled_WhenFieldsAreFilled()
    {
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("RJane@321");
        Assert.That(loginPage.IsLoginButtonEnabled(), Is.True);
    }

    [Test]
    public void Test_InputFields_DisplayCorrectPlaceholderText()
    {
        Assert.That(loginPage.GetEmailPlaceholder(), Is.EqualTo("Enter your email"));
        Assert.That(loginPage.GetPasswordPlaceholder(), Is.EqualTo("Enter your password"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
