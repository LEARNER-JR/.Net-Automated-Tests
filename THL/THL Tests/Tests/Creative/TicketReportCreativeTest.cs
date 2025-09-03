using NUnit.Framework.Legacy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TicketReport_CreativeTests : BaseTest
{
    private TicketReportPage _page;

    [SetUp]
    public void Setup()
    {
        driver.Navigate().GoToUrl(baseUrl + "https://sit-portal.trackinghub.co.ke/tickets_report");
        _page = new TicketReportPage(driver);
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
    public void Test_ResponsiveForm_CheckElements()
    {
        driver.Manage().Window.Size = new Size(800, 600);
        // Add assertions to verify elements are visible and functional
    }

    [Test]
    public void Test_MultipleVehiclesSelection_Processing()
    {
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
