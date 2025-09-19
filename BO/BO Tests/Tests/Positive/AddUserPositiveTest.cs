using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;
using BO_Tests.Tests;

[TestFixture]
public class AddUserPositiveTest : BaseTest
{
    private AddUserPositivePage _addUserPositivePage;
    private LoginPositivePage _loginPage;

    [SetUp]
    public void SetUp()
    {
        base.SetUp();

        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _addUserPositivePage = ServiceProvider.GetRequiredService<AddUserPositivePage>();

        _addUserPositivePage.NavigateToUserManagementPage();
        _addUserPositivePage.ClickAddNewUserButton(); //open the form
        _addUserPositivePage.WaitForPageLoad(); //wait for the form to load to fill in    
    }

    [Test]
    public void VerifyUserCanSelectIndividual()
    {
        _addUserPositivePage.SelectUserType("Individual");
        Assert.That(Driver.FindElement(By.XPath("//span[text()='Individual']")).Text, Is.EqualTo("Individual"));
    }

    [Test]
    public void ConfirmValidUserDetailsAllowsRegistration()
    {
        //_addUserPositivePage.SelectUserType("Individual");
        _addUserPositivePage.EnterFirstName("John");
        _addUserPositivePage.EnterMiddleName("A.");
        _addUserPositivePage.EnterLastName("Dot");
        _addUserPositivePage.EnterEmail("john.doe@example.com");
        _addUserPositivePage.EnterPhoneNumber("1 (702) 123-4567");
        _addUserPositivePage.SelectDateOfBirth("01/01/2000");
        _addUserPositivePage.SelectGender("Male");
        _addUserPositivePage.ClickRegisterUser();
    }

    [TearDown]
    public void teardown()
    {
        Driver.Quit();
    }
}
