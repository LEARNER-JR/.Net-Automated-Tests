//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;

//public class TicketReportPage
//{
//    private readonly IWebDriver _driver;

//    public TicketReportPage(IWebDriver driver)
//    {
//        _driver = driver;
//    }

//    public IWebElement FiltrationDropdown => _driver.FindElement(By.Id("filtration"));
//    public IWebElement VehicleDropdown => _driver.FindElement(By.Id("units"));
//    public IWebElement StatusDropdown => _driver.FindElement(By.Id("status"));
//    public IWebElement DateRangeInput => _driver.FindElement(By.Id("reservation"));
//    public IWebElement ExecuteButton => _driver.FindElement(By.XPath("//button[text()='Execute']"));
//    public IWebElement Form => _driver.FindElement(By.TagName("form"));

//    public void SelectFiltration(string option)
//    {
//        var selectElement = new SelectElement(FiltrationDropdown);
//        selectElement.SelectByText(option);
//    }

//    public void SelectVehicle(string vehicle)
//    {
//        var selectElement = new SelectElement(VehicleDropdown);
//        selectElement.SelectByText(vehicle);
//    }

//    public void SelectStatus(string status)
//    {
//        var selectElement = new SelectElement(StatusDropdown);
//        selectElement.SelectByText(status);
//    }

//    public void SetDateRange(string dateRange)
//    {
//        DateRangeInput.Clear();
//        DateRangeInput.SendKeys(dateRange);
//    }

//    public void ClickExecute()
//    {
//        ExecuteButton.Click();
//    }

//    public string GetCurrentUrl()
//    {
//        return _driver.Url;
//    }

//    public List<string> GetStatusOptions()
//    {
//        var options = new SelectElement(StatusDropdown).Options;
//        return options.Select(o => o.Text).ToList();
//    }

//    public bool IsVehicleDropdownVisible()
//    {
//        return VehicleDropdown.Displayed;
//    }
//}
