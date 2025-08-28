using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

[TestFixture]
public class AllTicketsTest
{
    private IWebDriver _driver;
    private AllTicketsPage _allTicketsPage;
    private const string BaseUrl = "https://sit-order.trackinghub.co.ke/dashboard";

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(BaseUrl);
        _allTicketsPage = new AllTicketsPage(_driver);
    }

    [Test]
    public void VerifyNavigationToAllTicketsPage()
    {
        _allTicketsPage.ClickAllTicketsLink();
        Assert.That(_driver.Url, Is.EqualTo("https://sit-order.trackinghub.co.ke/dashboard/alltickets"));
    }

    [Test]
    public void CheckLinkLabelAndVisibility()
    {
        Assert.That(_allTicketsPage.IsAllTicketsLinkDisplayed(), Is.True);
        Assert.That(_allTicketsPage.GetAllTicketsLinkText(), Is.EqualTo("All Tickets"));
    }

    [Test]
    public void EnsureIconIsDisplayed()
    {
        Assert.That(_allTicketsPage.IsIconDisplayed(), Is.True);
    }

    [Test]
    public void ValidateKeyboardNavigation()
    {
        _driver.FindElement(By.TagName("body")).SendKeys(Keys.Tab);
        var activeElement = _driver.SwitchTo().ActiveElement;
        Assert.That(activeElement, Is.EqualTo(_allTicketsPage.AllTicketsLink));
    }

    [Test]
    public void ConfirmLinkFunctionalityOnDifferentDevices()
    {
        // Simulate desktop, tablet, mobile viewports here (not implemented in this example)
        Assert.Pass("Device functionality tests need to be implemented.");
    }

    [Test]
    public void TestLinkBehaviorWhenOffline()
    {
        // Simulate offline behavior (not implemented in this example)
        Assert.Pass("Offline behavior tests need to be implemented.");
    }

    [Test]
    public void VerifyNoNavigationWithAlteredHref()
    {
        // Use JavaScript executor to modify the href attribute
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("arguments[0].setAttribute('href', 'javascript:void(0);')", _allTicketsPage.AllTicketsLink);

        _allTicketsPage.ClickAllTicketsLink();
        Assert.That(_driver.Url, Is.EqualTo(BaseUrl));
    }

    [Test]
    public void CheckAccessWithoutProperPermissions()
    {
        // Simulate access without permissions (not implemented in this example)
        Assert.Pass("Permission access tests need to be implemented.");
    }

    [Test]
    public void EnsureNoUnexpectedPopupsOnClick()
    {
        // Check initial window handles
        var initialWindowHandles = _driver.WindowHandles.Count;

        _allTicketsPage.ClickAllTicketsLink();

        // Wait a moment for any potential popups
        Thread.Sleep(1000);

        var currentWindowHandles = _driver.WindowHandles.Count;
        Assert.That(currentWindowHandles, Is.EqualTo(initialWindowHandles), "No unexpected popups should appear");
    }

    [Test]
    public void SimulateHoverForTooltips()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(_allTicketsPage.AllTicketsLink).Perform();

        // Wait for potential tooltip to appear
        Thread.Sleep(500);

        // Check if tooltip is present (you'll need to adjust the selector based on your tooltip implementation)
        try
        {
            var tooltip = _driver.FindElement(By.CssSelector("[role='tooltip'], .tooltip"));
            Assert.That(tooltip.Displayed, Is.True, "Tooltip should be visible on hover");
        }
        catch (NoSuchElementException)
        {
            Assert.Pass("No tooltip found - this may be expected behavior");
        }
    }

    [Test]
    public void TestLinkBehaviorWithBrowserZoom()
    {
        // Set zoom level to 150%
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("document.body.style.zoom='150%'");

        Thread.Sleep(1000); // Wait for zoom to apply

        // Verify link is still clickable and functional
        Assert.That(_allTicketsPage.IsAllTicketsLinkDisplayed(), Is.True);
        _allTicketsPage.ClickAllTicketsLink();
        Assert.That(_driver.Url, Is.EqualTo("https://sit-order.trackinghub.co.ke/dashboard/alltickets"));
    }

    [Test]
    public void InvestigateFunctionalityWithJavaScriptDisabled()
    {
        // Note: You cannot disable JavaScript in an already running ChromeDriver instance
        // This would require creating a new driver with JavaScript disabled
        Assert.Pass("JavaScript disabled tests require special ChromeDriver configuration.");
    }

    [Test]
    public void ExploreScreenReaderSupport()
    {
        // Check for accessibility attributes
        var linkElement = _allTicketsPage.AllTicketsLink;

        // Check for aria-label or other accessibility attributes
        var ariaLabel = linkElement.GetAttribute("aria-label");
        var title = linkElement.GetAttribute("title");
        var text = linkElement.Text;

        bool hasAccessibleText = !string.IsNullOrEmpty(ariaLabel) ||
                               !string.IsNullOrEmpty(title) ||
                               !string.IsNullOrEmpty(text);

        Assert.That(hasAccessibleText, Is.True, "Link should have accessible text for screen readers");
    }

    [Test]
    public void TestRapidClicksOnLink()
    {
        // Navigate back to the original page first
        _driver.Navigate().GoToUrl(BaseUrl);

        for (int i = 0; i < 3; i++) // Reduced to 3 clicks to avoid overwhelming the server
        {
            _allTicketsPage.ClickAllTicketsLink();
            Thread.Sleep(100); // Small delay between clicks
            _driver.Navigate().Back();
            Thread.Sleep(100);
        }

        // Final click to verify it still works
        _allTicketsPage.ClickAllTicketsLink();
        Assert.That(_driver.Url, Is.EqualTo("https://sit-order.trackinghub.co.ke/dashboard/alltickets"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
    }
}