//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//[TestFixture]
//public class LoginNegativeTests
//{
//    private IWebDriver driver;
//    private LoginNegativePage loginPage;

//    [SetUp]
//    public void Setup()
//    {
//        driver = new ChromeDriver();
//        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/login?unauthorized");
//        loginPage = new LoginNegativePage(driver);
//    }

//    [TearDown]
//    public void TearDown()
//    {
//        driver.Quit();
//    }

//    [Test]
//    public void Test_InvalidEmailFormat()
//    {
//        loginPage.EnterEmail("invalidEmailFormat");
//        loginPage.EnterPassword("ValidPassword1!");
//        loginPage.EnterOTP("123456");
//        loginPage.SubmitForm();

//        Assert.That(loginPage.ErrorText.Displayed, Is.True);
//        Assert.That(loginPage.ErrorText.Text, Does.Contain("valid email").IgnoreCase);
//    }

//    [Test]
//    public void Test_WeakPassword()
//    {
//        loginPage.EnterEmail("test@example.com");
//        loginPage.EnterPassword("short");
//        loginPage.EnterOTP("123456");
//        loginPage.SubmitForm();

//        Assert.That(loginPage.ErrorText.Displayed, Is.True);
//        Assert.That(loginPage.ErrorText.Text, Does.Contain("Password").And.Contain("8").IgnoreCase);
//    }

//    [Test]
//    public void Test_WrongOTP()
//    {
//        loginPage.EnterEmail("test@example.com");
//        loginPage.EnterPassword("ValidPassword1!");
//        loginPage.EnterOTP("wrongOTP");
//        loginPage.SubmitForm();

//        Assert.That(loginPage.ErrorText.Displayed, Is.True);
//        Assert.That(loginPage.ErrorText.Text, Does.Contain("OTP").And.Contain("incorrect").IgnoreCase);
//    }

//    [Test]
//    public void Test_EmptyFields()
//    {
//        loginPage.EnterEmail("");
//        loginPage.EnterPassword("");
//        loginPage.EnterOTP("");
//        loginPage.SubmitForm();

//        Assert.That(loginPage.ErrorText.Displayed, Is.True);
//        Assert.That(loginPage.ErrorText.Text, Does.Contain("All fields").IgnoreCase);
//    }

//    [Test]
//    public void Test_ExcessivelyLongEmail()
//    {
//        string longEmail = new string('a', 256) + "@example.com";
//        loginPage.EnterEmail(longEmail);
//        loginPage.EnterPassword("ValidPassword1!");
//        loginPage.EnterOTP("123456");
//        loginPage.SubmitForm();

//        Assert.That(loginPage.ErrorText.Displayed, Is.True);
//        Assert.That(loginPage.ErrorText.Text, Does.Contain("too long").IgnoreCase);
//    }
//}

