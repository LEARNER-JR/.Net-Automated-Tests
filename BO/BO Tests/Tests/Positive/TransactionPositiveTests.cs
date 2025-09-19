using BO_Tests.Tests;
using Docker.DotNet.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.Mime.MediaTypeNames;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TransactionPositiveTests : BaseTest
{
    private TransactionPositivePage _transactionPositiveTests;
    private LoginPositivePage _loginPage;

    [SetUp]
    public void Setup()
    {
        base.SetUp();
        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _transactionPositiveTests = ServiceProvider.GetRequiredService<TransactionPositivePage>();
        _transactionPositiveTests.NavigateToTransactionPage();
        _transactionPositiveTests.WaitForPageLoad();
        _transactionPositiveTests.ClickAddTransactionButton();
    }

    //sender details tests
    [Test]
    public void SearchAndClickUserByFullName()
    {
        string fullName = "Shawn Kamau";
        _transactionPositiveTests.EnterSearchUser(fullName);
        _transactionPositiveTests.ClickUser();

        _transactionPositiveTests.WaitForServiceForm();
    }

    //service type tests
    [Test]
    public void confimServiceTypeDetails()
    {
        _transactionPositiveTests.SelectReceiverCountry("Cameroon");
        _transactionPositiveTests.SelectReceiverServiceType("Bank Deposit");
        _transactionPositiveTests.EnterReceiverType("individual");
    }


    //exchage details tests

    [Test]
    public void TestValidCredentials()
    {
        _transactionPositiveTests.EnterReceiverCountry("United States");
        _transactionPositiveTests.EnterReceiverServiceType("Express");
        _transactionPositiveTests.EnterReceiverType("Individual");
        _transactionPositiveTests.SubmitForm();

        _transactionPositiveTests.WaitForExRatesForm();
    }

    [Test]
    public void VerifyReceiverDetailsCanBeEnteredAndSubmittedSuccessfully()
    {
        // Step 1: Check New Beneficiary
        _transactionPositiveTests.CheckNewBeneficiaryCheckbox();
        //Assert.That(_transactionPositiveTests.NewBeneficiaryCheckbox.Selected,Is.True, "New Beneficiary checkbox should be selected.");

        // Step 2: Fill in Receiver Core Details
        _transactionPositiveTests.EnterReceiverName("John Doe");
        _transactionPositiveTests.EnterEmail("john.doe@example.com");
        _transactionPositiveTests.EnterPhoneNumber("1 (702) 1234567");
        _transactionPositiveTests.SelectDateOfBirth("01/01/1990");
        _transactionPositiveTests.SelectGender("Male");

        // Step 3: Identification Document
        _transactionPositiveTests.SelectDocumentType("Passport");
        _transactionPositiveTests.EnterDocumentNumber("A1234567");
        _transactionPositiveTests.EnterPlaceOfIssue("USA");
        _transactionPositiveTests.SelectDocumentExpiryDate("01/01/2030");

        // Step 4: Address
        _transactionPositiveTests.SelectState("California");
        _transactionPositiveTests.SelectCity("Los Angeles");
        _transactionPositiveTests.EnterStreet("123 Main St");
        _transactionPositiveTests.EnterZipCode("90001");
        _transactionPositiveTests.EnterRegion("West");

        // Step 5: Validate only key fields
        Assert.That(_transactionPositiveTests.ReceiverNameInput.GetAttribute("value"),Is.EqualTo("John Doe"), "Receiver Name should be entered correctly.");
        Assert.That(_transactionPositiveTests.EmailInput.GetAttribute("value"),Is.EqualTo("john.doe@example.com"), "Email should be entered correctly.");
        _transactionPositiveTests.SubmitForm();

        Assert.That(_transactionPositiveTests.GetSuccessMessage(),Does.Contain("Receiver details submitted successfully"),"Form submission success message should be displayed.");
    }

    //quit after filling all details
    [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
}

