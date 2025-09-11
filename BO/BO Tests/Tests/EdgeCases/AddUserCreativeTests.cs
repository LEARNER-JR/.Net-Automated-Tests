using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;
using BO_Tests.Tests;

[TestFixture]
public class AddUserCreativeTests : BaseTest
{
    private IWebDriver _driver;
    private AddUserCreativePage _registrationPage;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/customers/users");
        _registrationPage = new AddUserCreativePage(_driver);
    }

    [Test]
    public void Test_UserTypeChange_ResetsForm()
    {
        _registrationPage.SelectUserType("Individual");
        _registrationPage.FillPersonalDetails("John", "Doe", "Smith", "john@example.com", "+254712345678", "01/01/1990");
        _registrationPage.SelectUserType("Organization");

        Assert.That(_registrationPage.FirstNameInput.GetAttribute("value"), Is.Empty);
        Assert.That(_registrationPage.MiddleNameInput.GetAttribute("value"), Is.Empty);
        Assert.That(_registrationPage.LastNameInput.GetAttribute("value"), Is.Empty);
        Assert.That(_registrationPage.EmailInput.GetAttribute("value"), Is.Empty);
    }

    [Test]
    public void Test_GenderOptionQuickClick()
    {
        _registrationPage.SelectUserType("Individual");
        _registrationPage.FillPersonalDetails("John", "Doe", "Smith", "john@example.com", "+254712345678", "01/01/1990");

        _registrationPage.SelectGender("Male");
        _registrationPage.SelectGender("Female");
        _registrationPage.SelectGender("Male");

        Assert.That(_registrationPage.GenderButton.Text, Is.EqualTo("Male")); // Assuming the button shows the selected gender
    }

    [Test]
    public void Test_PlaceholderVisibility()
    {
        _registrationPage.FirstNameInput.SendKeys("John");
        Assert.That(_registrationPage.FirstNameInput.GetAttribute("placeholder"), Is.Empty);
    }

    [Test]
    public void Test_FormResponsiveness()
    {
        _registrationPage.ResizeBrowser(800, 600);
        Assert.That(_registrationPage.FirstNameInput.Displayed, Is.True);
        Assert.That(_registrationPage.EmailInput.Displayed, Is.True);
    }

    [Test]
    public void Test_RegisterWithSpecialCharactersInName()
    {
        _registrationPage.SelectUserType("Individual");
        _registrationPage.FillPersonalDetails("J@hn", "D0e", "Sm!th", "john@example.com", "+254712345678", "01/01/1990");
        _registrationPage.SubmitForm();

        // Assuming some validation message is shown for invalid input
        Assert.That(_driver.PageSource, Does.Contain("Invalid name")); // Adjust based on actual validation message
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    _driver.Quit();
    //}
}
