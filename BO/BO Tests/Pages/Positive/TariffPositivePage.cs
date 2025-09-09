using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TariffsPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public TariffsPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement TariffsLink => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/tariffs']")));

    public void ClickTariffsLink()
    {
        TariffsLink.Click();
    }

    public string GetCurrentUrl()
    {
        return _driver.Url;
    }

    public bool IsTariffsLinkVisible()
    {
        return TariffsLink.Displayed && TariffsLink.Text == "Tariffs";
    }

    public bool IsTariffsLinkAccessible()
    {
        return TariffsLink.GetAttribute("tabindex") == "0";
    }
}