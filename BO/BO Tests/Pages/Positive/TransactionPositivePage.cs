using Docker.DotNet.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class TransactionPositivePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public TransactionPositivePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    //sender details
    public IWebElement SearchUserInput => wait.Until(d => d.FindElement(By.Id("react-select-3-input")));
    public IWebElement SearchUserPlaceholder => wait.Until(d => d.FindElement(By.Id("react-select-3-placeholder")));

    public void EnterSearchUser(string query)
    {
        SearchUserInput.Clear();
        SearchUserInput.SendKeys(query);
    }
    public string GetSearchUserInputValue()
    {
        return SearchUserInput.GetAttribute("value");
    }
    internal void NavigateToTransactionPage()
    {
        driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/transactions");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("transactions"));
    }
    internal void ClickAddTransactionButton()
    {
        var addTransactionButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/main/div/div/div[2]/div[1]/div[2]/div/a/button")));
        addTransactionButton.Click();
    }
    internal void WaitForPageLoad()
    {
        wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }
    internal void ClickUser()
    {
        string value = GetSearchUserInputValue(); // whatever was typed/shown in the input
        var option = wait.Until(d => d.FindElement(By.XPath($"//div[contains(@class,'css') and text()='{value}']")));
        option.Click();
    }

    //service type
    public IWebElement ReceiverCountryDropdown => wait.Until(d => d.FindElement(By.Id("react-select-4-input")));
    public IWebElement ReceiverServiceTypeDropdown => wait.Until(d => d.FindElement(By.Id("react-select-5-input")));
    public IWebElement ReceiverTypeDropdown => wait.Until(d => d.FindElement(By.Id("react-select-6-input")));
    public IWebElement ReceiverCountryPlaceholder => wait.Until(d => d.FindElement(By.Id("react-select-4-placeholder")));
    public IWebElement ReceiverServiceTypePlaceholder => wait.Until(d => d.FindElement(By.Id("react-select-5-placeholder")));
    public IWebElement ReceiverTypePlaceholder => wait.Until(d => d.FindElement(By.Id("react-select-6-placeholder")));
    public IWebElement SubmitButton => wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));
    public void WaitForServiceForm()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Receiver Country']")));
    }
    public void SelectReceiverCountry(string country)
    {
        ReceiverCountryDropdown.Click();
        ReceiverCountryDropdown.SendKeys(country);
        ReceiverCountryDropdown.SendKeys(Keys.Enter);
    }

    public void SelectReceiverServiceType(string serviceType)
    {
        ReceiverServiceTypeDropdown.Click();
        ReceiverServiceTypeDropdown.SendKeys(serviceType);
        ReceiverServiceTypeDropdown.SendKeys(Keys.Enter);
    }

    public void EnterReceiverType(string receiverType)
    {
        ReceiverTypeDropdown.Click();
        ReceiverTypeDropdown.SendKeys(receiverType);
        ReceiverTypeDropdown.SendKeys(Keys.Enter);
    }

    public string GetReceiverCountryPlaceholderText() => ReceiverCountryPlaceholder.Text;
    public string GetReceiverServiceTypePlaceholderText() => ReceiverServiceTypePlaceholder.Text;
    public string GetReceiverTypePlaceholderText() => ReceiverTypePlaceholder.Text;


    //exchange rates
    //public CurrencyExchangePage(IWebDriver driver) : base(driver) { }

    private IWebElement SenderCurrencyDropdown => driver.FindElement(By.Id("react-select-7-input"));
    private IWebElement ReceiverCurrencyDropdown => driver.FindElement(By.Id("react-select-8-input"));
    private IWebElement SenderAmountInput => driver.FindElement(By.Name("sendAmount"));
    private IWebElement CalculateRateButton => driver.FindElement(By.XPath("//button[text()='Calculate Rate']"));
    private IWebElement PromotionCodeInput => driver.FindElement(By.Name("promotionCode"));
    private IWebElement FeesText => driver.FindElement(By.XPath("//p[contains(text(),'Fees:')]"));
    private IWebElement ExciseDutyText => driver.FindElement(By.XPath("//p[contains(text(),'Excise duty:')]"));
    private IWebElement ExchangeRateText => driver.FindElement(By.XPath("//p[contains(text(),'Exchange rate:')]"));
    private IWebElement TotalToPayText => driver.FindElement(By.XPath("//p[contains(text(),'Total to pay:')]"));

    public void WaitForExRatesForm()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/main/div/div/div/form/div[1]/div[3]")));
    }
    internal void EnterReceiverCountry(string v)
    {
        throw new NotImplementedException();
    }

    internal void EnterReceiverServiceType(string v)
    {
        throw new NotImplementedException();
    }

    internal object GetErrorMessageText()
    {
        throw new NotImplementedException();
    }

    internal void SubmitForm()
    {
        throw new NotImplementedException();
    }

    internal void EnterEmail(string v)
    {
        throw new NotImplementedException();
    }


    //receiver details
    public IWebElement NewBeneficiaryCheckbox => driver.FindElement(By.XPath("/html/body/main/div/div/div/form/div[1]/div[4]/div[1]/div[1]/div/label/span[1]/input"));
    public IWebElement NewBeneficiaryCheckboxClickable => driver.FindElement(By.XPath("/html/body/main/div/div/div/form/div[1]/div[4]/div[1]/div[1]/div/label/span[1]/svg")); //exception   
    public IWebElement ReceiverNameInput => driver.FindElement(By.Name("receiverFirstName"));
    public IWebElement EmailInput => driver.FindElement(By.Name("receiverEmail"));
    public IWebElement PhoneNumberInput => driver.FindElement(By.XPath("//input[@type='tel']"));
    public IWebElement DateOfBirthInput => driver.FindElement(By.XPath("//input[@placeholder='Select Date']"));
    public IWebElement GenderDropdown => driver.FindElement(By.Id("headlessui-listbox-button-:r7:"));
    public IWebElement DocumentTypeDropdown => driver.FindElement(By.Id("react-select-11-input"));
    public IWebElement DocumentNumberInput => driver.FindElement(By.Name("receiverDocumentNumber"));
    public IWebElement PlaceOfIssueInput => driver.FindElement(By.Name("receiverDocumentPlaceofIssueCountryID"));
    public IWebElement DocumentExpiryDateInput => driver.FindElement(By.XPath("//input[@placeholder='Select Date'][2]"));
    public IWebElement StateDropdown => driver.FindElement(By.Id("react-select-13-input"));
    public IWebElement CityDropdown => driver.FindElement(By.Id("react-select-14-input"));
    public IWebElement StreetInput => driver.FindElement(By.Name("receiverStreet"));
    public IWebElement ZipCodeInput => driver.FindElement(By.Name("receiverZipCode"));
    public IWebElement RegionInput => driver.FindElement(By.Name("regionBeneficiary"));
    //public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[contains(text(),'Submit')]")); // Adjust selector as necessary

    public void CheckNewBeneficiaryCheckbox()
    {
        if (!NewBeneficiaryCheckbox.Selected)
        {
            NewBeneficiaryCheckboxClickable.Click();
        }
    }

    public void EnterReceiverName(string name)
    {
        ReceiverNameInput.SendKeys(name);
    }

    //public void EnterEmail(string email)
    //{
    //    EmailInput.SendKeys(email);
    //}

    public void EnterPhoneNumber(string phoneNumber)
    {
        PhoneNumberInput.SendKeys(phoneNumber);
    }

    public void SelectDateOfBirth(string date)
    {
        DateOfBirthInput.Click();
        DateOfBirthInput.SendKeys(date);
    }

    public void SelectGender(string gender)
    {
        GenderDropdown.Click();
        var genderOption = wait.Until(d => d.FindElement(By.XPath($"//li[contains(text(),'{gender}')]")));
        genderOption.Click();
    }

    public void SelectDocumentType(string documentType)
    {
        DocumentTypeDropdown.Click();
        var docTypeOption = wait.Until(d => d.FindElement(By.XPath($"//li[contains(text(),'{documentType}')]")));
        docTypeOption.Click();
    }

    public void EnterDocumentNumber(string documentNumber)
    {
        DocumentNumberInput.SendKeys(documentNumber);
    }

    public void EnterPlaceOfIssue(string place)
    {
        PlaceOfIssueInput.SendKeys(place);
    }

    public void SelectDocumentExpiryDate(string expiryDate)
    {
        DocumentExpiryDateInput.Click();
        DocumentExpiryDateInput.SendKeys(expiryDate);
    }

    public void SelectState(string state)
    {
        StateDropdown.Click();
        var stateOption = wait.Until(d => d.FindElement(By.XPath($"//li[contains(text(),'{state}')]")));
        stateOption.Click();
    }

    public void SelectCity(string city)
    {
        CityDropdown.Click();
        var cityOption = wait.Until(d => d.FindElement(By.XPath($"//li[contains(text(),'{city}')]")));
        cityOption.Click();
    }

    public void EnterStreet(string street)
    {
        StreetInput.SendKeys(street);
    }

    public void EnterZipCode(string zipCode)
    {
        ZipCodeInput.SendKeys(zipCode);
    }

    public void EnterRegion(string region)
    {
        RegionInput.SendKeys(region);
    }

    internal object GetSuccessMessage()
    {
        throw new NotImplementedException();
    }

    //public void SubmitForm()
    //{
    //    SubmitButton.Click();
    //}
}

