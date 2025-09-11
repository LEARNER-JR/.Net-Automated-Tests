using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TaxesCreativePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public TaxesCreativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement CountryInput => wait.Until(d => d.FindElement(By.Id("react-select-2-input")));
    public IWebElement ServiceTypeInput => wait.Until(d => d.FindElement(By.Id("react-select-3-input")));
    public IWebElement TaxPercentageInput => wait.Until(d => d.FindElement(By.Name("percentage")));
    public IWebElement AddTaxButton => wait.Until(d => d.FindElement(By.XPath("//button[contains(text(),'Add Tax')]")));
    public IWebElement CancelButton => wait.Until(d => d.FindElement(By.XPath("//button[contains(text(),'Cancel')]")));

    public void SelectCountry(string country)
    {
        CountryInput.Clear();
        CountryInput.SendKeys(country);
        CountryInput.SendKeys(Keys.Enter);
    }

    public void SelectServiceType(string serviceType)
    {
        ServiceTypeInput.Clear();
        ServiceTypeInput.SendKeys(serviceType);
        ServiceTypeInput.SendKeys(Keys.Enter);
    }

    public void EnterTaxPercentage(string percentage)
    {
        TaxPercentageInput.Clear();
        TaxPercentageInput.SendKeys(percentage);
    }

    public void ClickAddTax()
    {
        AddTaxButton.Click();
    }

    public void ClickCancel()
    {
        CancelButton.Click();
    }

    internal void NavigateToUserManagementPage()
    {
        throw new NotImplementedException();
    }

    internal void ClickAddNewUserButton()
    {
        throw new NotImplementedException();
    }

    internal void WaitForPageLoad()
    {
        throw new NotImplementedException();
    }
}