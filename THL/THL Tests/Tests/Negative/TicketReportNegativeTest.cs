using NUnit.Framework;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TicketReportNegativeTest : BaseTest
{
    private TicketReportNegativePage _page;

    [SetUp]
    public void Setup()
    {
        driver.Navigate().GoToUrl(baseUrl + "tickets_report");
        _page = new TicketReportNegativePage(driver);
    }

    [Test]
    public void Test_FormSubmission_WithoutSelections_ShowsValidationMessages()
    {
        _page.ClickExecute();
        Assert.That(_page.IsValidationMessageDisplayed(),
            Is.True, "Validation message should appear when submitting without selections.");
    }

    [Test]
    public void Test_FormSubmission_InvalidDateFormat()
    {
        _page.SetInvalidDateRange("invalid date");
        _page.ClickExecute();
        Assert.That(_page.IsErrorMessageDisplayed(),
            Is.True, "Error message should appear for invalid date format.");
    }

    [Test]
    public void Test_InvalidFiltrationOption_DoesNotCrash()
    {
        _page.SelectInvalidFiltration("Invalid Option");
        Assert.That(driver.Url.Contains("tickets_report"),
            Is.True, "System should stay on tickets report page when invalid filter is used.");
    }

    [Test]
    public void Test_EmptyTokenValue_FormSubmission_Rejected()
    {
        _page.ClearTokenValue();
        _page.ClickExecute();
        Assert.That(_page.IsValidationMessageDisplayed(),
            Is.True, "Form should be rejected when token value is empty.");
    }

    [Test]
    public void Test_SpecialCharactersInDateRange()
    {
        _page.SetInvalidDateRange("!@#$%^&*()");
        _page.ClickExecute();
        Assert.That(_page.IsErrorMessageDisplayed(),
            Is.True, "Error message should appear for special characters in date range.");
    }
}
