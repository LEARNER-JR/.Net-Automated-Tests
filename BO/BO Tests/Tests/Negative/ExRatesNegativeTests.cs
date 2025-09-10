using BO_Tests.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;
using Microsoft.Extensions.DependencyInjection;

[TestFixture]
public class ExRatesNegativeTests : BaseTest
{
    private ExRatesNegativePage _exchangeRatePage;
    private LoginPositivePage _loginPage;

    [SetUp]
    public void SetUp()
    {
        base.SetUp();
        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _exchangeRatePage = ServiceProvider.GetRequiredService<ExRatesNegativePage>();
        _exchangeRatePage.NavigateToExchangeRatePage();
        _exchangeRatePage.WaitForPageLoad();
    }

    [Test]
    public void TestSubmitWithoutSelectingCountry()
    {
        _exchangeRatePage.EnterFromCurrency("USD");
        _exchangeRatePage.EnterToCurrency("EUR");
        _exchangeRatePage.EnterRate("1.1");
        _exchangeRatePage.ClickAddExchangeRate();

        Assert.That(_exchangeRatePage.GetErrorMessage(), Does.Contain("Please select a country."));
    }

    [Test]
    public void TestNonNumericTaxPercentage()
    {
        _exchangeRatePage.EnterFromCurrency("USD");
        _exchangeRatePage.EnterToCurrency("EUR");
        _exchangeRatePage.EnterOperatingCountry("KENYA");
        _exchangeRatePage.EnterRate("abc");
        _exchangeRatePage.ClickAddExchangeRate();

        Assert.That(_exchangeRatePage.GetErrorMessage(), Does.Contain("Enter a valid number."));
    }

    [Test]
    public void TestServiceTypeNotSelected()
    {
        _exchangeRatePage.EnterFromCurrency("USD");
        _exchangeRatePage.EnterToCurrency("EUR");
        _exchangeRatePage.EnterOperatingCountry("KENYA");
        _exchangeRatePage.ClickAddExchangeRate();

        Assert.That(_exchangeRatePage.GetErrorMessage(), Does.Contain("Please select a service type."));
    }

    [Test]
    public void TestInvalidTaxPercentage()
    {
        _exchangeRatePage.EnterFromCurrency("USD");
        _exchangeRatePage.EnterToCurrency("EUR");
        _exchangeRatePage.EnterOperatingCountry("KENYA");
        _exchangeRatePage.EnterRate("-1");
        _exchangeRatePage.ClickAddExchangeRate();

        Assert.That(_exchangeRatePage.GetErrorMessage(), Does.Contain("Tax percentage must be between 0 and 100."));
    }

    [Test]
    public void TestAddTaxWithoutFillingFields()
    {
        _exchangeRatePage.ClickAddExchangeRate();
        //Assert.That(_driver.Url, Does.Not.Contain("success")); // Adjust based on actual behavior
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    _driver.Quit();
    //}
}
