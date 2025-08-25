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
public abstract class BaseTest
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    protected LoginPage loginPage;

    [SetUp]
    public virtual void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/login");

        loginPage = new LoginPage(driver);
        PerformLogin();
    }

    private void PerformLogin()
    {
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("jane1234");
        loginPage.ClickLoginButton();

        Assert.That(driver.Url.Contains("https://sit-portal.trackinghub.co.ke/home2"), Is.True);
    }

    [TearDown]
    public virtual void TearDown()
    {
        driver.Quit();
    }

    protected void EnterText(IWebElement element, string value)
    {
        element.Clear();
        element.SendKeys(value);
    }

    protected void ClickElement(IWebElement element)
    {
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        element.Click();
    }

    protected void SelectDropdownByValue(IWebElement element, string value)
    {
        var select = new SelectElement(element);
        select.SelectByValue(value);
    }

    protected void WaitForElementVisible(By locator, int timeoutSeconds = 10)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }
}

