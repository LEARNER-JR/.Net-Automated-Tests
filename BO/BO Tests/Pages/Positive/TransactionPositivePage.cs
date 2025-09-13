using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class CreateTransactionPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public CreateTransactionPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Locators
    private By PageHeader => By.XPath("//h2[text()='Create Transaction']");
    private By SearchUserInput => By.Id("react-select-3-input");
    private By SenderAmountInput => By.Name("sendAmount");
    private By ReceiverAmountInput => By.Name("receiverAmount");
    private By CalculateRateButton => By.XPath("//button[text()='Calculate Rate']");
    private By PreviewTransactionButton => By.XPath("//button[text()='Preview Transaction']");
    private By NewBeneficiaryCheckbox => By.XPath("//input[@type='checkbox' and @name='newBeneficiary']");
    private By UploadDocumentInput => By.XPath("//input[@type='file' and @name='complianceDocument']");
    public void WaitForPageLoad()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(PageHeader));
    }
    public void NavigateToCreateTransactionPage()
    {
        throw new NotImplementedException();
    }
    public void FillSenderDetails(string userName)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(SearchUserInput)).SendKeys(userName);
    }

    public void FillSenderAmount(string amount)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(SenderAmountInput)).SendKeys(amount);
    }

    public void FillReceiverAmount(string amount)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(ReceiverAmountInput)).SendKeys(amount);
    }

    public void ClickCalculateRate()
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(CalculateRateButton)).Click();
    }

    public void CheckNewBeneficiaryCheckbox()
    {
        var checkbox = _wait.Until(ExpectedConditions.ElementToBeClickable(NewBeneficiaryCheckbox));
        if (!checkbox.Selected)
            checkbox.Click();
    }

    public void UploadSupportingDocument(string filePath)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(UploadDocumentInput)).SendKeys(filePath);
    }

    public void ClickPreviewTransaction()
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(PreviewTransactionButton)).Click();
    }

    public bool IsOnCreateTransactionPage()
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(PageHeader)).Displayed;
    }

    public void NavigateToCreateTransactionPage(string url)
    {
        _driver.Navigate().GoToUrl(url);
        WaitForPageLoad();
    }

    public void SelectCountry(string v)
    {
        throw new NotImplementedException();
    }

    public bool GetSelectedCountry()
    {
        throw new NotImplementedException();
    }

    public bool IsDocumentUploaded()
    {
        throw new NotImplementedException();
    }
    public bool AreNewBeneficiaryFieldsEnabled()
    {
        throw new NotImplementedException();
    }
}
