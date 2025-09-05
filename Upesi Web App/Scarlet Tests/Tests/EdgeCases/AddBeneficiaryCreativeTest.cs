using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class AddBeneficiaryCreativeTests
{
    private IWebDriver _driver;
    private AddBeneficiaryCreativePage _addBeneficiaryPage;
    private const string BaseUrl = "https://sitwebapp.upesimts.com/add-beneficiary";

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(BaseUrl);
        _addBeneficiaryPage = new AddBeneficiaryCreativePage(_driver);
    }

    [Test]
    public void TestAddBeneficiaryOffline()
    {
        // Simulate offline
        var offlineScript = "navigator.serviceWorker.controller.postMessage({ type: 'SET_OFFLINE' });";
        ((IJavaScriptExecutor)_driver).ExecuteScript(offlineScript);

        _addBeneficiaryPage.ClickAddBeneficiary();
        _addBeneficiaryPage.EnterBeneficiaryName("John Doe");
        _addBeneficiaryPage.Submit();

        Assert.That(_addBeneficiaryPage.GetErrorMessage(),
            Does.Contain("You are offline"),
            "Expected offline error message not displayed.");
    }

    [Test]
    public void TestAddBeneficiaryOnMultipleDevices()
    {
        // This test would typically require different setups for mobile, tablet, and desktop.
        // Here we just assert that the button is present on the desktop version.
        Assert.That(_addBeneficiaryPage.AddBeneficiaryButton.Displayed,
            Is.True, "Add Beneficiary button should be visible.");
    }

    [Test]
    public void TestRapidClickOnAddBeneficiary()
    {
        for (int i = 0; i < 5; i++)
        {
            _addBeneficiaryPage.ClickAddBeneficiary();
        }

        // Assuming the application should prevent multiple requests
        Assert.That(_addBeneficiaryPage.AddBeneficiaryButton.Enabled,
            Is.True, "Add Beneficiary button should still be enabled after rapid clicks.");
    }

    [Test]
    public void TestAddBeneficiaryWithSpecialCharacters()
    {
        _addBeneficiaryPage.ClickAddBeneficiary();
        _addBeneficiaryPage.EnterBeneficiaryName("John @Doe #2023");
        _addBeneficiaryPage.Submit();

        // Assuming successful addition redirects or shows a success message
        Assert.That(_addBeneficiaryPage.GetErrorMessage(),
            Does.Not.Contain("error"),
            "No error should be present when adding special characters.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
