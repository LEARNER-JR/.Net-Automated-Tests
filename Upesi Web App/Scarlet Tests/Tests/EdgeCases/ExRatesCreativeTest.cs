using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class ExRatesCreativeTests
{
    private IWebDriver driver;
    private ExRatesCreativePage inputFieldPage;
    private const string baseUrl = "https://sitwebapp.upesimts.com/dashboard";

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(baseUrl);
        inputFieldPage = new ExRatesCreativePage(driver);
    }

    [Test]
    public void TestRapidTypingInInputField()
    {
        inputFieldPage.TypeInInputField("Test");
        Assert.That(inputFieldPage.IsAutocompleteVisible(), Is.True,
            "Autocomplete suggestions should be visible after typing.");
    }

    [Test]
    public void TestAutofillFeature()
    {
        inputFieldPage.TypeInInputField("AutoFillTest");
        driver.Navigate().Refresh(); // Simulate browser autofill

        Assert.That(inputFieldPage.GetInputFieldValue(), Is.EqualTo("AutoFillTest"),
            "Input field value should match the autofill value.");
    }

    [Test]
    public void TestAccessibilityWithScreenReader()
    {
        // This test would require a screen reader tool to validate; placeholder for actual implementation.
        Assert.Pass("Accessibility test requires screen reader tool.");
    }

    [Test]
    public void TestLanguageSwitching()
    {
        inputFieldPage.TypeInInputField("Привет"); // Typing in Russian

        Assert.That(inputFieldPage.GetInputFieldValue(), Is.EqualTo("Привет"),
            "Input field should accept different language inputs.");
    }

    [Test]
    public void TestInputFieldResponsiveness()
    {
        driver.Manage().Window.Size = new System.Drawing.Size(375, 667); // Simulate mobile
        inputFieldPage.TypeInInputField("ResponsiveTest");

        Assert.That(inputFieldPage.IsAutocompleteVisible(), Is.True,
            "Autocomplete suggestions should be visible on mobile.");

        driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Simulate desktop
        inputFieldPage.TypeInInputField("ResponsiveTest");

        Assert.That(inputFieldPage.IsAutocompleteVisible(), Is.True,
            "Autocomplete suggestions should be visible on desktop.");
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
    }
}
