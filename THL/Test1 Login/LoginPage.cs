using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement EmailInput => wait.Until(d => d.FindElement(By.Id("email")));
    public IWebElement PasswordInput => wait.Until(d => d.FindElement(By.Id("password")));
    public IWebElement ShowPasswordCheckbox => wait.Until(d => d.FindElement(By.XPath("//input[@type='checkbox']")));
    public IWebElement LoginButton => wait.Until(d => d.FindElement(By.CssSelector(".button")));
    public IWebElement ForgotPasswordLink => wait.Until(d => d.FindElement(By.CssSelector(".btn.btn-link")));
    public IWebElement ErrorMessage => wait.Until(d => d.FindElement(By.CssSelector(".alert.alert-danger"))); // Adjust selector as necessary

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

    public void ClickLoginButton()
    {
        LoginButton.Click();
    }

    public void ClickForgotPassword()
    {
        ForgotPasswordLink.Click();
    }
}