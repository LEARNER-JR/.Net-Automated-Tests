using OpenQA.Selenium;

public class TariffNegativePage
{
    private readonly IWebDriver _driver;

    // Use a private field for the element locator
    private readonly By _tariffsLinkLocator = By.XPath("//a[@href='/tariffs']");

    public TariffNegativePage(IWebDriver driver)
    {
        _driver = driver;
    }

    // A public property that finds and returns the element
    public IWebElement TariffsLink => _driver.FindElement(_tariffsLinkLocator);

    public void ClickTariffsLink()
    {
        TariffsLink.Click();
    }
}