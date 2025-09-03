using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public class TicketReportNegativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public TicketReportNegativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    // Locators
    public IWebElement FiltrationDropdown => _driver.FindElement(By.Id("filtration"));
    public IWebElement VehicleDropdown => _driver.FindElement(By.Id("units"));
    public IWebElement StatusDropdown => _driver.FindElement(By.Id("status"));
    public IWebElement DateRangeInput => _driver.FindElement(By.Id("reservation"));
    public IWebElement ExecuteButton => _driver.FindElement(By.XPath("//button[text()='Execute']"));

    //Actions
    public void SelectInvalidFiltration(string option = "Invalid Option")
    {
        var selectElement = new SelectElement(FiltrationDropdown);
        selectElement.SelectByText(option);
    }

    public void SetInvalidDateRange(string invalidDate = "invalid date")
    {
        DateRangeInput.Clear();
        DateRangeInput.SendKeys(invalidDate);
    }

    public void SetSpecialCharactersInDateRange(string chars = "!@#$%^&*()")
    {
        DateRangeInput.Clear();
        DateRangeInput.SendKeys(chars);
    }

    public void ClearTokenValue()
    {
        try
        {
            var tokenInput = _driver.FindElement(By.Id("token")); // adjust if ID differs
            tokenInput.Clear();
        }
        catch (NoSuchElementException)
        {
            // Token field not found – ignore
        }
    }

    public void ClickExecute()
    {
        ExecuteButton.Click();
    }

    //Helpers
    public bool IsValidationMessageDisplayed()
    {
        try
        {
            var validation = _wait.Until(d => d.FindElement(By.CssSelector(".validation-error, .field-validation-error")));
            return validation.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public bool IsErrorMessageDisplayed()
    {
        try
        {
            var error = _wait.Until(d => d.FindElement(By.CssSelector(".error, .alert-danger")));
            return error.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
