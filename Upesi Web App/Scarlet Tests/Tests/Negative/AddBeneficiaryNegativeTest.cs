using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class AddBeneficiaryNegativeTests
{
    private IWebDriver driver;
    private AddBeneficiaryNegativePage addBeneficiaryPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/add-beneficiary");
        addBeneficiaryPage = new AddBeneficiaryNegativePage(driver);
    }

    [Test]
    public void TestClickPlusIconWhenNotLoggedIn()
    {
        addBeneficiaryPage.ClickPlusIcon();

        Assert.That(addBeneficiaryPage.IsErrorMessageDisplayed(),
            Is.True, "Error message is not displayed when clicking plus icon while not logged in.");
    }

    [Test]
    public void TestClickPlusIconDuringLoadingState()
    {
        // Simulate loading state
        // e.g. ToggleLoadingState();

        addBeneficiaryPage.ClickPlusIcon();

        Assert.That(addBeneficiaryPage.IsFormDisplayed(),
            Is.False, "Form should not be displayed during loading state.");
    }

    [Test]
    public void TestIncompleteFormSubmission()
    {
        addBeneficiaryPage.FillBeneficiaryForm(""); // Leaving the form incomplete
        addBeneficiaryPage.SubmitForm();

        Assert.That(addBeneficiaryPage.IsErrorMessageDisplayed(),
            Is.True, "Error message is not displayed for incomplete form submission.");
    }

    [Test]
    public void TestMultipleClicksOnPlusIcon()
    {
        addBeneficiaryPage.ClickPlusIcon();
        Assert.That(addBeneficiaryPage.IsFormDisplayed(),
            Is.True, "Form should be displayed after first click.");

        addBeneficiaryPage.ClickPlusIcon();
        Assert.That(addBeneficiaryPage.IsFormDisplayed(),
            Is.True, "Form should still be displayed after second click.");
        // TODO: Optionally check that only one form instance exists.
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
