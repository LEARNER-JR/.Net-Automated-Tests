using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TaxesNegativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public TaxesNegativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    public IWebElement AddTaxButton =>
    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(., 'Tax')]")));
    private IWebElement CountryDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("react-select-2-input")));
    private IWebElement ServiceTypeDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("react-select-3-input")));
    private IWebElement TaxPercentageInput => _driver.FindElement(By.Name("percentage"));
    //private IWebElement AddTaxButton => _driver.FindElement(By.XPath("//button[text()='Add Tax']"));
    private IWebElement NotificationCheckbox => _driver.FindElement(By.XPath("//input[@type='checkbox']"));
    public void ClickNewTaxButton()
    {
        AddTaxButton.Click();
        WaitForFormLoad();
    }
    public void WaitForPageLoad()
    {
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/taxes");
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/taxes"));
    }

    public void SelectCountry(string country)
    {
        CountryDropdown.Click();
        CountryDropdown.SendKeys(country);
        CountryDropdown.SendKeys(Keys.Enter);
    }

    public void SelectServiceType(string serviceType)
    {
        ServiceTypeDropdown.Click();
        ServiceTypeDropdown.SendKeys(serviceType);
        ServiceTypeDropdown.SendKeys(Keys.Enter);
    }

    public void EnterTaxPercentage(string percentage)
    {
        TaxPercentageInput.Clear();
        TaxPercentageInput.SendKeys(percentage);
    }

    public void CheckNotificationCheckbox()
    {
        if (!NotificationCheckbox.Selected)
        {
            NotificationCheckbox.Click();
        }
    }

    public void NavigateToTaxesNegativePage()
    {
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/taxes");
        WaitForPageLoad();
    }


    private void WaitForFormLoad()
    {
        _wait.Until(d => d.FindElement(By.Name("percentage")).Displayed);
    }

    public void SubmitForm()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated( //exception
            By.CssSelector(".rizzui-modal-overlay")));

        AddTaxButton.Click();
    }

    public string GetTaxPercentageError()
    {
        return _driver.FindElement(By.XPath("//div[@role='alert' and contains(text(),'Required')][1]")).Text;
    }

    public string GetServiceTypeError()
    {
        return _driver.FindElement(By.XPath("//div[@role='alert' and contains(text(),'Required')][2]")).Text;
    }

    public string GetCountryError()
    {
        return _driver.FindElement(By.XPath("//div[@role='alert' and contains(text(),'Required')][3]")).Text;
    }

}