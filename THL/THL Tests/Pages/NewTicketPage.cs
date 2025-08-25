using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NewTicketPage
{
    private IWebDriver driver;

    public NewTicketPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }

    public string Url => "https://sit-portal.trackinghub.co.ke/newticket";

    public IWebElement NewTicketLink => driver.FindElement(By.CssSelector("a[href='/newticket']"));

    public void ClickNewTicketLink()
    {
        NewTicketLink.Click();
    }

    public string GetCurrentUrl()
    {
        return driver.Url;
    }
}