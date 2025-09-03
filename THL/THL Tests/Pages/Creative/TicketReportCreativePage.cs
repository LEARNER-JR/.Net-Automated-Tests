using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TicketReportCreativePage
{
    private readonly IWebDriver _driver;

    public TicketReportCreativePage(IWebDriver driver)
    {
        _driver = driver;
    }

    // Locators
    public IWebElement FiltrationDropdown => _driver.FindElement(By.Id("filtration"));
    public IWebElement VehicleDropdown => _driver.FindElement(By.Id("units"));

    // Rapid filtration switching
    public void ChangeFiltrationRapidly()
    {
        var selectElement = new SelectElement(FiltrationDropdown);
        selectElement.SelectByText("By Vehicle Reg. No");
        selectElement.SelectByText("All");
        selectElement.SelectByText("By Valuer Name");
    }

    // Multiple vehicle selection (if UI supports it)
    public void SelectMultipleVehicles(List<string> vehicles)
    {
        var selectElement = new SelectElement(VehicleDropdown);
        foreach (var vehicle in vehicles)
        {
            selectElement.SelectByText(vehicle);
        }
    }
}
