using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TicketReportCreativeTest : BaseTest
{
    private TicketReportCreativePage _page;

    [SetUp]
    public void Setup()
    {
        driver.Navigate().GoToUrl(baseUrl + "tickets_report");
        _page = new TicketReportCreativePage(driver);
    }

    [Test]
    public void Test_RapidFiltrationChanges_NoErrors()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        Assert.That(_page.GetSelectedFiltration(), Is.EqualTo("By Vehicle Reg. No"));

        _page.SelectFiltration("All");
        Assert.That(_page.GetSelectedFiltration(), Is.EqualTo("All"));

        _page.SelectFiltration("By Valuer Name");
        Assert.That(_page.GetSelectedFiltration(), Is.EqualTo("By Valuer Name"));
    }

    [Test]
    public void Test_ResponsiveForm_CheckElements()
    {
        driver.Manage().Window.Size = new Size(800, 600);
        // TODO: Add assertions to check elements are visible & usable
    }

    [Test]
    public void Test_MultipleVehiclesSelection_Processing()
    {
        _page.SelectFiltration("By Vehicle Reg. No");
        Assert.That(_page.GetSelectedFiltration(), Is.EqualTo("By Vehicle Reg. No"));

        // TODO: Add logic to select multiple vehicles and verify
    }
}
