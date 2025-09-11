using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class AddUserGroupPositivePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public AddUserGroupPositivePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement GroupNameInput => _wait.Until(d => d.FindElement(By.Name("groupName")));
    public IWebElement DescriptionTextarea => _wait.Until(d => d.FindElement(By.Name("description")));
    public IWebElement CreateUserGroupButton => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Create User Group']")));
    public IWebElement CancelButton => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Cancel']")));

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

    public void SubmitForm()
    {
        CreateUserGroupButton.Click();
    }

    public void ClickCancel()
    {
        CancelButton.Click();
    }

    public bool IsCreateUserGroupButtonEnabled()
    {
        return CreateUserGroupButton.Enabled;
    }

    public string GetGroupNameInputValue()
    {
        return GroupNameInput.GetAttribute("value");
    }

    public string GetDescriptionTextareaValue()
    {
        return DescriptionTextarea.GetAttribute("value");
    }
}