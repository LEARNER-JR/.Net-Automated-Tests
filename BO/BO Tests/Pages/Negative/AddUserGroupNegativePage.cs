using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class AddUserGroupNegativePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public AddUserGroupNegativePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement GroupNameInput => _wait.Until(d => d.FindElement(By.Name("groupName")));
    private IWebElement DescriptionTextarea => _wait.Until(d => d.FindElement(By.Name("description")));
    private IWebElement CreateUserGroupButton => _wait.Until(d => d.FindElement(By.XPath("//button[contains(text(), 'Create User Group')]")));
    private IWebElement CancelButton => _wait.Until(d => d.FindElement(By.XPath("//button[contains(text(), 'Cancel')]")));

    public void EnterGroupName(string groupName)
    {
        GroupNameInput.Clear();
        GroupNameInput.SendKeys(groupName);
    }

    public void EnterDescription(string description)
    {
        DescriptionTextarea.Clear();
        DescriptionTextarea.SendKeys(description);
    }

    public void ClickCreateUserGroup()
    {
        CreateUserGroupButton.Click();
    }

    public void ClickCancel()
    {
        CancelButton.Click();
    }
}