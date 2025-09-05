using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class SendMoneyNegativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public SendMoneyNegativePage(IWebDriver driver)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public By SendMoneyLink => By.XPath("//a[contains(text(),'Send Money')]");

    public void ClickSendMoneyLink()
    {
        var el = _wait.Until(d =>
        {
            try
            {
                var e = d.FindElement(SendMoneyLink);
                return (e != null && e.Displayed && e.Enabled) ? e : null;
            }
            catch (NoSuchElementException) { return null; }
            catch (StaleElementReferenceException) { return null; }
        });

        // ensure it is visible in viewport (helps with some flaky clicks)
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", el);

        el.Click();
    }
}
