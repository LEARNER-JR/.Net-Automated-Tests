using BO_Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TariffPositiveTests : BaseTest
{
    private TariffPositivePage _tariffPage;
    private LoginPositivePage _loginPage;

    [SetUp]
    public void Setup()
    {
        base.SetUp();
        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _tariffPage = ServiceProvider.GetRequiredService<TariffPositivePage>();

        _tariffPage.NavigateToAddTariff();
        _tariffPage.ClickAddTariffButton(); //open the form pop up
        _tariffPage.WaitForPageLoad(); //wait for it to load
    }

    [TestCase("KENYA", "CANADA", "Bank Deposit", "Domestic", "One Time", "100", "2000", "200")]
    [TestCase("KENYA", "GAMBIA", "Cash Pickup", "International", "Recurring", "300", "1000", "150")]

    public void TestFillAndSubmitForm(
        string fromCountry,
        string toCountry,
        string serviceType,
        string scope,
        string frequency,
        string fromAmount,
        string toAmount,
        string tariffAmount)
    {
        _tariffPage.FillForm(fromCountry, toCountry, serviceType, scope, frequency, fromAmount, toAmount, tariffAmount);
        _tariffPage.ClickAddTariff();
        //Assert.That(driver.Url, Does.Contain("success"));
    }

    [TestCase("KENYA", "USA", "Standard", "Domestic", "One Time", "100", "200", "50")]
    public void TestDropdownSelections(
        string fromCountry,
        string toCountry,
        string serviceType,
        string scope,
        string frequency,
        string fromAmount,
        string toAmount,
        string tariffAmount)
    {
        _tariffPage.FillForm(fromCountry, toCountry, serviceType, scope, frequency, fromAmount, toAmount, tariffAmount);
        _tariffPage.ClickAddTariff();
        //Assert.That(driver.Url, Does.Contain("success"));
    }

    [Test]
    public void TestAllowNotificationsCheckbox()
    {
        _tariffPage.CheckAllowNotificationsCheckbox();
        Assert.That(_tariffPage.AllowNotificationsCheckbox.Selected, Is.True);
        _tariffPage.CheckAllowNotificationsCheckbox();
        Assert.That(_tariffPage.AllowNotificationsCheckbox.Selected, Is.False);
    }

    [TestCase("100", "200", "50")]
    [TestCase("500", "1000", "150")]
    public void TestNumericInputs(string fromAmount, string toAmount, string tariffAmount)
    {
        _tariffPage.FillForm("KENYA", "USA", "Standard", "Domestic", "One Time", fromAmount, toAmount, tariffAmount);
        Assert.That(_tariffPage.FromTransactionAmountInput.GetAttribute("value"), Is.EqualTo(fromAmount));
        Assert.That(_tariffPage.ToTransactionAmountInput.GetAttribute("value"), Is.EqualTo(toAmount));
        Assert.That(_tariffPage.TariffAmountInput.GetAttribute("value"), Is.EqualTo(tariffAmount));
    }

    [TestCase("KENYA", "USA", "Standard", "Domestic", "One Time", "100", "200", "50")]
    public void TestCancelButton(
        string fromCountry,
        string toCountry,
        string serviceType,
        string scope,
        string frequency,
        string fromAmount,
        string toAmount,
        string tariffAmount)
    {
        _tariffPage.FillForm(fromCountry, toCountry, serviceType, scope, frequency, fromAmount, toAmount, tariffAmount);
        _tariffPage.ClickCancel();
        //Assert.That(driver.Url, Does.Contain("previous"));
    }
    //[TearDown]
    //public void TearDown()
    //{
    //    driver.Quit();
    //}
}
