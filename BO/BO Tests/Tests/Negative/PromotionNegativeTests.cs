using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BO_Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
[TestFixture]
public class PromotionNegativeTests : BaseTest
{
    private IWebDriver driver;
    private PromotionNegativePage promotionPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/promotions/create");
        promotionPage = new PromotionNegativePage(driver);
    }

    [Test]
    public void SubmitForm_EmptyPromotionName_ShowsError()
    {
        promotionPage.EnterPromotionName("");
        promotionPage.ClickSubmit();
        Assert.That(promotionPage.GetErrorMessage(), Does.Contain("Promotion name is required"));
    }

    [Test]
    public void SubmitForm_InvalidPromotionType_PreventsSubmission()
    {
        promotionPage.SelectPromotionType("InvalidType");
        promotionPage.ClickSubmit();
        Assert.That(promotionPage.GetErrorMessage(), Does.Contain("Invalid promotion type"));
    }

    [Test]
    public void SubmitForm_NegativeTransactionAmount_ShowsError()
    {
        promotionPage.SetTransactionAmount(-100);
        promotionPage.ClickSubmit();
        Assert.That(promotionPage.GetErrorMessage(), Does.Contain("Transaction amount must be positive"));
    }

    [Test]
    public void SubmitForm_EndDateEarlierThanStartDate_ShowsError()
    {
        promotionPage.SetStartDate(DateTime.Now.AddDays(1));
        promotionPage.SetEndDate(DateTime.Now);
        promotionPage.ClickSubmit();
        Assert.That(promotionPage.GetErrorMessage(), Does.Contain("End date must be after start date"));
    }

    [Test]
    public void SubmitForm_UncheckSingleUse_ProcessesCorrectly()
    {
        promotionPage.UncheckSingleUse();
        promotionPage.ClickSubmit();
        Assert.That(promotionPage.GetErrorMessage(), Does.Contain("Promotion processed successfully"));
    }

    [Test]
    public void SubmitButton_Disabled_WhenRequiredFieldsMissing()
    {
        promotionPage.EnterPromotionName("");
        Assert.That(promotionPage.IsSubmitButtonEnabled(), Is.False);
    }

    //[TearDown]
    //public void TearDown()
    //{
    //    driver.Quit();
    //}
}
