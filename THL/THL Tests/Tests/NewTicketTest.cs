using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[TestFixture]
public class Tests
{
    private IWebDriver driver;
    private NewTicketPage newTicketPage;
    private WebDriver wait;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        // Use WebDriverWait instead of WebDriver for waiting
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));

        //Navigate to login first
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/");

        // Perform login
        var loginPage = new LoginPage(driver);
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("jane1234");
        loginPage.ClickLoginButton();

        // wait to be redirected to home page
        wait.Until(d => d.Url.Contains("https://sit-portal.trackinghub.co.ke/home2"));

        //raise new ticket
        newTicketPage = new NewTicketPage(driver);
    }

    [Test]
    public void VerifyNavigationToNewTicketPage()
    {
        newTicketPage.ClickNewTicketLink();
        Assert.Equals(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void EnsureLinkIsVisuallyDistinct()
    {
        Assert.That(newTicketPage.NewTicketLink.Displayed, Is.True);
        Assert.That(newTicketPage.NewTicketLink.GetCssValue("cursor").Equals("pointer"), Is.True);
    }

    [Test]
    public void CheckLinkAccessibilityViaKeyboard()
    {
        newTicketPage.NewTicketLink.SendKeys(Keys.Tab);
        Assert.That(newTicketPage.NewTicketLink.Equals(driver.SwitchTo().ActiveElement), Is.True);
    }

    [Test]
    public void ConfirmLinkFunctionalityOnVariousDevices()
    {
        // Simulate mobile device
        var mobileEmulation = new ChromeOptions();
        mobileEmulation.AddArgument("window-size=375,667");
        driver = new ChromeDriver(mobileEmulation);
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/home2");
        newTicketPage = new NewTicketPage(driver);
        newTicketPage.ClickNewTicketLink();
        Assert.Equals(newTicketPage.Url, newTicketPage.GetCurrentUrl());
        driver.Quit();

        // Simulate tablet device
        var tabletEmulation = new ChromeOptions();
        tabletEmulation.AddArgument("window-size=768,1024");
        driver = new ChromeDriver(tabletEmulation);
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/home2");
        newTicketPage = new NewTicketPage(driver);
        newTicketPage.ClickNewTicketLink();
        Assert.Equals(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void ValidateSameTabNavigation()
    {
        newTicketPage.ClickNewTicketLink();
        Assert.Equals(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void TestLinkClickWhenNotLoggedIn()
    {
        // Simulate not logged in by navigating to login page
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/login");
        newTicketPage.ClickNewTicketLink();
        Assert.That(driver.Url.Contains("login"), Is.True);
    }

    [Test]
    public void VerifyLinkDoesNotWorkWithJavaScriptDisabled()
    {
        var options = new ChromeOptions();
        options.AddArgument("--disable-javascript");
        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/home2");
        Assert.Throws<NoSuchElementException>(() => newTicketPage.ClickNewTicketLink());
    }

    [Test]
    public void CheckMalformedUrlBehavior()
    {
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('href', '/newticket');",newTicketPage.NewTicketLink);
        newTicketPage.ClickNewTicketLink();
        Assert.That(newTicketPage.GetCurrentUrl(),
        Is.EqualTo("https://sit-portal.trackinghub.co.ke/newticket"));
    }

    [Test]
    public void EnsureNoErrorPageOnClick()
    {
        newTicketPage.ClickNewTicketLink();
        Assert.That(driver.Url.Contains("404"), Is.False);
    }

    [Test]
    public void ConfirmNoNavigationWithPopupBlocker()
    {
        // Simulate popup blocker
        var options = new ChromeOptions();
        options.AddArgument("--disable-popup-blocking");
        driver = new ChromeDriver(options);
        newTicketPage.ClickNewTicketLink();
        Assert.Equals(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void SimulateSlowInternetConnection()
    {
        // Simulate slow network
        var options = new ChromeOptions();
        options.AddArgument("--throttle-lan=1000");
        driver = new ChromeDriver(options);
        newTicketPage.ClickNewTicketLink();
        Assert.That(driver.Url.Contains("loading"), Is.True);
    }

    [Test]
    public void RapidClicksPerformanceTest()
    {
        for (int i = 0; i < 10; i++)
        {
            newTicketPage.ClickNewTicketLink();
        }
        Assert.Equals(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void TestLinkWithScreenReaders()
    {
        // This would typically require a screen reader simulation (not feasible in Selenium - js is used instead)
        Assert.That(newTicketPage.NewTicketLink.Text.Contains("New Ticket"), Is.True);
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('href', '/newticket');", newTicketPage.NewTicketLink);
    }

    [Test]
    public void CheckBehaviorWithJavaScriptErrors()
    {
        // Fix: Cast driver to IJavaScriptExecutor to use ExecuteScript
        ((IJavaScriptExecutor)driver).ExecuteScript("throw new Error('JavaScript error');");
        Assert.That(newTicketPage.NewTicketLink.Displayed, Is.True);
    }

    [Test]
    public void ValidateResponsiveBehavior()
    {
        driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        newTicketPage.ClickNewTicketLink();
        Assert.Equals(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}

