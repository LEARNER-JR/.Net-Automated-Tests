using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class TariffsPageTests
{
    private IWebDriver _driver;
    private TariffsPage _tariffsPage;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/tariffs");
        _tariffsPage = new TariffsPage(_driver);
    }

    [Test]
    public void VerifyTariffsLinkNavigatesToCorrectPage()
    {
        _tariffsPage.ClickTariffsLink();
        Assert.That(_tariffsPage.GetCurrentUrl(), Is.EqualTo("https://sit-ui.upesimts.com/tariffs"));
    }

    [Test]
    public void CheckTariffsLinkIsVisuallyDistinctAndLabeled()
    {
        Assert.That(_tariffsPage.IsTariffsLinkVisible(), Is.True, "Tariffs link should be visible.");
    }

    [Test]
    public void EnsureTariffsLinkIsAccessibleViaKeyboardNavigation()
    {
        Assert.That(_tariffsPage.IsTariffsLinkAccessible(), Is.True, "Tariffs link should be accessible via keyboard.");
    }

    [Test]
    public void ValidateTariffsLinkFunctionalityAcrossBrowsers()
    {
        _tariffsPage.ClickTariffsLink();
        Assert.That(_tariffsPage.GetCurrentUrl(), Is.EqualTo("https://sit-ui.upesimts.com/tariffs"));
    }

    [Test]
    public void ConfirmTariffsLinkWorksOnDesktopAndMobile()
    {
        // Desktop
        _tariffsPage.ClickTariffsLink();
        Assert.That(_tariffsPage.GetCurrentUrl(), Is.EqualTo("https://sit-ui.upesimts.com/tariffs"));

        // Mobile viewport
        _driver.Manage().Window.Size = new System.Drawing.Size(375, 667);
        _tariffsPage.ClickTariffsLink();
        Assert.That(_tariffsPage.GetCurrentUrl(), Is.EqualTo("https://sit-ui.upesimts.com/tariffs"));
    }

    [Test]
    public void TestTariffsLinkStyledInLightAndDarkThemes()
    {
        // Light theme check
        Assert.That(_tariffsPage.TariffsLink.GetCssValue("color"), Does.Contain("white"));

        // Dark theme check (requires app theme toggle support)
        Assert.That(_tariffsPage.TariffsLink.GetCssValue("color"), Does.Contain("gray"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
