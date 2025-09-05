using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;

public abstract class BaseTest
{
    protected IWebDriver driver;
    protected LoginPositivePage loginPage;

    [SetUp]
    public async Task SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/login");

        loginPage = new LoginPositivePage(driver);

        await loginPage.LoginWithOtpAsync(
            "janerose.muthoni@ngaocredit.com",
            "RJane@321"
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}