using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;


[TestFixture]
public class LoginCreativeTest
{
    private IWebDriver _driver;
    private LoginCreativePage _loginPage;
    private const string BaseUrl = "https://sitwebapp.upesimts.com/login?country=/login";

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(BaseUrl);
        _loginPage = new LoginCreativePage(_driver);
    }

    [Test]
    public void TestLoginLinkFunctionalityOnMobile()
    {
        // Simulate mobile device
        var mobileEmulation = new ChromeOptions();
        mobileEmulation.AddAdditionalCapability("deviceName", "Nexus 5");
        _driver = new ChromeDriver(mobileEmulation);

        _driver.Navigate().GoToUrl(BaseUrl);
        _loginPage.ClickLoginButton();

        Assert.AreEqual("/login?country=/login", _driver.Url);
    }

    [Test]
    public void TestLoginLinkAfterSessionTimeout()
    {
        // Simulating session timeout
        _driver.Manage().Cookies.DeleteAllCookies();
        _driver.Navigate().GoToUrl(BaseUrl);
        _loginPage.ClickLoginButton();

        Assert.IsTrue(_driver.Url.Contains("/login?country=/login"));
        // Add assertion for session expiration message if applicable
    }

    [Test]
    public void TestLoginLinkAccessibilityWithScreenReader()
    {
        // This test would typically require a screen reader tool integration
        // Here we just check the link's accessibility properties
        var isAriaLabelPresent = _loginPage.LoginButton.GetAttribute("aria-label") != null;
        Assert.IsTrue(isAriaLabelPresent, "Login link should be accessible via screen reader.");
    }

    [Test]
    public void TestLoginLinkZoomLevelImpact()
    {
        // Change browser zoom level
        _driver.ExecuteScript("document.body.style.zoom='150%'");
        Assert.IsTrue(_loginPage.LoginButton.Displayed);
    }

    [Test]
    public void TestLoginLinkWithDifferentUserRoles()
    {
        // Simulate different user roles by changing the session or cookies
        // This is a placeholder for actual role-based testing
        string[] userRoles = { "admin", "guest" };
        foreach (var role in userRoles)
        {
            // Set user role in cookies or session
            // ...

            _driver.Navigate().GoToUrl(BaseUrl);
            Assert.IsTrue(_loginPage.LoginButton.Displayed, $"{role} role: Login button should be visible.");
        }
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}