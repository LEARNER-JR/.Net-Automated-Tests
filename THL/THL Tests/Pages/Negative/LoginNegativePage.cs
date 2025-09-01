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

    public IWebElement EmailInput => wait.Until(d => d.FindElement(By.Id("email")));
    public IWebElement PasswordInput => wait.Until(d => d.FindElement(By.Id("password")));
    public IWebElement ShowPasswordCheckbox => wait.Until(d => d.FindElement(By.XPath("//input[@type='checkbox']")));
    public IWebElement SubmitButton => wait.Until(d => d.FindElement(By.XPath("//button[@type='submit']")));
    public IWebElement ErrorMessage => wait.Until(d => d.FindElement(By.CssSelector(".invalid-feedback"))); // Adjust selector as necessary

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

    public void ClickSubmit()
    {
        SubmitButton.Click();
    }

    public void ToggleShowPassword()
    {
        ShowPasswordCheckbox.Click();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }
}

