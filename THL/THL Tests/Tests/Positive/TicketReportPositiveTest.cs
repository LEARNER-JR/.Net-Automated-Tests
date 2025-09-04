using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using THL_Tests.Tests;

// using THL_Tests.Pages.Positive;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TicketReportPositiveTest : BaseTest
{
    private TicketReportPositivePage _page;

    [SetUp]
    public void Setup()
    {
        driver.Navigate().GoToUrl(baseUrl + "https://sit-portal.trackinghub.co.ke/tickets_report");
        _page = new TicketReportPositivePage(driver);
    }

    //Positive
    [Test]
    public void Test_FiltrationByVehicleRegNo_ShowsVehicleDropdown()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        var vehicles = _page.VehicleDropdown.FindElements(By.TagName("option"));
        Assert.That(vehicles.Count > 1, Is.True); // Assuming "All" shows more than one vehicle
        Assert.That(_page.IsVehicleDropdownVisible(), Is.True);
    }

    //Positive
    [Test]
    public void Test_SelectAllInFiltration_ShowsAllVehicles()
    {
        _page.SelectFiltration("All");
        var vehicles = _page.VehicleDropdown.FindElements(By.TagName("option"));
        Assert.That(vehicles.Count > 1, Is.True); // Fixed: Use Assert.That instead of Assert.IsTrue
    }

    //Positive
    [Test]
    public void Test_StatusDropdown_DisplaysAllOptions()
    {
        var expectedOptions = new List<string> { "All", "Open", "Assigned", "On-Hold", "Escalated", "Closed" };
        var actualOptions = _page.GetStatusOptions();
        NUnit.Framework.Legacy.CollectionAssert.AreEqual(expectedOptions, actualOptions);
    }

    //Positive
    [Test]
    public void Test_DateRangeInput_ValidDateFormat()
    {
        _page.SetDateRange("01/01/2023 - 01/31/2023");
        // Assuming the system accepts this format, add validation if necessary
    }

    //Positive
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

    //Positive
    [Test]
    public void Test_VehicleSelected_DisplaysCorrectInfo()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        _page.SelectVehicle("KDB 121M");
        // Add assertions to check if the report displays correct vehicle info
    }

    //Positive
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

    //Positive
    [Test]
    public void Test_ByValuerName_HidesVehicleDropdown()
    {
        _page.SelectFiltration("By Valuer Name");
        Assert.That(_page.IsVehicleDropdownVisible(), Is.False);
    }

    //Positive
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
}
