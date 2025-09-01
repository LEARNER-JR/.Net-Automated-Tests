using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginCreativePage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginCreativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement EmailInput => wait.Until(d => d.FindElement(By.Id("email")));
    public IWebElement PasswordInput => wait.Until(d => d.FindElement(By.Id("password")));
    public IWebElement LoginButton => wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));
    public IWebElement ForgotPasswordLink => wait.Until(d => d.FindElement(By.CssSelector("a.btn.btn-link")));

    public void EnterEmail(string email)
    {
        EmailInput.Clear();
        EmailInput.SendKeys(email);
    }

    public void EnterPassword(string password)
    {
        PasswordInput.Clear();
        PasswordInput.SendKeys(password);
    }

    public void ClickLogin()
    {
        LoginButton.Click();
    }
}
