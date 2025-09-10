using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class ExRatesNegativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public ExRatesNegativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement FromCurrencyInput => _wait.Until(d => d.FindElement(By.Id("react-select-5-input")));
    public IWebElement ToCurrencyInput => _wait.Until(d => d.FindElement(By.Id("react-select-6-input")));
    public IWebElement OperatingCountryInput => _wait.Until(d => d.FindElement(By.Id("react-select-7-input")));
    public IWebElement RateInput => _wait.Until(d => d.FindElement(By.Name("rate")));
    public IWebElement AddExchangeRateButton => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Add Exchange Rate']")));
    public IWebElement NotificationCheckbox => _wait.Until(d => d.FindElement(By.ClassName("rizzui-checkbox-input")));
    public IWebElement ErrorMessage => _wait.Until(d => d.FindElement(By.CssSelector(".error-message-selector"))); // Update with actual error message selector

    public void EnterFromCurrency(string currency)
    {
        FromCurrencyInput.SendKeys(currency);
    }

    public void EnterToCurrency(string currency)
    {
        ToCurrencyInput.SendKeys(currency);
    }

    public void EnterOperatingCountry(string country)
    {
        OperatingCountryInput.SendKeys(country);
    }

    public void EnterRate(string rate)
    {
        RateInput.Clear();
        RateInput.SendKeys(rate);
    }

    public void ClickAddExchangeRate()
    {
        AddExchangeRateButton.Click();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }

    internal void NavigateToExchangeRatePage()
    {
        throw new NotImplementedException();
    }

    internal void WaitForPageLoad()
    {
        throw new NotImplementedException();
    }
}