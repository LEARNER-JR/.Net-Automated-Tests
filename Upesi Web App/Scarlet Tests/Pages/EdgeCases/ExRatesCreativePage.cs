using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class ExRatesCreativePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public ExRatesCreativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement InputField => wait.Until(d => d.FindElement(By.Id("react-select-9-input")));

    public void TypeInInputField(string text)
    {
        InputField.Clear();
        InputField.SendKeys(text);
    }

    public string GetInputFieldValue()
    {
        return InputField.GetAttribute("value");
    }

    public bool IsAutocompleteVisible()
    {
        return driver.FindElements(By.ClassName("css-19bb58m")).Count > 0;
    }
}
