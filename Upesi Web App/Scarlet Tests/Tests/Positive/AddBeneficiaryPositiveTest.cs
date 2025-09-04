using NUnit.Framework;
using Scarlet_Tests.Tests;

[TestFixture]
public class AddBeneficiaryPositiveTest
{
    private AddBeneficiaryPage _page;

    [SetUp]
    public void TestSetup()
    {
        driver.Navigate().GoToUrl(baseUrl + "add-beneficiary");
        _page = new AddBeneficiaryPage(driver);
    }

    [Test]
    public void VerifyAddBeneficiaryTextIsDisplayed()
    {
        Assert.That(_page.AddBeneficiaryText.Displayed, Is.True);
    }

    [Test]
    public void EnsurePlusIconIsVisible()
    {
        Assert.That(_page.AddBeneficiaryIcon.Displayed, Is.True);
    }

    [Test]
    public void ValidateSuccessfulAdditionOfBeneficiary()
    {
        _page.AddBeneficiary("John Doe");
        Assert.That(_page.GetConfirmationMessage(), Is.EqualTo("Beneficiary added successfully!"));
    }

    [Test]
    public void AddMultipleBeneficiariesInOneSession()
    {
        _page.AddBeneficiary("John Doe");
        _page.AddBeneficiary("Jane Smith");
        Assert.That(_page.GetConfirmationMessage(), Does.Contain("Beneficiary added successfully"));
    }
}
