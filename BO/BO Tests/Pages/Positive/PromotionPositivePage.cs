using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class PromotionPositivePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public PromotionPositivePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    public string BaseUrl => "https://sit-ui.upesimts.com/promotions";

    public IWebElement PromotionNameInput => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("promotionName")));
    public IWebElement PromotionTypeDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("headlessui-listbox-button-:r4n:")));
    public IWebElement MinimumTransactionInput => _driver.FindElement(By.Name("minimumTransaction"));
    public IWebElement DiscountAmountInput => _driver.FindElement(By.Name("discountAmount"));
    public IWebElement StartDateInput => _driver.FindElement(By.Name("startDate"));
    public IWebElement EndDateInput => _driver.FindElement(By.Name("endDate"));
    public IWebElement SingleUseCheckbox => _driver.FindElement(By.Name("singleUse"));
    public IWebElement AddPromotionButton => _driver.FindElement(By.Id("addPromotionButton"));

    public void NavigateToPromotionPage()
    {
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/promotions");
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("promotions"));
    }
    public void WaitForPageLoad()
    {
        _wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }
    public void ClickCreatePromotion()
    {
        var createPromotionButton = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/main/div/div/div[1]/div/div/a[2]")));
        createPromotionButton.Click();
    }
    public void EnterPromotionName(string name)
    {
        PromotionNameInput.Clear();
        PromotionNameInput.SendKeys(name);
    }
    public void SelectPromotionType(string type)
    {
        PromotionTypeDropdown.Click();
        var option = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[text()='{type}']")));
        option.Click();
    }

    public void EnterMinimumTransaction(string amount)
    {
        MinimumTransactionInput.Clear();
        MinimumTransactionInput.SendKeys(amount);
    }

    public void EnterDiscountAmount(string amount)
    {
        DiscountAmountInput.Clear();
        DiscountAmountInput.SendKeys(amount);
    }

    public void SelectStartDate(string date)
    {
        StartDateInput.Clear();
        StartDateInput.SendKeys(date);
    }

    public void SelectEndDate(string date)
    {
        EndDateInput.Clear();
        EndDateInput.SendKeys(date);
    }

    public void ToggleSingleUseCheckbox()
    {
        if (!SingleUseCheckbox.Selected)
        {
            SingleUseCheckbox.Click();
        }
    }

    public bool IsAddPromotionButtonEnabled()
    {
        return AddPromotionButton.Enabled;
    }
}