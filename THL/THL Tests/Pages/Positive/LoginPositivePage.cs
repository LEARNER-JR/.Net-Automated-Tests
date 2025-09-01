using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPositivePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPositivePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement EmailInput => _wait.Until(d => d.FindElement(By.Id("email")));
    public IWebElement PasswordInput => _wait.Until(d => d.FindElement(By.Id("password")));
    public IWebElement ShowPasswordCheckbox => _wait.Until(d => d.FindElement(By.XPath("//input[@type='checkbox']")));
    public IWebElement LoginButton => _wait.Until(d => d.FindElement(By.CssSelector(".button")));
    public IWebElement ForgotPasswordLink => _wait.Until(d => d.FindElement(By.CssSelector("a.btn.btn-link")));

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

    public void ClickShowPassword()
    {
        ShowPasswordCheckbox.Click();
    }

    public void ClickLogin()
    {
        LoginButton.Click();
    }

    public void ClickForgotPassword()
    {
        ForgotPasswordLink.Click();
    }
}
