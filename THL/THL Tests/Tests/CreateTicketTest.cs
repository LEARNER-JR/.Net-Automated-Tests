using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TicketPage : BaseTest
{
    public TicketPage(IWebDriver driver) : base(driver) { }

    public IWebElement JobTypeDropdown => driver.FindElement(By.Id("jobtype"));
    public IWebElement VehicleRegNoInput => driver.FindElement(By.Id("regno"));
    public IWebElement EmailInput => driver.FindElement(By.Id("email"));
    public IWebElement CustomerPhoneInput => driver.FindElement(By.Id("customerphone"));
    public IWebElement VehicleMakeDropdown => driver.FindElement(By.Id("make"));
    public IWebElement LoanAmountInput => driver.FindElement(By.Id("loanAmt"));
    public IWebElement CustomerNameInput => driver.FindElement(By.Id("customername"));
    public IWebElement SubmitButton => driver.FindElement(By.CssSelector("button[type='submit']"));

    public void SelectJobType(string value)
    {
        var selectElement = new SelectElement(JobTypeDropdown);
        selectElement.SelectByValue(value);
    }

    public void EnterVehicleRegNo(string value)
    {
        VehicleRegNoInput.Clear();
        VehicleRegNoInput.SendKeys(value);
    }

    public void EnterEmail(string value)
    {
        EmailInput.Clear();
        EmailInput.SendKeys(value);
    }

    public void EnterCustomerPhone(string value)
    {
        CustomerPhoneInput.Clear();
        CustomerPhoneInput.SendKeys(value);
    }

    public void SelectVehicleMake(string value)
    {
        var selectElement = new SelectElement(VehicleMakeDropdown);
        selectElement.SelectByValue(value);
    }

    public void EnterLoanAmount(string value)
    {
        LoanAmountInput.Clear();
        LoanAmountInput.SendKeys(value);
    }

    public void EnterCustomerName(string value)
    {
        CustomerNameInput.Clear();
        CustomerNameInput.SendKeys(value);
    }

    public void SubmitForm()
    {
        SubmitButton.Click();
    }

    public string GetValidationMessage(IWebElement element)
    {
        return element.GetAttribute("validationMessage");
    }
}