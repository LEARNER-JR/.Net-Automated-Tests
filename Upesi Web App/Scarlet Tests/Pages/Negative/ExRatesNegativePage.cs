using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public class ExRatesNegativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    // Locators
    private readonly By inputField = By.Id("react-select-9-input");
    private readonly By placeholder = By.Id("react-select-9-placeholder");

    public ExRatesNegativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Generic "visible element" waiter (no SeleniumExtras)
    private IWebElement WaitVisible(By by) =>
        _wait.Until(d =>
        {
            try
            {
                var e = d.FindElement(by);
                return e.Displayed ? e : null;
            }
            catch (NoSuchElementException) { return null; }
            catch (StaleElementReferenceException) { return null; }
        });

    public void EnterText(string text)
    {
        var el = WaitVisible(inputField);
        // Clear safely (React inputs sometimes ignore Clear())
        el.Clear();
        el.SendKeys(Keys.Control + "a");
        el.SendKeys(Keys.Delete);
        el.SendKeys(text);
    }

    public string GetInputValue()
    {
        var el = WaitVisible(inputField);
        return el.GetAttribute("value") ?? string.Empty;
    }

    public void ClearInput()
    {
        var el = WaitVisible(inputField);
        el.Clear();
        el.SendKeys(Keys.Control + "a");
        el.SendKeys(Keys.Delete);
    }

    public string GetPlaceholderText()
    {
        var ph = WaitVisible(placeholder);
        return ph.Text;
    }
}
