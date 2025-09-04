using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

public class LoginPositivePage
{
    private IWebDriver driver;

    public LoginPositivePage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.CssSelector, Using = "a.Header_loginBtn__2+Lso")]
    private IWebElement loginLink;

    public void ClickLoginLink()
    {
        loginLink.Click();
    }

    public bool IsLoginLinkVisible()
    {
        return loginLink.Displayed && loginLink.Enabled;
    }

    public string GetLoginLinkHref()
    {
        return loginLink.GetAttribute("href");
    }
}