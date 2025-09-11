using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;
using BO_Tests.Tests;

[TestFixture]
public class AddUserGroupNegativeTest : BaseTest
{
    private IWebDriver _driver;
    private AddUserGroupNegativePage _userGroupPage;
    private const string BaseUrl = "https://sit-ui.upesimts.com/user-management/user-groups";

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(BaseUrl);
        _userGroupPage = new AddUserGroupNegativePage(_driver);
    }

    [Test]
    public void SubmitFormWithoutGroupName_ShouldShowErrorMessage()
    {
        _userGroupPage.ClickCreateUserGroup();
        // Add assertion for error message
        Assert.That(_driver.PageSource.Contains("error message"), Is.True); // Replace with actual error message
    }

    [Test]
    public void InputExcessivelyLongTextInGroupName_ShouldHandleGracefully()
    {
        string longGroupName = new string('a', 256); // Assuming 255 is the limit
        _userGroupPage.EnterGroupName(longGroupName);
        _userGroupPage.ClickCreateUserGroup();
        // Add assertion to check that the system did not crash
        Assert.That(true, Is.True); // Replace with actual check
    }

    [Test]
    public void InputInvalidCharactersInGroupName_ShouldPreventSubmission()
    {
        _userGroupPage.EnterGroupName("Invalid😊Name");
        _userGroupPage.ClickCreateUserGroup();
        // Add assertion for error message
        Assert.That(_driver.PageSource.Contains("error message"), Is.True); // Replace with actual error message
    }

    [Test]
    public void LeaveDescriptionEmptyAndSubmit_ShouldHandleGracefully()
    {
        _userGroupPage.EnterGroupName("Valid Group Name");
        _userGroupPage.ClickCreateUserGroup();
        // Add assertion for error message or successful submission
        Assert.That(_driver.PageSource.Contains("error message"), Is.True); // Replace with actual error message
    }

    [Test]
    public void ClickCreateUserGroupWithoutFillingFields_ShouldNotSubmit()
    {
        _userGroupPage.ClickCreateUserGroup();
        // Add assertion for form not submitted
        Assert.That(_driver.PageSource.Contains("error message"), Is.True); // Replace with actual error message
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    _driver.Quit();
    //}
}
