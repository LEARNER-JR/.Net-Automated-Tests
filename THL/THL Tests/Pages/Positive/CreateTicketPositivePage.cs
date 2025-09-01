using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;

public class CreateTicketPositivePage
{
    private readonly IWebDriver _driver;

    public CreateTicketPositivePage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(driver, this);
    }

    public By NewTicketLink => By.CssSelector("a.nav-link[href='/newticket']");
    public By NewTicketIcon => By.CssSelector("a.nav-link .nav-icon.fas.fa-plus-square");

    public void ClickNewTicketLink()
    {
        _driver.FindElement(NewTicketLink).Click();
    }

    public bool IsNewTicketLinkVisible()
    {
        return _driver.FindElement(NewTicketLink).Displayed;
    }

    public bool IsNewTicketIconDisplayed()
    {
        return _driver.FindElement(NewTicketIcon).Displayed;
    }
}
