using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;
using BO_Tests.Tests;

[TestFixture]
public class UserGroupTests : BaseTest
{
    private IWebDriver _driver;
    private AddUserGroupPositivePage _userGroupPage;
    private const string BaseUrl = "https://sit-ui.upesimts.com/user-management/user-groups";

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(BaseUrl);
        _userGroupPage = new AddUserGroupPositivePage(_driver);
    }

    [Test]
    public void Test_SubmitForm_WithValidGroupNameAndDescription()
    {
        _userGroupPage.EnterGroupName("Test Group");
        _userGroupPage.EnterDescription("This is a test description.");
        _userGroupPage.SubmitForm();
        // Add assertion for successful submission
    }

    [Test]
    public void Test_GroupNameInput_AcceptsVariousFormats()
    {
        string[] validNames = { "SingleWord", "Multiple Words", "Special@Characters!" };
        foreach (var name in validNames)
        {
            _userGroupPage.EnterGroupName(name);
            Assert.That(_userGroupPage.GetGroupNameInputValue(), Is.EqualTo(name));
        }
    }

    [Test]
    public void Test_DescriptionTextarea_AllowsReasonableCharacterCount()
    {
        string longDescription = new string('a', 500); // Adjust the length as needed
        _userGroupPage.EnterDescription(longDescription);
        Assert.That(_userGroupPage.GetDescriptionTextareaValue(), Is.EqualTo(longDescription));
    }

    [Test]
    public void Test_CreateUserGroupButton_Enabled_WhenGroupNameFilled()
    {
        _userGroupPage.EnterGroupName("Valid Group Name");
        Assert.That(_userGroupPage.IsCreateUserGroupButtonEnabled(), Is.True);
    }

    [Test]
    public void Test_CancelButton_ClearsInputAndReturnsToPreviousState()
    {
        _userGroupPage.EnterGroupName("Group to Cancel");
        _userGroupPage.EnterDescription("Description to Cancel");
        _userGroupPage.ClickCancel();
        Assert.That(_userGroupPage.GetGroupNameInputValue(), Is.Empty);
        Assert.That(_userGroupPage.GetDescriptionTextareaValue(), Is.Empty);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
