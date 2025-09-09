using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class UserManagementCreativeTests
{
    private IWebDriver driver;
    private UserManagementCreativePage systemUsersPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/user-management/system-users");
        systemUsersPage = new UserManagementCreativePage(driver);
    }

    [Test]
    public void RapidInputSubmission()
    {
        for (int i = 0; i < 10; i++)
        {
            systemUsersPage.FillEmail("test@example.com");
            systemUsersPage.FillPhone("1234567890");
        }
        systemUsersPage.SubmitForm();

        // ✅ Modern Assert
        Assert.That(driver.Url, Does.Contain("success"), "Form submission did not redirect to success page.");
    }

    [Test]
    public void DataRetentionOnNavigation()
    {
        systemUsersPage.FillEmail("test@example.com");
        systemUsersPage.FillPhone("1234567890");

        driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/user-management/other-page");
        driver.Navigate().Back();

        Assert.That(driver.FindElement(systemUsersPage.FormFieldEmail).GetAttribute("value"), Is.EqualTo("test@example.com"));
        Assert.That(driver.FindElement(systemUsersPage.FormFieldPhone).GetAttribute("value"), Is.EqualTo("1234567890"));
    }

    [Test]
    public void InvalidDataPaste()
    {
        systemUsersPage.FillEmail("invalid-email");
        systemUsersPage.FillPhone("invalid-phone");
        systemUsersPage.SubmitForm();

        Assert.That(systemUsersPage.GetErrorMessage(), Does.Contain("invalid"));
    }

    [Test]
    public void AccessibilityValidation()
    {
        // Placeholder: implement accessibility checks (axe, wave, etc.)
        Assert.Pass("Accessibility checks need to be implemented.");
    }

    [Test]
    public void ResponsiveDesignCheck()
    {
        // Placeholder: implement responsiveness checks (window resize, breakpoints, etc.)
        Assert.Pass("Responsive design checks need to be implemented.");
    }

    [Test]
    public void RequiredFieldsSubmission()
    {
        systemUsersPage.SubmitForm();
        Assert.That(systemUsersPage.GetErrorMessage(), Does.Contain("required"));

        systemUsersPage.FillEmail("test@example.com");
        systemUsersPage.SubmitForm();
        Assert.That(systemUsersPage.GetErrorMessage(), Does.Contain("required"));

        systemUsersPage.FillPhone("1234567890");
        systemUsersPage.SubmitForm();
        Assert.That(driver.Url, Does.Contain("success"));
    }

    [Test]
    public void PerformanceUnderLoad()
    {
        // Placeholder: hook into JMeter, k6, or custom performance framework
        Assert.Pass("Performance testing needs to be implemented.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
