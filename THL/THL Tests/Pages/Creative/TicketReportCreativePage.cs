using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

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

    //Generic filtration selector (used by tests)
    public void SelectFiltration(string option)
    {
        var selectElement = new SelectElement(FiltrationDropdown);
        selectElement.SelectByText(option);
    }

    //Helper
    public string GetSelectedFiltration()
    {
        var selectElement = new SelectElement(FiltrationDropdown);
        return selectElement.SelectedOption.Text;
    }

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
