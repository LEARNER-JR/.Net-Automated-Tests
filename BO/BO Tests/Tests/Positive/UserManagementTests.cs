using BO_Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class UserManagementTests : BaseTest
{
    private UserManagementPage _userManagementPage;
    private LoginPositivePage _loginPage;

    [SetUp]
    public void SetUp()
    {
        base.SetUp();

        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _userManagementPage = ServiceProvider.GetRequiredService<UserManagementPage>();

        _userManagementPage.NavigateToUserManagementPage();
        _userManagementPage.ClickAddNewUserButton(); //open the form
        _userManagementPage.WaitForPageLoad(); //wait for the form to load to fill in    
    }

    [Test]
    public void TestFormSubmissionWithValidData()
    {
        _userManagementPage.FillFirstName("John");
        _userManagementPage.FillMiddleName("A.");
        _userManagementPage.FillLastName("Doe");
        _userManagementPage.FillEmail("johndoe@gmail.com");
        _userManagementPage.FillPhoneNumber("+254712345678");
        _userManagementPage.FillDateOfBirth("08/09/2007");
        _userManagementPage.SelectGender("Male");
        _userManagementPage.FillCompany("Example Company");
        _userManagementPage.SubmitForm();
    }

    [Test]
    public void TestNameInputWithSpacesAndHyphens()
    {
        _userManagementPage.FillFirstName("Anna-Marie");
        _userManagementPage.FillMiddleName("O'Connor");
        _userManagementPage.FillLastName("Smith-Jones");

        Assert.That(_userManagementPage.FirstNameInput.GetAttribute("value"), Is.EqualTo("Anna-Marie"));
        Assert.That(_userManagementPage.MiddleNameInput.GetAttribute("value"), Is.EqualTo("O'Connor"));
        Assert.That(_userManagementPage.LastNameInput.GetAttribute("value"), Is.EqualTo("Smith-Jones"));
    }

    [Test]
    public void TestEmailInputWithValidEmail()
    {
        _userManagementPage.FillEmail("valid.email@example.com");
        Assert.That(_userManagementPage.EmailInput.GetAttribute("value"), Is.EqualTo("valid.email@example.com"));
    }

    [Test]
    public void TestPhoneNumberInputWithValidFormats()
    {
        _userManagementPage.FillPhoneNumber("+254712345678");
        Assert.That(_userManagementPage.PhoneNumberInput.GetAttribute("value"), Is.EqualTo("+254712345678"));
    }

    [Test]
    public void TestDateOfBirthFieldWithValidDate()
    {
        _userManagementPage.FillDateOfBirth("08/09/2007");
        Assert.That(_userManagementPage.DateOfBirthInput.GetAttribute("value"), Is.EqualTo("08/09/2007"));
    }

    [Test]
    public void TestGenderSelection()
    {
        _userManagementPage.SelectGender("Female");
        Assert.That(_userManagementPage.GenderDropdown.Text, Is.EqualTo("Female"));
    }

    [Test]
    public void TestCompanySelection()
    {
        _userManagementPage.FillCompany("Test Company");
        Assert.That(_userManagementPage.CompanyInput.GetAttribute("value"), Is.EqualTo("Test Company"));
    }

    [Test]
    public void TestCreateUserButtonEnabledState()
    {
        _userManagementPage.FillFirstName("Valid");
        _userManagementPage.FillLastName("User");
        _userManagementPage.FillEmail("user@example.com");
        _userManagementPage.FillPhoneNumber("+254712345678");
        _userManagementPage.FillDateOfBirth("08/09/2007");
        _userManagementPage.SelectGender("Male");
        _userManagementPage.FillCompany("Example Company");

        Assert.That(_userManagementPage.CreateUserButton.Enabled, Is.True);
    }
}
