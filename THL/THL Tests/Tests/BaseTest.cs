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
}

