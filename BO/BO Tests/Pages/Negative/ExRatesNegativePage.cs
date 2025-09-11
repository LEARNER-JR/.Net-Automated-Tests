using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class ExRatesNegativePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public ExRatesNegativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement FromCurrencyInput => wait.Until(d => d.FindElement(By.Id("react-select-5-input")));
    public IWebElement ToCurrencyInput => wait.Until(d => d.FindElement(By.Id("react-select-6-input")));
    public IWebElement ToDateInput => wait.Until(d => d.FindElement(By.CssSelector("input[placeholder='Select Date']")));
    public IWebElement OperatingCountryInput => wait.Until(d => d.FindElement(By.Id("react-select-7-input")));
    public IWebElement ExchangeRateInput => wait.Until(d => d.FindElement(By.Name("rate")));
    public IWebElement ActivateNotificationCheckbox => wait.Until(d => d.FindElement(By.CssSelector("input[type='checkbox']")));
    public IWebElement SubmitButton => wait.Until(d => d.FindElement(By.XPath("//button[contains(text(), 'Add Exchange Rate')]")));
    public IWebElement CancelButton => wait.Until(d => d.FindElement(By.XPath("//button[contains(text(), 'Cancel')]")));

    public void SetFromCurrency(string currency)
    {
        FromCurrencyInput.SendKeys(currency);
        FromCurrencyInput.SendKeys(Keys.Enter);
    }

    public void SetToCurrency(string currency)
    {
        ToCurrencyInput.SendKeys(currency);
        ToCurrencyInput.SendKeys(Keys.Enter);
    }

    public void SetToDate(string date)
    {
        ToDateInput.Clear();
        ToDateInput.SendKeys(date);
    }

    public void SetOperatingCountry(string country)
    {
        OperatingCountryInput.SendKeys(country);
        OperatingCountryInput.SendKeys(Keys.Enter);
    }

    public void SetExchangeRate(string rate)
    {
        ExchangeRateInput.Clear();
        ExchangeRateInput.SendKeys(rate);
    }

    public void ClickSubmit()
    {
        SubmitButton.Click();
    }

    public void ClickCancel()
    {
        CancelButton.Click();
    }

    public bool IsErrorMessageDisplayed()
    {
        return driver.FindElements(By.ClassName("error-message")).Count > 0; // Adjust selector based on actual error message implementation
    }

    internal void WaitForPageLoad()
    {
        throw new NotImplementedException();
    }

    internal void NavigateToExchangeRatePage()
    {
        throw new NotImplementedException();
    }
}