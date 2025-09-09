using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class LoginPositiveTests 
{
    private LoginPositivePage loginPage;
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

    [Test]
    public void Test_Login_RedirectsToOTPPage()
    {
        // Step 1: Fill in valid credentials
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("RJane@321");

        // Step 2: Click Login
        loginPage.ClickLogin();
    }

}
