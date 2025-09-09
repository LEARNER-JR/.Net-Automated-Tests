using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class UserManagementNegativeTests
{
    private IWebDriver _driver;
    private UserManagementNegativePage _userManagementPage;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _userManagementPage = new UserManagementNegativePage(_driver);
    }

    [Test]
    public void Test_SubmitForm_RequiredFieldsEmpty()
    {
        _userManagementPage.NavigateTo();
        _userManagementPage.SubmitForm();
        Assert.That(_userManagementPage.GetErrorMessage(), Does.Contain("This field is required."));
    }

    [Test]
    public void Test_InvalidEmailFormat()
    {
        _userManagementPage.NavigateTo();
        _userManagementPage.EnterEmail("user@com");
        _userManagementPage.SubmitForm();
        Assert.That(_userManagementPage.GetErrorMessage(), Does.Contain("Invalid email format."));
    }

    [Test]
    public void Test_InvalidPhoneCharacters()
    {
        _userManagementPage.NavigateTo();
        _userManagementPage.EnterPhone("abc123");
        _userManagementPage.SubmitForm();
        Assert.That(_userManagementPage.GetErrorMessage(), Does.Contain("Invalid phone number."));
    }

    [Test]
    public void Test_FutureDateOfBirth()
    {
        _userManagementPage.NavigateTo();
        _userManagementPage.EnterDateOfBirth("12/31/2025");
        _userManagementPage.SubmitForm();
        Assert.That(_userManagementPage.GetErrorMessage(), Does.Contain("Date of birth cannot be in the future."));
    }

    [Test]
    public void Test_FirstNameExceedsMaxLength()
    {
        _userManagementPage.NavigateTo();
        _userManagementPage.EnterFirstName(new string('A', 256));
        _userManagementPage.SubmitForm();
        Assert.That(_userManagementPage.GetErrorMessage(), Does.Contain("First name exceeds maximum length."));
    }

    [Test]
    public void Test_InvalidGenderSelection()
    {
        _userManagementPage.NavigateTo();
        _userManagementPage.SelectGender("InvalidGender");
        _userManagementPage.SubmitForm();
        Assert.That(_userManagementPage.GetErrorMessage(), Does.Contain("Invalid gender selection."));
    }

    [Test]
    public void Test_EmailAlreadyAssociated()
    {
        _userManagementPage.NavigateTo();
        _userManagementPage.EnterEmail("existinguser@example.com");
        _userManagementPage.SubmitForm();
        Assert.That(_userManagementPage.GetErrorMessage(), Does.Contain("Email is already associated with an existing user."));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
