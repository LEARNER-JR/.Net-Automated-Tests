using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPositivePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private Wait<WebDriver> wait = new FluentWait<>(driver)

    public LoginPositivePage(IWebDriver driver)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement ContinueOrLoginButton => _wait.Until(d =>
    {
        try
        {
            var e = d.FindElement(By.ClassName("reset-btn-submit"));
            return (e != null && e.Displayed) ? e : null;
        }
        catch (NoSuchElementException) { return null; }
        catch (StaleElementReferenceException) { return null; }
    });

    private IWebElement EmailInput => _wait.Until(d => d.FindElement(By.Name("email")));
    private IWebElement PasswordInput => _wait.Until(d => d.FindElement(By.Name("password")));
    private IWebElement OTPInput => _wait.Until(d => d.FindElement(By.Name("OTP")));

    // Extract OTP text dynamically
    public async Task<string> GetOTPAsync()
    {
        return await Task.Run(() =>
        {
            var otpHeader = _wait.Until(d => d.FindElement(By.XPath("//h4[contains(text(),'TEST OTP:')]")));
            string fullText = otpHeader.Text;   // e.g. "TEST OTP: LGSTUJ"
            return Regex.Replace(fullText, @"TEST OTP:\s*", ""); // returns just "LGSTUJ"
        });
    }

    // Actions
    public async Task EnterEmailAsync(string email)
    {
        await Task.Run(() =>
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);
        });
    }

    public async Task EnterPasswordAsync(string password)
    {
        await Task.Run(() =>
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        });
    }

    public async Task ClickContinueAsync()
    {
        await Task.Run(() => ContinueOrLoginButton.Click());
    }

    public async Task EnterOTPAsync(string otp)
    {
        await Task.Run(() =>
        {
            OTPInput.Clear();
            OTPInput.SendKeys(otp);
        });
    }

    public async Task ClickLoginAsync()
    {
        await Task.Run(() => ContinueOrLoginButton.Click());
    }

    // Full login helper
    public async Task LoginWithOtpAsync(string email, string password)
    {
        await EnterEmailAsync(email);
        await EnterPasswordAsync(password);
        await ClickContinueAsync();
        _wait.Until(d => d.FindElement(By.Name("otp")));

        string otp = await GetOTPAsync();
        await EnterOTPAsync(otp);

        await ClickLoginAsync();
    }
}