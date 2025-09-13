using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class PromotionPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public PromotionPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement PromotionNameInput => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("promotionName")));
    public IWebElement PromotionTypeDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("headlessui-listbox-button-:r4n:")));
    public IWebElement ConditionDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("headlessui-listbox-button-:r4q:")));
    public IWebElement PlatformDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("headlessui-listbox-button-:r4t:")));
    public IWebElement ChannelDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("headlessui-listbox-button-:r50:")));
    public IWebElement DiscountTypeDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("headlessui-listbox-button-:r53:")));
    public IWebElement SubmitButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("button[type='submit']")));

    public void FillPromotionName(string name)
    {
        PromotionNameInput.Clear();
        PromotionNameInput.SendKeys(name);
    }

    public void SelectPromotionType(string type)
    {
        PromotionTypeDropdown.Click();
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[text()='{type}']"))).Click();
    }

    public void SelectCondition(string condition)
    {
        ConditionDropdown.Click();
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[text()='{condition}']"))).Click();
    }

    public void SelectPlatform(string platform)
    {
        PlatformDropdown.Click();
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[text()='{platform}']"))).Click();
    }

    public void SelectChannel(string channel)
    {
        ChannelDropdown.Click();
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[text()='{channel}']"))).Click();
    }

    public void SelectDiscountType(string discountType)
    {
        DiscountTypeDropdown.Click();
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[text()='{discountType}']"))).Click();
    }

    public void SubmitForm()
    {
        SubmitButton.Click();
    }
}