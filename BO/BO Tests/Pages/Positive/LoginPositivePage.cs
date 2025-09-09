using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPositivePage
{
    private readonly IWebDriver _driver;
    private WebDriverWait wait;
    private readonly By _otpButton = By.XPath("/html/body/div[2]/div/div/form/div/button[2]");

    public LoginPositivePage(IWebDriver driver)
    {
        _driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }
    public IWebElement EmailInput => wait.Until(d => d.FindElement(By.Name("email")));
    public IWebElement PasswordInput => wait.Until(d => d.FindElement(By.Name("password")));
    public IWebElement ForgotPasswordLink => wait.Until(d => d.FindElement(By.LinkText("Forgot Password?")));
    public IWebElement LoginButton => wait.Until(d => d.FindElement(By.XPath("//button[text()='Login']")));

    public void PerformPositiveLogin()
    {

        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/auth/login");
        var email = "janerose.muthoni@ngaocredit.com";
        var password = "RJane@321";

        EnterEmail(email);
        EnterPassword(password);
        ClickLogin();
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((_otpButton)));
        _driver.FindElement(_otpButton).Click();
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://sit-ui.upesimts.com/"));

        //  wait.Until(d => d.Url.Contains("https://sit-ui.upesimts.com/"));
    }

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

    //internal void ClickAddTariffButton()
    //{
    //    throw new NotImplementedException();
    //}
}