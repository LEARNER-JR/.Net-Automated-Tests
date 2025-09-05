using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

public class PageObjectModel
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);

    // Replace these with the actual selectors used in your app.
    // The order is important: the class will try them in sequence.
    private readonly By[] _sendMoneyLocators = new By[]
    {
        By.CssSelector("a.send-money-link"),          // example CSS class selector
        By.LinkText("Send Money"),                    // link text fallback
        By.CssSelector("a[href*='money-transfer']")   // href-based fallback
    };

    public PageObjectModel(IWebDriver driver, TimeSpan? timeout = null)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _wait = new WebDriverWait(_driver, timeout ?? _timeout);
    }

    // Generic wait-for-visible helper (no SeleniumExtras)
    private IWebElement WaitVisible(By by)
    {
        return _wait.Until(d =>
        {
            try
            {
                var el = d.FindElement(by);
                return el != null && el.Displayed ? el : null;
            }
            catch (NoSuchElementException) { return null; }
            catch (StaleElementReferenceException) { return null; }
        });
    }

    // Public property that will try multiple locators and return the first visible element
    public IWebElement SendMoneyLink
    {
        get
        {
            foreach (var loc in _sendMoneyLocators)
            {
                try
                {
                    var el = WaitVisible(loc);
                    if (el != null) return el;
                }
                catch (WebDriverTimeoutException) { /* try next locator */ }
            }

            // If none matched, throw with helpful info
            throw new NoSuchElementException($"Send Money link not found. Tried locators: {string.Join(", ", Array.ConvertAll(_sendMoneyLocators, loc => loc.ToString()))}");
        }
    }

    public void HoverOverSendMoneyLink()
    {
        var el = SendMoneyLink;
        var actions = new Actions(_driver);
        actions.MoveToElement(el).Perform();
    }

    public void ClickSendMoneyLink()
    {
        var el = SendMoneyLink;
        // Wait the element to be enabled and clickable-ish
        _wait.Until(d => el.Displayed && el.Enabled);
        el.Click();
    }

    // Returns a small summary of computed style (color, font-size, decoration) + class/style attributes
    public string GetLinkStyle()
    {
        var el = SendMoneyLink;
        try
        {
            var js = (IJavaScriptExecutor)_driver;
            var color = js.ExecuteScript("return window.getComputedStyle(arguments[0]).getPropertyValue('color');", el) as string;
            var fontSize = js.ExecuteScript("return window.getComputedStyle(arguments[0]).getPropertyValue('font-size');", el) as string;
            var textDecoration = js.ExecuteScript("return window.getComputedStyle(arguments[0]).getPropertyValue('text-decoration');", el) as string;
            var fontWeight = js.ExecuteScript("return window.getComputedStyle(arguments[0]).getPropertyValue('font-weight');", el) as string;

            return $"color:{color}; font-size:{fontSize}; text-decoration:{textDecoration}; font-weight:{fontWeight}; class:{el.GetAttribute("class")}; styleAttr:{el.GetAttribute("style")}";
        }
        catch
        {
            // Fallback to attributes if JS call fails
            return el.GetAttribute("style") ?? el.GetAttribute("class") ?? string.Empty;
        }
    }
}
