using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TicketReportNegativePage
{
    private readonly IWebDriver _driver;

    public TicketReportNegativePage(IWebDriver driver)
    {
        _driver = driver;
    }

    // Locators
    public IWebElement FiltrationDropdown => _driver.FindElement(By.Id("filtration"));
    public IWebElement VehicleDropdown => _driver.FindElement(By.Id("units"));
    public IWebElement StatusDropdown => _driver.FindElement(By.Id("status"));
    public IWebElement DateRangeInput => _driver.FindElement(By.Id("reservation"));
    public IWebElement ExecuteButton => _driver.FindElement(By.XPath("//button[text()='Execute']"));

    // Invalid filtration
    public void SelectInvalidFiltration(string option = "Invalid Option")
    {
        var selectElement = new SelectElement(FiltrationDropdown);
        selectElement.SelectByText(option);
    }

    // Invalid date
    public void SetInvalidDateRange(string invalidDate = "invalid date")
    {
        DateRangeInput.Clear();
        DateRangeInput.SendKeys(invalidDate);
    }

    // Special characters
    public void SetSpecialCharactersInDateRange(string chars = "!@#$%^&*()")
    {
        DateRangeInput.Clear();
        DateRangeInput.SendKeys(chars);
    }

    public void ClickExecute()
    {
        ExecuteButton.Click();
    }
}
