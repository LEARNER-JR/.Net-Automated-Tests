using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public class AddBeneficiaryNegativePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public AddBeneficiaryNegativePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private By plusIconSelector => By.CssSelector(".add-beneficiary .fa-plus");
    private By errorMessageSelector => By.CssSelector(".error-message"); // Assuming an error message class
    private By loadingIndicatorSelector => By.CssSelector(".loading-indicator"); // Assuming a loading indicator class
    private By addBeneficiaryFormSelector => By.CssSelector(".beneficiary-form"); // Assuming a form class

    public void ClickPlusIcon()
    {
        var plusIcon = wait.Until(d =>
        {
            var element = d.FindElement(plusIconSelector);
            return (element.Displayed && element.Enabled) ? element : null;
        });
        plusIcon.Click();
    }

    public bool IsErrorMessageDisplayed()
    {
        return driver.FindElements(errorMessageSelector).Count > 0;
    }

    public bool IsLoadingIndicatorDisplayed()
    {
        return driver.FindElements(loadingIndicatorSelector).Count > 0;
    }

    public void FillBeneficiaryForm(string name)
    {
        // Assuming there's a name input field in the form
        var nameInput = wait.Until(d =>
        {
            var element = d.FindElement(By.CssSelector(".beneficiary-name-input"));
            return element.Displayed ? element : null;
        });
        nameInput.Clear();
        nameInput.SendKeys(name);
    }

    public void SubmitForm()
    {
        // Assuming there's a submit button in the form
        var submitButton = wait.Until(d =>
        {
            var element = d.FindElement(By.CssSelector(".submit-button"));
            return element.Displayed && element.Enabled ? element : null;
        });
        submitButton.Click();
    }

    public bool IsFormDisplayed()
    {
        return driver.FindElements(addBeneficiaryFormSelector).Count > 0;
    }
}
