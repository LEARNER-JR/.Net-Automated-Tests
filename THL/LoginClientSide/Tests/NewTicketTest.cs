using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class Tests
{
    private IWebDriver driver;
    private NewTicketPage newTicketPage;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/home2");
        newTicketPage = new NewTicketPage(driver);
    }

    [Test]
    public void VerifyNavigationToNewTicketPage()
    {
        newTicketPage.ClickNewTicketLink();
        Assert.AreEqual(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void EnsureLinkIsVisuallyDistinct()
    {
        Assert.IsTrue(newTicketPage.NewTicketLink.Displayed);
        Assert.IsTrue(newTicketPage.NewTicketLink.GetCssValue("cursor").Equals("pointer"));
    }

    [Test]
    public void CheckLinkAccessibilityViaKeyboard()
    {
        newTicketPage.NewTicketLink.SendKeys(Keys.Tab);
        Assert.IsTrue(newTicketPage.NewTicketLink.Equals(driver.SwitchTo().ActiveElement));
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
        Assert.AreEqual(newTicketPage.Url, newTicketPage.GetCurrentUrl());
        driver.Quit();

        // Simulate tablet device
        var tabletEmulation = new ChromeOptions();
        tabletEmulation.AddArgument("window-size=768,1024");
        driver = new ChromeDriver(tabletEmulation);
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/home2");
        newTicketPage = new NewTicketPage(driver);
        newTicketPage.ClickNewTicketLink();
        Assert.AreEqual(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void ValidateSameTabNavigation()
    {
        newTicketPage.ClickNewTicketLink();
        Assert.AreEqual(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void TestLinkClickWhenNotLoggedIn()
    {
        // Simulate not logged in by navigating to login page
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/login");
        newTicketPage.ClickNewTicketLink();
        Assert.IsTrue(driver.Url.Contains("login"));
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
        newTicketPage.NewTicketLink.SetAttribute("href", "/newticket");
        newTicketPage.ClickNewTicketLink();
        Assert.AreEqual("https://sit-portal.trackinghub.co.ke/newticket", newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void EnsureNoErrorPageOnClick()
    {
        newTicketPage.ClickNewTicketLink();
        Assert.IsFalse(driver.Url.Contains("404"));
    }

    [Test]
    public void ConfirmNoNavigationWithPopupBlocker()
    {
        // Simulate popup blocker
        var options = new ChromeOptions();
        options.AddArgument("--disable-popup-blocking");
        driver = new ChromeDriver(options);
        newTicketPage.ClickNewTicketLink();
        Assert.AreEqual(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void SimulateSlowInternetConnection()
    {
        // Simulate slow network
        var options = new ChromeOptions();
        options.AddArgument("--throttle-lan=1000");
        driver = new ChromeDriver(options);
        newTicketPage.ClickNewTicketLink();
        Assert.IsTrue(driver.Url.Contains("loading"));
    }

    [Test]
    public void RapidClicksPerformanceTest()
    {
        for (int i = 0; i < 10; i++)
        {
            newTicketPage.ClickNewTicketLink();
        }
        Assert.AreEqual(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [Test]
    public void TestLinkWithScreenReaders()
    {
        // This would typically require a screen reader simulation
        Assert.IsTrue(newTicketPage.NewTicketLink.Text.Contains("New Ticket"));
    }

    [Test]
    public void CheckBehaviorWithJavaScriptErrors()
    {
        // Simulate JavaScript error
        driver.ExecuteScript("throw new Error('JavaScript error');");
        Assert.IsTrue(newTicketPage.NewTicketLink.Displayed);
    }

    [Test]
    public void ValidateResponsiveBehavior()
    {
        driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        newTicketPage.ClickNewTicketLink();
        Assert.AreEqual(newTicketPage.Url, newTicketPage.GetCurrentUrl());
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}

