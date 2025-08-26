using NUnit.Framework.Legacy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;
using System.Drawing;

[TestFixture]
public class TicketReportTest : BaseTest
{
    private TicketReportPage _page;

    [SetUp]
    public void Setup()
    {
        driver.Navigate().GoToUrl(baseUrl + "https://sit-portal.trackinghub.co.ke/tickets_report");
        _page = new TicketReportPage(driver);
    }

    [Test]
    public void Test_FiltrationByVehicleRegNo_ShowsVehicleDropdown()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        var vehicles = _page.VehicleDropdown.FindElements(By.TagName("option"));
        Assert.That(vehicles.Count > 1, Is.True); // Assuming "All" shows more than one vehicle
        Assert.That(_page.IsVehicleDropdownVisible(), Is.True);
    }

    [Test]
    public void Test_SelectAllInFiltration_ShowsAllVehicles()
    {
        _page.SelectFiltration("All");
        var vehicles = _page.VehicleDropdown.FindElements(By.TagName("option"));
        Assert.That(vehicles.Count > 1, Is.True); // Fixed: Use Assert.That instead of Assert.IsTrue
    }

    [Test]
    public void Test_StatusDropdown_DisplaysAllOptions()
    {
        var expectedOptions = new List<string> { "All", "Open", "Assigned", "On-Hold", "Escalated", "Closed" };
        var actualOptions = _page.GetStatusOptions();
        NUnit.Framework.Legacy.CollectionAssert.AreEqual(expectedOptions, actualOptions);
    }

    [Test]
    public void Test_DateRangeInput_ValidDateFormat()
    {
        _page.SetDateRange("01/01/2023 - 01/31/2023");
        // Assuming the system accepts this format, add validation if necessary
    }

    [Test]
    public void Test_ExecuteButton_SubmitsForm()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        _page.SelectVehicle("KDB 121M");
        _page.SelectStatus("Open");
        _page.SetDateRange("01/01/2023 - 01/31/2023");
        _page.ClickExecute();
        Assert.That(_page.GetCurrentUrl(), Is.EqualTo("https://sit-portal.trackinghub.co.ke/tickets_report"));
    }

    [Test]
    public void Test_VehicleSelected_DisplaysCorrectInfo()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        _page.SelectVehicle("KDB 121M");
        // Add assertions to check if the report displays correct vehicle info
    }

    [Test]
    public void Test_FormSubmission_ValidFields_ReturnsResults()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        _page.SelectVehicle("KDB 121M");
        _page.SelectStatus("Open");
        _page.SetDateRange("01/01/2023 - 01/31/2023");
        _page.ClickExecute();
        // Add assertions to verify results
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
    public void Test_ByValuerName_HidesVehicleDropdown()
    {
        _page.SelectFiltration("By Valuer Name");
        Assert.That(_page.IsVehicleDropdownVisible(), Is.False);
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
    public void Test_RapidFiltrationChanges_NoErrors()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        _page.SelectFiltration("All");
        _page.SelectFiltration("By Valuer Name");
        // Check for errors or state issues
    }

    [Test]
    public void Test_SpecialCharactersInDateRange()
    {
        _page.SetDateRange("!@#$%^&*()");
        _page.ClickExecute();
        // Add assertions to verify how the system responds
    }

    [Test]
    public void Test_ResponsiveForm_CheckElements()
    {
        driver.Manage().Window.Size = new Size(800, 600);
        // Add assertions to verify elements are visible and functional
    }

    [Test]
    public void Test_SuccessMessage_OnSuccessfulSubmission()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        _page.SelectVehicle("KDB 121M");
        _page.SelectStatus("Open");
        _page.SetDateRange("01/01/2023 - 01/31/2023");
        _page.ClickExecute();
        // Add assertions to verify success message and redirection
    }

    [Test]
    public void Test_MultipleVehiclesSelection_Processing()
    {
        // Assuming the system allows multiple selections
        _page.SelectFiltration("By Vehicle Reg. No");
        // Add logic to select multiple vehicles
        // Add assertions to verify how the system processes this input
    }

    [TearDown]
    public void Cleanup()
    {
        driver.Quit();
    }
}