using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class ExRatesCreativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait wait;

    public ExRatesCreativePage(IWebDriver driver)
    {
        _driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement FromCurrencyDropdown => _driver.FindElement(By.Id("react-select-2-input"));
    public IWebElement ToCurrencyDropdown => _driver.FindElement(By.Id("react-select-3-input"));
    public IWebElement ToDateInput => _driver.FindElement(By.Name("toDate"));
    public IWebElement NotificationCheckbox => _driver.FindElement(By.ClassName("rizzui-checkbox-input"));
    public IWebElement ExchangeRateInput => _driver.FindElement(By.Name("percentage"));
    public IWebElement CancelButton => _driver.FindElement(By.XPath("//button[text()='Cancel']"));
    public IWebElement AddTaxButton => _driver.FindElement(By.XPath("//button[text()='Add Tax']"));

    public void SelectFromCurrency(string currency)
    {
        FromCurrencyDropdown.SendKeys(currency);
        FromCurrencyDropdown.SendKeys(Keys.Enter);
    }

    public void SelectToCurrency(string currency)
    {
        ToCurrencyDropdown.SendKeys(currency);
        ToCurrencyDropdown.SendKeys(Keys.Enter);
    }

    public void CheckNotificationCheckbox()
    {
        NotificationCheckbox.Click();
    }

    public void UncheckNotificationCheckbox()
    {
        NotificationCheckbox.Click();
    }

    public void EnterExchangeRate(string rate)
    {
        ExchangeRateInput.Clear();
        ExchangeRateInput.SendKeys(rate);
    }

    public void ClickCancelButton()
    {
        CancelButton.Click();
    }
}