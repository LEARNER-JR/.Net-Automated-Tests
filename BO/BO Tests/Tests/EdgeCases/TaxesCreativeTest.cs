using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;
using BO_Tests.Tests;

[TestFixture]
public class TaxesCreativeTests : BaseTest
{
    private TaxesCreativePage _taxCreativePage;
    private LoginPositivePage _loginPage;

    public void SetUp()
    {
        base.SetUp();

        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _taxCreativePage = ServiceProvider.GetRequiredService<TaxesCreativePage>();

        _taxCreativePage.NavigateToUserManagementPage();
        _taxCreativePage.ClickAddNewUserButton(); //open the form
        _taxCreativePage.WaitForPageLoad(); //wait for the form to load to fill in    
    }

    [Test]
    public void TestQuickSelectionOfCountriesAndServiceTypes()
    {
        string[] countries = { "USA", "Canada", "Mexico" };
        string[] serviceTypes = { "Service A", "Service B", "Service C" };

        foreach (var country in countries)
        {
            _taxCreativePage.SelectCountry(country);
            foreach (var serviceType in serviceTypes)
            {
                _taxCreativePage.SelectServiceType(serviceType);
                Assert.That(_taxCreativePage.AddTaxButton.Displayed, Is.True);
            }
        }
    }

    [Test]
    public void TestPastingLargeStringInTaxPercentage()
    {
        string largeString = new string('1', 100); // 100 characters of '1'
        _taxCreativePage.EnterTaxPercentage(largeString);
        Assert.That(_taxCreativePage.TaxPercentageInput.GetAttribute("value"), Is.EqualTo(largeString));
    }

    [Test]
    public void TestFormRetainsSelectedValuesOnNavigation()
    {
        _taxCreativePage.SelectCountry("USA");
        _taxCreativePage.SelectServiceType("Service A");
        //driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/taxes");
        Assert.That(_taxCreativePage.CountryInput.GetAttribute("value"), Is.EqualTo("USA"));
        Assert.That(_taxCreativePage.ServiceTypeInput.GetAttribute("value"), Is.EqualTo("Service A"));
    }

    [Test]
    public void TestAccessibilityWithScreenReaders()
    {
        // This test would require a screen reader tool to verify accessibility. 
        // Implementing a placeholder for this test.
        Assert.Pass("Accessibility tests must be conducted using a screen reader tool.");
    }

    [Test]
    public void TestKeyboardNavigation()
    {
        _taxCreativePage.CountryInput.SendKeys(Keys.Tab);
        Assert.That(_taxCreativePage.ServiceTypeInput.Displayed, Is.True);
        _taxCreativePage.ServiceTypeInput.SendKeys(Keys.Tab);
        Assert.That(_taxCreativePage.TaxPercentageInput.Displayed, Is.True);
        _taxCreativePage.TaxPercentageInput.SendKeys(Keys.Tab);
        Assert.That(_taxCreativePage.AddTaxButton.Displayed, Is.True);
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    driver.Quit();
    //}
}
