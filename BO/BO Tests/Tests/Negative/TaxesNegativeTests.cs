using BO_Tests.Tests;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TaxesNegativeTests : BaseTest
{
    private TaxesNegativePage _taxFormPage;
    private LoginPositivePage _loginPage;

    [SetUp]
    public void SetUp()
    {
        base.SetUp();

        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _taxFormPage = ServiceProvider.GetRequiredService<TaxesNegativePage>();
        _taxFormPage.NavigateToTaxesNegativePage();
        _taxFormPage.ClickNewTaxButton();
    }

    [Test]
    public void Test_RequiredError_WhenTaxPercentageIsEmpty()
    {
        _taxFormPage.SelectCountry("India");
        _taxFormPage.SelectServiceType("Consulting");
        _taxFormPage.SubmitForm();

        Assert.That(_taxFormPage.GetTaxPercentageError(), Is.EqualTo("Required"));
    }

    [Test]
    public void Test_RequiredError_WhenServiceTypeIsMissing()
    {
        _taxFormPage.SelectCountry("India");
        _taxFormPage.EnterTaxPercentage("18");
        _taxFormPage.SubmitForm();

        Assert.That(_taxFormPage.GetServiceTypeError(), Is.EqualTo("Required"));
    }

    [Test]
    public void Test_RequiredError_WhenCountryIsMissing()
    {
        _taxFormPage.SelectServiceType("Consulting");
        _taxFormPage.EnterTaxPercentage("18");
        _taxFormPage.SubmitForm();

        Assert.That(_taxFormPage.GetCountryError(), Is.EqualTo("Required"));
    }

    [Test]
    public void Test_MultipleRequiredErrors_WhenFormIsEmpty()
    {
        _taxFormPage.SubmitForm();

        Assert.That(_taxFormPage.GetCountryError(), Is.EqualTo("Required"));
        Assert.That(_taxFormPage.GetServiceTypeError(), Is.EqualTo("Required"));
        Assert.That(_taxFormPage.GetTaxPercentageError(), Is.EqualTo("Required"));
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    _driver.Quit();
    //}
}
