using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.PageObjects;

public class AllTicketsPage
{
    private readonly IWebDriver _driver;

    public AllTicketsPage(IWebDriver driver)
    {
        _driver = driver;
        //PageFactory.InitElements(driver, this);
    }

    public IWebElement AllTicketsLink => _driver.FindElement(By.CssSelector("a[href='/alltickets']"));

    public void ClickAllTicketsLink()
    {
        AllTicketsLink.Click();
    }

    public string GetAllTicketsLinkText()
    {
        return AllTicketsLink.Text.Trim();
    }

    public bool IsAllTicketsLinkDisplayed()
    {
        return AllTicketsLink.Displayed;
    }

    public bool IsIconDisplayed()
    {
        return AllTicketsLink.FindElement(By.TagName("i")).Displayed;
    }
}
