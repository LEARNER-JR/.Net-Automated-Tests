using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class TicketPropertiesPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public TicketPropertiesPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Properties with explicit waits
    public IWebElement StatusDropdown =>
        wait.Until(d => d.FindElement(By.Id("statusSelect")));

    public IWebElement ContactInfoSection =>
        wait.Until(d => d.FindElement(By.XPath("//h2[text()='Contact Info']/..")));

    public IWebElement TicketInformationSection =>
        wait.Until(d => d.FindElement(By.XPath("//h2[text()='Ticket Information']/..")));

    public IWebElement TechnicianCommentsSection =>
        wait.Until(d => d.FindElement(By.XPath("//h2[text()='Technician's Comments']/..")));

    public IWebElement AdditionalInformationSection =>
        wait.Until(d => d.FindElement(By.XPath("//h2[text()='Additional Information']/..")));

    // Methods
    public void SelectStatus(string status)
    {
        var selectElement = new SelectElement(StatusDropdown);
        selectElement.SelectByText(status);
    }

    public void ToggleSection(IWebElement section)
    {
        section.Click();
    }

    public string GetContactInfo()
    {
        try
        {
            return ContactInfoSection.Text;
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
    }

    public string GetTicketInformation()
    {
        try
        {
            return TicketInformationSection.Text;
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
    }

    public string GetTechnicianComments()
    {
        try
        {
            return TechnicianCommentsSection.Text;
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
    }

    public string GetAdditionalInformation()
    {
        try
        {
            return AdditionalInformationSection.Text;
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
    }

    // Helper methods for better element handling
    public bool IsStatusDropdownVisible()
    {
        try
        {
            return StatusDropdown.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public bool IsSectionVisible(IWebElement section)
    {
        try
        {
            return section.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}