using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class TicketTests
{
    private IWebDriver driver;
    private TicketPage ticketPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/newticket");
        ticketPage = new TicketPage(driver);
    }

    [Test]
    public void VerifyJobTypeSelection()
    {
        ticketPage.SelectJobType("INSTALLATION");
        Assert.That(ticketPage.JobTypeDropdown.GetAttribute("value"), Is.EqualTo("INSTALLATION"));
    }

    [Test]
    public void VerifyValidVehicleRegNo()
    {
        ticketPage.EnterVehicleRegNo("KCD003H");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.VehicleRegNoInput)), Is.True);
    }

    [Test]
    public void VerifyValidEmail()
    {
        ticketPage.EnterEmail("user@example.com");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.EmailInput)), Is.True);
    }

    [Test]
    public void VerifyValidCustomerPhone()
    {
        ticketPage.EnterCustomerPhone("+254712345678");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.CustomerPhoneInput)), Is.True);
    }

    [Test]
    public void VerifyVehicleMakeSelection()
    {
        ticketPage.SelectVehicleMake("TOYOTA");
        Assert.That(ticketPage.VehicleMakeDropdown.GetAttribute("value"), Is.EqualTo("TOYOTA"));
    }

    [Test]
    public void VerifyPositiveLoanAmount()
    {
        ticketPage.EnterLoanAmount("1000");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.LoanAmountInput)), Is.True);
    }

    [Test]
    public void CheckRequiredFieldsValidationMessages()
    {
        ticketPage.SubmitForm();
        Assert.That(ticketPage.GetValidationMessage(ticketPage.JobTypeDropdown), Is.Not.EqualTo(string.Empty));
        Assert.That(ticketPage.GetValidationMessage(ticketPage.VehicleRegNoInput), Is.Not.EqualTo(string.Empty));
        Assert.That(ticketPage.GetValidationMessage(ticketPage.EmailInput), Is.Not.EqualTo(string.Empty));
        Assert.That(ticketPage.GetValidationMessage(ticketPage.CustomerPhoneInput), Is.Not.EqualTo(string.Empty));
        Assert.That(ticketPage.GetValidationMessage(ticketPage.CustomerNameInput), Is.Not.EqualTo(string.Empty));
    }

    [Test]
    public void VerifyEmptyJobTypeError()
    {
        ticketPage.SubmitForm();
        Assert.That(ticketPage.GetValidationMessage(ticketPage.JobTypeDropdown), Is.EqualTo("Please select a valid option."));
    }

    [Test]
    public void VerifyInvalidVehicleRegNo()
    {
        ticketPage.EnterVehicleRegNo("XYZ123");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.VehicleRegNoInput)), Is.False);
    }

    [Test]
    public void VerifyInvalidEmailFormat()
    {
        ticketPage.EnterEmail("user@com");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.EmailInput)), Is.False);
    }

    [Test]
    public void VerifyInvalidCustomerPhone()
    {
        ticketPage.EnterCustomerPhone("123456789");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.CustomerPhoneInput)), Is.False);
    }

    [Test]
    public void VerifyInvalidVehicleMake()
    {
        ticketPage.SelectVehicleMake("TOYOTA");
        ticketPage.SelectVehicleMake("INVALID_MAKE");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.VehicleMakeDropdown)), Is.False);
    }

    [Test]
    public void VerifyNegativeLoanAmount()
    {
        ticketPage.EnterLoanAmount("-1000");
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.LoanAmountInput)), Is.False);
    }

    [Test]
    public void VerifyEmptyCustomerNameError()
    {
        ticketPage.SubmitForm();
        Assert.That(ticketPage.GetValidationMessage(ticketPage.CustomerNameInput), Is.EqualTo(string.Empty));
    }

    [Test]
    public void VerifyRapidJobTypeChange()
    {
        ticketPage.SelectJobType("INSTALLATION");
        ticketPage.SelectJobType("REMOVAL");
        ticketPage.SelectJobType("VERIFICATION");
        Assert.That(ticketPage.JobTypeDropdown.GetAttribute("value"), Is.EqualTo("VERIFICATION"));
    }

    [Test]
    public void VerifyLongStringInSubject()
    {
        ticketPage.EnterCustomerName(new string('A', 101));
        Assert.That(string.IsNullOrEmpty(ticketPage.GetValidationMessage(ticketPage.CustomerNameInput)), Is.False);
    }

    [Test]
    public void VerifyTooltips()
    {
        // Assuming tooltips are implemented, you would need to hover over elements to check tooltips.
    }

    [Test]
    public void VerifyFormResponsiveness()
    {
        // Resize the browser window and check element accessibility.
    }

    [Test]
    public void VerifyAutofillFunctionality()
    {
        // Validate that previously filled data is retained.
    }

    [Test]
    public void VerifyDataRetentionOnNavigationAway()
    {
        // Simulate navigation away and back to check data retention.
    }

    [Test]
    public void VerifyBehaviorWithJavaScriptDisabled()
    {
        // This requires a different setup to disable JS.
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
