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
         var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.PageLoadStrategy = PageLoadStrategy.Eager;

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/login");

        loginPage = new LoginPositivePage(driver);

        await loginPage.LoginWithOtpAsync(
            "janerose.muthoni@ngaocredit.com",
            "RJane@321"
        );
    }


    //[TearDown]
    //public abstract void TearDown();


        }