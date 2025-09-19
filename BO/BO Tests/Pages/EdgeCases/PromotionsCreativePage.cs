using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class PromotionCreativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public PromotionCreativePage(IWebDriver driver)
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

    public void NavigateToPromotionsPage()
    {
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/promotions/create");
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("promotions"));
    }
    public void ClickAddPromotionButton()
    {
        var addPromotionBtn = _wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                By.XPath("//button[normalize-space()='Add Promotion']")
            )
        );
        addPromotionBtn.Click();
    }

    public void WaitForPageLoad()
    {
        _wait.Until(driver =>
            ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete"
        );
    }

    //public void WaitForPageLoad()
    //{
    //    _wait.Until(driver =>
    //        ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete"
    //    );

    //    // If jQuery is present, wait for AJAX requests too
    //    try
    //    {
    //        _wait.Until(driver =>
    //            (bool)((IJavaScriptExecutor)driver).ExecuteScript("return (typeof jQuery === 'undefined') || (jQuery.active === 0)")
    //        );
    //    }
    //    catch (WebDriverTimeoutException)
    //    {
    //        // Ignore if no jQuery
    //    }
    //}

    internal bool IsValidationMessageDisplayed()
    {
        throw new NotImplementedException();
    }
    public int GetPromotionCount()
    {
        var promos = _driver.FindElements(By.CssSelector("div table tbody tr"));
        return promos.Count;
    }

    public string GetSelectedPromotionType()
    {
        return PromotionTypeDropdown.Text.Trim();
    }

    public string GetSelectedCondition()
    {
        return ConditionDropdown.Text.Trim();
    }

    public string GetSelectedPlatform()
    {
        return PlatformDropdown.Text.Trim();
    }

    public bool IsSubmitButtonEnabled()
    {
        throw new NotImplementedException();
    }
    public bool IsSuccessMessageDisplayed()
    {
        try
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/promotions"));

            var success = _wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.XPath("//p[contains(text(),'Promotion Created Successfully')]")
                )
            );

            return success.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void SubmitForm()
    {
        SubmitButton.Click();
    }
}