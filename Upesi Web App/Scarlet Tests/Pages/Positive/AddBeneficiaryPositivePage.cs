using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public class AddBeneficiaryPositivePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public AddBeneficiaryPositivePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement AddBeneficiaryDiv =>
        _wait.Until(d =>
        {
            var element = d.FindElement(By.ClassName("add-beneficiary-div"));
            return element.Displayed ? element : null;
        });

    public IWebElement PlusIcon =>
        _wait.Until(d =>
        {
            var element = d.FindElement(By.CssSelector(".add-beneficiary i.fa-plus"));
            return element.Displayed ? element : null;
        });

    public IWebElement BeneficiaryText =>
        _wait.Until(d =>
        {
            var element = d.FindElement(By.XPath("//div[contains(@class,'add-beneficiary-name')]/p[text()='Add Beneficiary']"));
            return element.Displayed ? element : null;
        });

    public void ClickPlusIcon()
    {
        PlusIcon.Click();
    }

    public bool IsAddBeneficiaryVisible()
    {
        return AddBeneficiaryDiv.Displayed;
    }

    public string GetBeneficiaryText()
    {
        return BeneficiaryText.Text;
    }
}
