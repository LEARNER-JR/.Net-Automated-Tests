using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class AddBeneficiaryCreativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public AddBeneficiaryCreativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement AddBeneficiaryButton => _wait.Until(d => d.FindElement(By.CssSelector(".add-beneficiary-div .fa-plus")));
    public IWebElement BeneficiaryNameInput => _wait.Until(d => d.FindElement(By.CssSelector("input[name='beneficiaryName']"))); // Assuming there's an input for beneficiary name
    public IWebElement SubmitButton => _wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']"))); // Assuming there's a submit button
    public IWebElement ErrorMessage => _wait.Until(d => d.FindElement(By.CssSelector(".error-message"))); // Assuming there's an error message element

    public void ClickAddBeneficiary()
    {
        AddBeneficiaryButton.Click();
    }

    public void EnterBeneficiaryName(string name)
    {
        BeneficiaryNameInput.SendKeys(name);
    }

    public void Submit()
    {
        SubmitButton.Click();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }
}