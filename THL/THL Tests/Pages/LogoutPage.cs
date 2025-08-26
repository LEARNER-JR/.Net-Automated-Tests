using NUnit.Framework;
using OpenQA.Selenium;

public class LogoutPage
{
    private readonly IWebDriver driver;

    public LogoutPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public string LogoutLink => "a.dropdown-item";

    public void ClickLogout()
    {
        driver.FindElement(By.Id("logout-form")).Click();
    }
}
