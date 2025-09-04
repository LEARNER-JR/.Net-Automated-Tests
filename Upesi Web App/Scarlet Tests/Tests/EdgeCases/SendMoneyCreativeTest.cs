using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

using System;

[TestFixture]
public class SendMoneyCreativeTest
{
    private IWebDriver driver;
    private PageObjectModel page;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/money-transfer");
        page = new PageObjectModel(driver);
    }

    [Test]
    public void Test_HoverOverLink_ShowsTooltip()
    {
        page.HoverOverSendMoneyLink();
        // Add assertion to check if tooltip is displayed
        // Example: Assert.IsTrue(driver.FindElement(By.ClassName("tooltip-class")).Displayed);
    }

    [TestCase(1920, 1080)]
    [TestCase(1366, 768)]
    [TestCase(1280, 720)]
    public void Test_LinkIsClickable(int width, int height)
    {
        driver.Manage().Window.Size = new System.Drawing.Size(width, height);
        Assert.IsTrue(page.SendMoneyLink.Displayed);
        Assert.IsTrue(page.SendMoneyLink.Enabled);
    }

    [Test]
    public void Test_LinkStyleConsistency()
    {
        string linkStyle = page.GetLinkStyle();
        // Add assertion to compare with other link styles
        // Example: Assert.AreEqual(linkStyle, "expected-style");
    }

    [Test]
    public void Test_ClickLinkRapidly_NoErrors()
    {
        for (int i = 0; i < 10; i++)
        {
            page.ClickSendMoneyLink();
        }
        // Add assertion to check for errors or page stability
        // Example: Assert.IsFalse(driver.PageSource.Contains("Error"));
    }

    [Test]
    public void Test_BrowserZoomImpact()
    {
        driver.ExecuteScript("document.body.style.zoom='150%'");
        Assert.IsTrue(page.SendMoneyLink.Displayed);
        // Add additional assertions as needed
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}