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

    public IWebElement UsernameField => wait.Until(d => d.FindElement(By.Id("login")));
    public IWebElement PasswordField => wait.Until(d => d.FindElement(By.Id("password")));
    public IWebElement SubmitButton => wait.Until(d => d.FindElement(By.CssSelector("input[type='submit']")));
    public IWebElement ForgotPasswordButton => wait.Until(d => d.FindElement(By.ClassName("reset-password-button")));
    public IWebElement ErrorMessage => wait.Until(d => d.FindElement(By.Id("error_div")));
    public IWebElement SuccessMessage => wait.Until(d => d.FindElement(By.Id("success")));
    public IWebElement ResetForm => wait.Until(d => d.FindElement(By.Id("reset-form")));
    public IWebElement EmailField => wait.Until(d => d.FindElement(By.Id("email")));

    public void EnterUsername(string username)
    {
        UsernameField.Clear();
        UsernameField.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        PasswordField.Clear();
        PasswordField.SendKeys(password);
    }

    public void ClickSubmit()
    {
        SubmitButton.Click();
    }

    public void ClickForgotPassword()
    {
        ForgotPasswordButton.Click();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }

    public string GetSuccessMessage()
    {
        return SuccessMessage.Text;
    }

    public void EnterEmail(string email)
    {
        EmailField.Clear();
        EmailField.SendKeys(email);
    }
}