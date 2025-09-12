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
    public IWebElement ErrorMessage => driver.FindElement(By.ClassName("error-message-class")); // Update with actual class name

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
        return ErrorMessage.Text;
    }

    public bool IsSubmitButtonEnabled()
    {
        return SubmitButton.Enabled;
    }
}