using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class CreateTransactionTests
{
    private IWebDriver _driver;
    private CreateTransactionPage _createTransactionPage;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/transactions/create#senderDetails");
        _createTransactionPage = new CreateTransactionPage(_driver);
    }

    [Test]
    public void Test_NavigateToCreateTransactionPage()
    {
        Assert.IsTrue(_createTransactionPage.IsOnCreateTransactionPage(), "User is not on Create Transaction page.");
    }

    [Test]
    public void Test_FillAndSubmitTransactionForm()
    {
        _createTransactionPage.FillSenderDetails("John Doe");
        _createTransactionPage.FillSenderAmount("200");
        _createTransactionPage.FillReceiverAmount("200");
        _createTransactionPage.ClickPreviewTransaction();
        // Assert that the transaction summary is displayed correctly (add appropriate assertion based on the summary page)
    }

    [Test]
    public void Test_CalculateRateUpdatesFees()
    {
        _createTransactionPage.FillSenderAmount("200");
        _createTransactionPage.FillReceiverAmount("200");
        _createTransactionPage.ClickCalculateRate();
        // Assert that the fees and total amount are updated correctly (add appropriate assertion)
    }

    [Test]
    public void Test_SelectCountryDropdown()
    {
        // Implement the country selection logic and assertions (add appropriate selector and action)
    }

    [Test]
    public void Test_UploadSupportingDocument()
    {
        _createTransactionPage.UploadSupportingDocument("path/to/document.pdf");
        // Assert that the document was uploaded successfully (add appropriate assertion)
    }

    [Test]
    public void Test_NewBeneficiaryCheckbox()
    {
        _createTransactionPage.CheckNewBeneficiaryCheckbox();
        // Assert that the associated fields are enabled (add appropriate assertion)
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}