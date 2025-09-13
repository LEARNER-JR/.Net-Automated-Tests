using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;
using BO_Tests.Tests;

[TestFixture]
public class TransactionPositiveTests : BaseTest
{
    private LoginPositivePage _loginPage;
    private CreateTransactionPage _createTransactionPage;

    [SetUp]
    public void Setup()
    {
        base.SetUp();
        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _createTransactionPage = ServiceProvider.GetRequiredService<CreateTransactionPage>();
        _createTransactionPage.NavigateToCreateTransactionPage();
        _createTransactionPage.WaitForPageLoad();

    }

    [Test]
    public void Test_NavigateToCreateTransactionPage()
    {
        Assert.That(_createTransactionPage.IsOnCreateTransactionPage(), Is.True,
            "User is not on Create Transaction page.");
    }

    [Test]
    public void Test_FillAndSubmitTransactionForm()
    {
        _createTransactionPage.FillSenderDetails("John Doe");
        _createTransactionPage.FillSenderAmount("200");
        _createTransactionPage.FillReceiverAmount("200");
        _createTransactionPage.ClickPreviewTransaction();
        // Example placeholder assertion
        Assert.That(Driver.PageSource, Does.Contain("Transaction Summary"));
    }

    [Test]
    public void Test_CalculateRateUpdatesFees()
    {
        _createTransactionPage.FillSenderAmount("200");
        _createTransactionPage.FillReceiverAmount("200");
        _createTransactionPage.ClickCalculateRate();
        // Example placeholder assertion
        Assert.That(Driver.PageSource, Does.Contain("Fees updated"));
    }

    [Test]
    public void Test_SelectCountryDropdown()
    {
        _createTransactionPage.SelectCountry("Kenya");
        Assert.That(_createTransactionPage.GetSelectedCountry(), Is.EqualTo("Kenya"));
    }

    [Test]
    public void Test_UploadSupportingDocument()
    {
        _createTransactionPage.UploadSupportingDocument("path/to/document.pdf");
        Assert.That(_createTransactionPage.IsDocumentUploaded(), Is.True);
    }

    [Test]
    public void Test_NewBeneficiaryCheckbox()
    {
        _createTransactionPage.CheckNewBeneficiaryCheckbox();
        Assert.That(_createTransactionPage.AreNewBeneficiaryFieldsEnabled(), Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}
