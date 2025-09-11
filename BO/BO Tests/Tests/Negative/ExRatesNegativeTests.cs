using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Microsoft.Extensions.DependencyInjection;
using BO_Tests.Tests;

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
    public void Test_EmptyFromCurrency()
    {
        _exchangeRatePage.SetToCurrency("USD");
        _exchangeRatePage.SetToDate("09/10/2025");
        _exchangeRatePage.SetOperatingCountry("KENYA");
        _exchangeRatePage.SetExchangeRate("1.5");
        _exchangeRatePage.ClickSubmit();

        Assert.That(_exchangeRatePage.IsErrorMessageDisplayed(), Is.True);
    }

    [Test]
    public void Test_EmptyToCurrency()
    {
        _exchangeRatePage.SetFromCurrency("USD");
        _exchangeRatePage.SetToDate("09/10/2025");
        _exchangeRatePage.SetOperatingCountry("KENYA");
        _exchangeRatePage.SetExchangeRate("1.5");
        _exchangeRatePage.ClickSubmit();

        Assert.That(_exchangeRatePage.IsErrorMessageDisplayed(), Is.True);
    }

    [Test]
    public void Test_InvalidDateFormat()
    {
        _exchangeRatePage.SetFromCurrency("USD");
        _exchangeRatePage.SetToCurrency("EUR");
        _exchangeRatePage.SetToDate("invalid-date");
        _exchangeRatePage.SetOperatingCountry("KENYA");
        _exchangeRatePage.SetExchangeRate("1.5");
        _exchangeRatePage.ClickSubmit();

        Assert.That(_exchangeRatePage.IsErrorMessageDisplayed(), Is.True);
    }

    [Test]
    public void Test_EmptyOperatingCountry()
    {
        _exchangeRatePage.SetFromCurrency("USD");
        _exchangeRatePage.SetToCurrency("EUR");
        _exchangeRatePage.SetToDate("09/10/2025");
        _exchangeRatePage.SetExchangeRate("1.5");
        _exchangeRatePage.ClickSubmit();

        Assert.That(_exchangeRatePage.IsErrorMessageDisplayed(), Is.True);
    }

    [Test]
    public void Test_EmptyExchangeRate()
    {
        _exchangeRatePage.SetFromCurrency("USD");
        _exchangeRatePage.SetToCurrency("EUR");
        _exchangeRatePage.SetToDate("09/10/2025");
        _exchangeRatePage.SetOperatingCountry("KENYA");
        _exchangeRatePage.ClickSubmit();

        Assert.That(_exchangeRatePage.IsErrorMessageDisplayed(), Is.True);
    }

    [Test]
    public void Test_ActivateNotificationWithEmptyFields()
    {
        _exchangeRatePage.ActivateNotificationCheckbox.Click();
        _exchangeRatePage.ClickSubmit();

        Assert.That(_exchangeRatePage.IsErrorMessageDisplayed(), Is.True);
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    driver.Quit();
    //}
}

