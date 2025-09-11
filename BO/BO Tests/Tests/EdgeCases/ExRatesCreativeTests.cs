using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;
using Microsoft.Extensions.DependencyInjection;
using BO_Tests.Tests;

[TestFixture]
public class ExRatesCreativeTests : BaseTest
{
    private IWebDriver _driver;
    private ExRatesCreativePage _taxesPage;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/exchange-rates");
        _taxesPage = new ExRatesCreativePage(_driver);
    }

    [Test]
    public void VerifyDropdownsDisplaySortedCurrencies()
    {
        _taxesPage.SelectFromCurrency("USD");
        _taxesPage.SelectToCurrency("EUR");

        // Add assertions to verify the currencies are sorted
        // This requires a method to retrieve and sort the dropdown options
    }

    [Test]
    public void VerifyToDateFieldAutosuggestsCurrentDate()
    {
        _taxesPage.ToDateInput.Click();
        // Add assertion to check if current date is suggested
    }

    [Test]
    public void VerifyKeyboardNavigationInDropdowns()
    {
        _taxesPage.FromCurrencyDropdown.Click();
        _taxesPage.FromCurrencyDropdown.SendKeys(Keys.ArrowDown);
        _taxesPage.FromCurrencyDropdown.SendKeys(Keys.Enter);

        // Add assertions to verify the selected option
    }

    [Test]
    public void VerifyNotificationCheckboxLabelChanges()
    {
        _taxesPage.CheckNotificationCheckbox();
        Assert.That(_taxesPage.NotificationCheckbox.GetAttribute("label"), Is.EqualTo("Deactivate Notification"));

        _taxesPage.UncheckNotificationCheckbox();
        Assert.That(_taxesPage.NotificationCheckbox.GetAttribute("label"), Is.EqualTo("Activate Notification"));
    }

    [Test]
    public void VerifyNonNumericInputInExchangeRateField()
    {
        _taxesPage.EnterExchangeRate("abc");
        Assert.That(_taxesPage.ExchangeRateInput.GetAttribute("value"), Is.EqualTo(""));
    }

    [Test]
    public void VerifyCancelButtonResetsForm()
    {
        _taxesPage.SelectFromCurrency("USD");
        _taxesPage.SelectToCurrency("EUR");
        _taxesPage.EnterExchangeRate("5");
        _taxesPage.CheckNotificationCheckbox();

        _taxesPage.ClickCancelButton();

        // Add assertions to verify all fields are reset
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    _driver.Quit();
    //}
}
