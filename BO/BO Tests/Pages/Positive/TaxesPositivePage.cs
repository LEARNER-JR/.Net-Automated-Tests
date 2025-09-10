using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TaxesPositivePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public TaxesPositivePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Navigation
    public void NavigateToTaxesPositivePage()
    {
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/taxes");
        WaitForPageLoad();
    }

    public void WaitForPageLoad()
    {
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/taxes");
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/taxes"));
        //_wait.Until(d => d.FindElement(By.XPath("//button[contains(., 'Tax')]")).Displayed);
    }

    // Elements
    public IWebElement AddNewTaxButton =>
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
            By.XPath("//button[contains(., 'Tax')]")));

    public IWebElement CountryInput =>
        _wait.Until(d => d.FindElement(By.Id("react-select-2-input")));

    public IWebElement ServiceTypeInput =>
        _wait.Until(d => d.FindElement(By.Id("react-select-3-input")));

    public IWebElement TaxPercentageInput =>
        _wait.Until(d => d.FindElement(By.Name("percentage")));

    public IWebElement ActivateNotificationCheckbox =>
        _wait.Until(d => d.FindElement(By.ClassName("rizzui-checkbox-input")));

    public IWebElement SubmitButton =>
        _wait.Until(d => d.FindElement(By.XPath("//button[text()='Add Tax']")));

    public IWebElement CancelButton =>
        _wait.Until(d => d.FindElement(By.XPath("//button[text()='Cancel']")));

    // Actions
    public void ClickAddNewTaxButton()
    {
        AddNewTaxButton.Click();
        WaitForFormLoad();
    }

    public void WaitForFormLoad()
    {
        _wait.Until(d => d.FindElement(By.Name("percentage")).Displayed);
    }

    public void EnterCountry(string country)
    {
        CountryInput.SendKeys(country);
        CountryInput.SendKeys(Keys.Enter);
    }

    public void EnterServiceType(string serviceType)
    {
        ServiceTypeInput.SendKeys(serviceType);
        ServiceTypeInput.SendKeys(Keys.Enter);
    }

    public void EnterTaxPercentage(string percentage)
    {
        TaxPercentageInput.Clear();
        TaxPercentageInput.SendKeys(percentage);
    }

    public void ToggleNotificationCheckbox()
    {
        ActivateNotificationCheckbox.Click();
    }

    public void SubmitForm()
    {
        SubmitButton.Click();
    }
}
