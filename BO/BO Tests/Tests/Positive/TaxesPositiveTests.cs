using BO_Tests.Tests;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TaxesPositiveTests : BaseTest
{
    private TaxesPositivePage _taxpage;
    private LoginPositivePage _loginPage;

    [SetUp]
    public void Setup()
    {
        base.SetUp();

        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _taxpage = ServiceProvider.GetRequiredService<TaxesPositivePage>();

        // Navigate to taxes page & open form
        _taxpage.NavigateToTaxesPositivePage();
        _taxpage.ClickAddNewTaxButton();
    }

    [Test]
    public void VerifyFormSubmission()
    {
        _taxpage.EnterCountry("India");
        _taxpage.EnterServiceType("Bank Deposit");
        _taxpage.EnterTaxPercentage("18");
        _taxpage.ToggleNotificationCheckbox(); //exeption
        _taxpage.SubmitForm();
    }

    [Test]
    public void CheckCountryDropdownSelection()
    {
        _taxpage.EnterCountry("India");
        Assert.That(_taxpage.CountryInput.GetAttribute("value"),
            Is.EqualTo("India"), "Country selection is not reflected correctly.");
    }

    [Test]
    public void EnsureServiceTypeUpdatesCorrectly()
    {
        _taxpage.EnterServiceType("Consulting");
        Assert.That(_taxpage.ServiceTypeInput.GetAttribute("value"),
            Is.EqualTo("Consulting"), "Service type selection is not reflected correctly.");
    }

    [Test]
    public void ValidateTaxPercentageInput()
    {
        _taxpage.EnterTaxPercentage("18");
        Assert.That(_taxpage.TaxPercentageInput.GetAttribute("value"),
            Is.EqualTo("18"), "Tax percentage input is not accepting numerical values correctly.");
    }

    [Test]
    public void TestActivateNotificationCheckbox()
    {
        _taxpage.ToggleNotificationCheckbox();
        Assert.That(_taxpage.ActivateNotificationCheckbox.Selected,
            Is.True, "Checkbox should be checked.");

        _taxpage.ToggleNotificationCheckbox();
        Assert.That(_taxpage.ActivateNotificationCheckbox.Selected,
            Is.False, "Checkbox should be unchecked.");
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    _driver.Quit();
    //}
}
