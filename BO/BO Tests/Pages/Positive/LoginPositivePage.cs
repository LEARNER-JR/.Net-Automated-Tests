using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPositivePage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPositivePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement EmailInput => wait.Until(d => d.FindElement(By.Name("email")));
    public IWebElement PasswordInput => wait.Until(d => d.FindElement(By.Name("password")));
    public IWebElement ForgotPasswordLink => wait.Until(d => d.FindElement(By.LinkText("Forgot Password?")));
    public IWebElement LoginButton => wait.Until(d => d.FindElement(By.XPath("//button[text()='Login']")));

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

    public void ClickForgotPassword()
    {
        ForgotPasswordLink.Click();
    }

    public void ClickLogin()
    {
        LoginButton.Click();
    }

    public bool IsLoginButtonEnabled()
    {
        return LoginButton.Enabled;
    }

    public string GetEmailPlaceholder()
    {
        return EmailInput.GetAttribute("placeholder");
    }

    public string GetPasswordPlaceholder()
    {
        return PasswordInput.GetAttribute("placeholder");
    }
}