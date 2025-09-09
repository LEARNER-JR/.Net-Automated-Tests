using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TariffPositivePage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public TariffPositivePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public string BaseUrl => "https://sit-ui.upesimts.com/tariffs";

    public IWebElement FromCountryInput => driver.FindElement(By.Name("fromCountryID"));
    public IWebElement ReceivingCountryDropdown => driver.FindElement(By.Id("headlessui-listbox-button-:r36:"));
    public IWebElement ServiceTypeDropdown => driver.FindElement(By.Id("headlessui-listbox-button-:r39:"));
    public IWebElement TariffTypeDropdown => driver.FindElement(By.Id("headlessui-listbox-button-:r3c:"));
    public IWebElement TransactionTypeDropdown => driver.FindElement(By.Id("headlessui-listbox-button-:r3f:"));
    public IWebElement FromTransactionAmountInput => driver.FindElement(By.XPath("//input[@placeholder='Screen reader only' and @type='text'][1]"));
    public IWebElement ToTransactionAmountInput => driver.FindElement(By.XPath("//input[@placeholder='Screen reader only' and @type='text'][2]"));
    public IWebElement TariffAmountInput => driver.FindElement(By.XPath("//input[@placeholder='Screen reader only' and @type='text'][3]"));
    public IWebElement AllowNotificationsCheckbox => driver.FindElement(By.Name("notificationActive"));
    public IWebElement CancelButton => driver.FindElement(By.XPath("//button[text()='Cancel']"));
    public IWebElement AddTariffButton => driver.FindElement(By.XPath("//button[text()='Add Tariff']"));

    public void NavigateToAddTariff()
    {
        driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/tariffs");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("tariffs"));
    }
    public void WaitForPageLoad()
    {
        wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }
    public void ClickAddTariffButton()
    {
        var addNewTariffButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/main/div/div/div/div[1]/div[3]/button")));
        addNewTariffButton.Click();
    }

    public void FillForm(string fromCountry, string receivingCountry, string serviceType, string tariffType, string transactionType, string fromAmount, string toAmount, string tariffAmount)
    {
        FromCountryInput.SendKeys(fromCountry);
        ReceivingCountryDropdown.Click();
        SelectDropdownOption(receivingCountry);
        ServiceTypeDropdown.Click();
        SelectDropdownOption(serviceType);
        TariffTypeDropdown.Click();
        SelectDropdownOption(tariffType);
        TransactionTypeDropdown.Click();
        SelectDropdownOption(transactionType);
        FromTransactionAmountInput.SendKeys(fromAmount);
        ToTransactionAmountInput.SendKeys(toAmount);
        TariffAmountInput.SendKeys(tariffAmount);
    }

    private void SelectDropdownOption(string option)
    {
        wait.Until(d => d.FindElement(By.XPath($"//span[text()='{option}']"))).Click();
    }

    public void CheckAllowNotificationsCheckbox()
    {
        AllowNotificationsCheckbox.Click();
    }

    public void ClickCancel()
    {
        CancelButton.Click();
    }

    public void ClickAddTariff()
    {
        AddTariffButton.Click();
    }
}