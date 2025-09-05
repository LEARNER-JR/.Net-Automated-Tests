using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public class ExRatesPositivePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public ExRatesPositivePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement InputField =>
        _wait.Until(d =>
        {
            var element = d.FindElement(By.Id("react-select-9-input"));
            return element.Displayed ? element : null;
        });
    public IWebElement InputFieldElement => InputField;

    private IWebElement Placeholder =>
        _wait.Until(d =>
        {
            var element = d.FindElement(By.Id("react-select-9-placeholder"));
            return element.Displayed ? element : null;
        });

    public string GetPlaceholderText()
    {
        return Placeholder.Text;
    }

    public void TypeInInputField(string text)
    {
        InputField.Clear();
        InputField.SendKeys(text);
    }

    public void SelectAutocompleteOption(string optionText)
    {
        var option = _wait.Until(d =>
        {
            var element = d.FindElement(By.XPath($"//div[contains(@class, 'css-19bb58m') and text()='{optionText}']"));
            return element.Displayed ? element : null;
        });
        option.Click();
    }

    public string GetInputFieldValue()
    {
        return InputField.GetAttribute("value");
    }

    public void ClearInputField()
    {
        InputField.Clear();
    }

    public void FocusInputField()
    {
        InputField.Click();
    }
}
