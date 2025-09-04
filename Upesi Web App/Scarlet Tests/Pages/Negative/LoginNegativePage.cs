using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginNegativePage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginNegativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public By LoginButton => By.ClassName("Header_loginBtn__2+Lso");

    public void ClickLoginButton()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton)).Click();
    }
}