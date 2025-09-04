using NUnit.Framework;
using Scarlet_Tests.Pages.Negative;
using Scarlet_Tests.Tests;

[TestFixture]
public class AddBeneficiaryNegativeTest
{
    private AddBeneficiaryNegativePage _page;

    [SetUp]
    public void TestSetup()
    {
        driver.Navigate().GoToUrl(baseUrl + "add-beneficiary");
        _page = new AddBeneficiaryNegativePage(driver);
    }

    [Test]
    public void AttemptToAddBeneficiaryWithoutDetails()
    {
        _page.AddBeneficiary("");
        Assert.That(_page.GetErrorMessage(), Is.EqualTo("Please enter beneficiary details."));
    }

    [Test]
    public void TestInvalidDataEntry()
    {
        _page.AddBeneficiary("!@#$%^&*()");
        Assert.That(_page.GetErrorMessage(), Is.EqualTo("Invalid name entered."));
    }

    [Test]
    public void SimulateAddingDuplicateBeneficiary()
    {
        _page.AddBeneficiary("John Doe");
        _page.AddBeneficiary("John Doe");
        Assert.That(_page.GetErrorMessage(), Is.EqualTo("Beneficiary already exists."));
    }
}
