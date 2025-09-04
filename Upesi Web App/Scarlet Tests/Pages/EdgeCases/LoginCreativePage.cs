using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

public class LoginCreativePage
{
    private readonly IWebDriver _driver;

    public LoginCreativePage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(driver, this);
    }

    public IWebElement LoginButton => _driver.FindElement(By.ClassName("Header_loginBtn__2+Lso"));

    public void ClickLoginButton()
    {
        LoginButton.Click();
    }
}