using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;
using BO_Tests.Tests;
using Microsoft.Extensions.DependencyInjection;

[TestFixture]
public class AddUserNegativeTest : BaseTest
{
    private LoginPositivePage _loginPage;
    private AddUserNegativePage _addUserNegativePage;

    [SetUp]
    public void SetUp()
    {
        base.SetUp();

        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _addUserNegativePage = ServiceProvider.GetRequiredService<AddUserNegativePage>();

        _addUserNegativePage.NavigateToUserManagementPage();
        _addUserNegativePage.ClickAddNewUserButton(); //open the form
        _addUserNegativePage.WaitForPageLoad(); //wait for the form to load to fill in    
    }

    [Test]
    public void SubmitFormWithEmptyFields_ShowsErrorMessages()
    {
        _addUserNegativePage.SubmitForm();
        Assert.That(_addUserNegativePage.GetErrorMessage(), Does.Contain("First Name is required"));
        Assert.That(_addUserNegativePage.GetErrorMessage(), Does.Contain("Last Name is required"));
        Assert.That(_addUserNegativePage.GetErrorMessage(), Does.Contain("Email is required"));
    }

    [Test]
    public void SubmitFormWithInvalidEmail_ShowsError()
    {
        _addUserNegativePage.EnterFirstName("John");
        _addUserNegativePage.EnterLastName("Doe");
        _addUserNegativePage.EnterEmail("user@.com");
        _addUserNegativePage.SubmitForm();
        Assert.That(_addUserNegativePage.GetErrorMessage(), Does.Contain("Invalid email format"));
    }

    [Test]
    public void SubmitFormWithInvalidPhoneNumber_ShowsError()
    {
        _addUserNegativePage.EnterFirstName("John");
        _addUserNegativePage.EnterLastName("Doe");
        _addUserNegativePage.EnterEmail("john.doe@example.com");
        _addUserNegativePage.EnterPhone("12345");
        _addUserNegativePage.SubmitForm();
        Assert.That(_addUserNegativePage.GetErrorMessage(), Does.Contain("Invalid phone number format"));
    }

    [Test]
    public void SubmitFormWithUnderageDOB_ShowsError()
    {
        _addUserNegativePage.EnterFirstName("John");
        _addUserNegativePage.EnterLastName("Doe");
        _addUserNegativePage.EnterEmail("john.doe@example.com");
        _addUserNegativePage.EnterPhone("+254712345678");
        _addUserNegativePage.EnterDateOfBirth("12/31/2025");
        _addUserNegativePage.SubmitForm();
        Assert.That(_addUserNegativePage.GetErrorMessage(), Does.Contain("User must be at least 18 years old"));
    }

    [Test]
    public void SubmitFormWithoutSelectingGender_ShowsError()
    {
        _addUserNegativePage.EnterFirstName("John");
        _addUserNegativePage.EnterLastName("Doe");
        _addUserNegativePage.EnterEmail("john.doe@example.com");
        _addUserNegativePage.EnterPhone("+254712345678");
        _addUserNegativePage.EnterDateOfBirth("01/01/2000");
        _addUserNegativePage.SubmitForm();
        Assert.That(_addUserNegativePage.GetErrorMessage(), Does.Contain("Gender is required"));
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    _driver.Quit();
    //}
}
