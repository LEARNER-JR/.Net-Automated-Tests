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
    protected string baseUrl = "https://sit-portal.trackinghub.co.ke/";

    [SetUp]
    public async Task Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("log-level=3");
        driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(baseUrl);

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
        loginPage = new LoginPage(driver);

        // Perform login automatically before each test
        loginPage.EnterEmail("janerose.muthoni@ngaocredit.com");
        loginPage.EnterPassword("jane1234");
        loginPage.ClickLoginButton();

        // Async wait for dashboard to load
        await loginPage.WaitForElementAsync(By.CssSelector("body > div.wrapper"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
