using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.PageObjects;

public class TicketDetailsPage
{
    private IWebDriver driver;

    public TicketDetailsPage(IWebDriver driver)
    {
        this.driver = driver;
        //PageFactory.InitElements(driver, this);
    }

    public IWebElement MainLink => driver.FindElement(By.XPath("//div[@class='inner-card']/a"));
    public IWebElement DateTimeDisplay => driver.FindElement(By.XPath("//i[@class='fa fa-clock']"));
    public IWebElement UserNameDisplay => driver.FindElement(By.XPath("//i[@class='fa fa-user']"));
    public IWebElement CompanyNameDisplay => driver.FindElement(By.XPath("//i[@class='fas fa-building']"));
    public IWebElement BadgeDisplay => driver.FindElement(By.XPath("//span[@class='badge bg-info']"));
    public IWebElement OverdueStatus => driver.FindElement(By.XPath("//div[contains(text(),'Overdue')]"));

    public void ClickMainLink()
    {
        MainLink.Click();
    }
}
