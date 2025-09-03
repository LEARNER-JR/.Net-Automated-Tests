using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using THL_Tests.Pages.Negative;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TicketReportNegativeTest : BaseTest
{
    private TicketReportNegativePage _page;

    [SetUp]
    public void Setup()
    {
        driver.Navigate().GoToUrl(baseUrl + "https://sit-portal.trackinghub.co.ke/tickets_report");
        _page = new TicketReportNegativePage(driver);
    }

    [Test]
    public void Test_FormSubmission_WithoutSelections_ShowsValidationMessages()
    {
        _page.ClickExecute();
        // Add assertions to verify validation messages
    }

    [Test]
    public void Test_FormSubmission_InvalidDateFormat()
    {
        _page.SetDateRange("invalid date");
        _page.ClickExecute();
        // Add assertions to verify how the system responds
    }

    [Test]
    public void Test_InvalidFiltrationOption_DoesNotCrash()
    {
        _page.SelectFiltration("Invalid Option");
        // Add assertions to ensure the system handles it gracefully
    }

    [Test]
    public void Test_EmptyTokenValue_FormSubmission_Rejected()
    {
        // Assuming a way to set the token value to empty
        // _page.SetTokenValue(string.Empty);
        _page.ClickExecute();
        // Add assertions to ensure the request is rejected
    }

    [Test]
    public void Test_SpecialCharactersInDateRange()
    {
        _page.SetDateRange("!@#$%^&*()");
        _page.ClickExecute();
        // Add assertions to verify how the system responds
    }

    [TearDown]
    public void Cleanup()
    {
        driver.Quit();
    }
}
