using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class PromotionNegativePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public PromotionNegativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement PromotionNameInput => driver.FindElement(By.Name("promotionName"));
    public IWebElement PromotionTypeSelect => driver.FindElement(By.Id("headlessui-listbox-button-:r4n:"));
    public IWebElement ConditionSelect => driver.FindElement(By.Id("headlessui-listbox-button-:r4q:"));
    public IWebElement SubmitButton => driver.FindElement(By.CssSelector("button[type='submit']"));
    public IList<IWebElement> ErrorMessages =>driver.FindElements(By.CssSelector("div[role='alert'].rizzui-input-error-text"));
    public void NavigateToPromotionPage()
    {
        driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/promotions");
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("promotions"));
    }
    public void WaitForPageLoad()
    {
        wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }
    public void ClickCreatePromotion()
    {
        var createPromotionButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/main/div/div/div[1]/div/div/a[2]")));
        createPromotionButton.Click();
    }
    public void EnterPromotionName(string name)
    {
        PromotionNameInput.Clear();
        PromotionNameInput.SendKeys(name);
    }

    public void SelectPromotionType(string type)
    {
        PromotionTypeSelect.Click();
        var option = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//li[text()='{type}']")));
        option.Click();
    }

    public void ClickSubmit()
    {
        SubmitButton.Click();
    }

    public string GetErrorMessage()
    {
        return string.Join(" | ", ErrorMessages.Select(e => e.Text));
    }

    public bool IsSubmitButtonEnabled()
    {
        return SubmitButton.Enabled;
    }

    public void SetTransactionAmount(int amount)
    {
        var amountInput = wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("transactingAmount"))
        );
        amountInput.Clear();
        amountInput.SendKeys(amount.ToString());
    }
    public void SetStartDate(DateTime date)
    {
        var startDateInput = wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("startDate"))
        );
        startDateInput.Clear();
        startDateInput.SendKeys(date.ToString("yyyy-MM-dd"));
        startDateInput.SendKeys(Keys.Tab); // ensure blur triggers validation
    }
    public void SetEndDate(DateTime date)
    {
        var endDateInput = wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("endDate"))
        );
        endDateInput.Clear();
        endDateInput.SendKeys(date.ToString("yyyy-MM-dd"));
        endDateInput.SendKeys(Keys.Tab);
    }
    public void UncheckSingleUse()
    {
        var checkbox = wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("singleUse"))
        );

        if (checkbox.Selected)
        {
            checkbox.Click();
        }
    }
}