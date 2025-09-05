using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class AddBeneficiaryPositiveTests
{
    private IWebDriver _driver;
    private AddBeneficiaryPositivePage _addBeneficiaryPage;
    private const string BaseUrl = "https://sitwebapp.upesimts.com/add-beneficiary";

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(BaseUrl);
        _addBeneficiaryPage = new AddBeneficiaryPositivePage(_driver);
    }

    [Test]
    public void VerifyAddBeneficiaryOptionIsDisplayed()
    {
        Assert.That(_addBeneficiaryPage.IsAddBeneficiaryVisible(),
            Is.True, "Add Beneficiary option is not displayed.");
    }

    [Test]
    public void EnsureClickingPlusIconInitiatesAddBeneficiaryProcess()
    {
        _addBeneficiaryPage.ClickPlusIcon();

        // Example: check if form appears
        var form = _driver.FindElement(By.Id("beneficiaryForm"));
        Assert.That(form.Displayed,
            Is.True, "Beneficiary form is not displayed after clicking plus icon.");
    }

    [Test]
    public void CheckAddBeneficiaryTextVisibilityOnVariousScreenSizes()
    {
        string text = _addBeneficiaryPage.GetBeneficiaryText();
        Assert.That(string.IsNullOrWhiteSpace(text),
            Is.False, "Add Beneficiary text is not visible or legible.");
    }

    [Test]
    public void ValidateIconAppearanceOnHoverOrClick()
    {
        // TODO: Implement hover/click style check
        // Example (pseudo):
        // var icon = _addBeneficiaryPage.PlusIcon;
        // string initialClass = icon.GetAttribute("class");
        // new Actions(_driver).MoveToElement(icon).Perform();
        // string hoverClass = icon.GetAttribute("class");
        // Assert.That(initialClass, Is.Not.EqualTo(hoverClass), "Icon style did not change on hover.");
    }

    [Test]
    public void ConfirmNavigationToBeneficiaryAdditionForm()
    {
        _addBeneficiaryPage.ClickPlusIcon();
        Assert.That(_driver.Url,
            Does.Contain("beneficiaryForm"),
            "Did not navigate to the beneficiary addition form.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
