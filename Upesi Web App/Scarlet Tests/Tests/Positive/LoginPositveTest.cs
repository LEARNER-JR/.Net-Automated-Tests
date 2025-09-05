using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class LoginPositiveTest : BaseTest
{
    [Test]
    public async Task TestUserIsRedirectedToDashboard()
    {
        // BaseTest already logged in, so just check URL
        Assert.That(driver.Url, Does.Contain("dashboard"),
            "User was not redirected to dashboard after login.");
    }

    [Test]
    public async Task TestNavigationMenuIsVisible()
    {
        var navMenu = driver.FindElement(By.Id("main-nav"));
        Assert.That(navMenu.Displayed, Is.True,
            "Navigation menu should be visible after login.");
    }

    [Test]
    public async Task TestLogoutButtonIsPresent()
    {
        var logoutBtn = driver.FindElement(By.CssSelector(".logout-btn"));
        Assert.That(logoutBtn.Displayed, Is.True,
            "Logout button should be visible after login.");
    }

    //public override void TearDown()
    //{
    //    driver.Quit();
    //}
}