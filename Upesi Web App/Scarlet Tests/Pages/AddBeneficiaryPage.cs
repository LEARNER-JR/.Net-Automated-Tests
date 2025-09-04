using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

public class AddBeneficiaryPage
{
    private IWebDriver driver;

    public AddBeneficiaryPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }

    public IWebElement AddBeneficiaryText => driver.FindElement(By.XPath("//div[contains(@class,'add-beneficiary-name')]/p[text()='Add Beneficiary']"));
    public IWebElement AddBeneficiaryIcon => driver.FindElement(By.XPath("//i[contains(@class,'fa-plus')]"));
    public IWebElement AddBeneficiaryArea => driver.FindElement(By.ClassName("add-beneficiary-div"));

    public void ClickAddBeneficiaryArea()
    {
        AddBeneficiaryArea.Click();
    }

    public void AddBeneficiary(string name)
    {
        // Assume there's an input field for beneficiary name
        var inputField = driver.FindElement(By.Id("beneficiaryNameInput"));
        inputField.SendKeys(name);
        var submitButton = driver.FindElement(By.Id("submitBeneficiaryButton"));
        submitButton.Click();
    }

    public string GetConfirmationMessage()
    {
        return driver.FindElement(By.Id("confirmationMessage")).Text;
    }

    public string GetErrorMessage()
    {
        return driver.FindElement(By.Id("errorMessage")).Text;
    }
}
