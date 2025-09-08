using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LoginPage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement EmailInput => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("email")));
    private IWebElement PasswordInput => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("password")));
    private IWebElement LoginButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@type='submit']")));
    private IWebElement ForgotPasswordLink => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Forgot Password?")));
    private IWebElement ErrorMessage => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("error-message"))); // Update selector based on actual error message class

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

    public void ClickLoginButton()
    {
        LoginButton.Click();
    }

    public void ClickForgotPassword()
    {
        ForgotPasswordLink.Click();
    }

    public bool IsLoginButtonEnabled()
    {
        return LoginButton.Enabled;
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }
}
