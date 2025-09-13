using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

public class CreateTransactionPage
{
    private readonly IWebDriver _driver;

    public CreateTransactionPage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(driver, this);
    }

    // Selectors
    [FindsBy(How = How.XPath, Using = "//h2[text()='Create Transaction']")]
    public IWebElement PageHeader { get; set; }

    [FindsBy(How = How.Id, Using = "react-select-3-input")]
    public IWebElement SearchUserInput { get; set; }

    [FindsBy(How = How.Name, Using = "sendAmount")]
    public IWebElement SenderAmountInput { get; set; }

    [FindsBy(How = How.Name, Using = "receiverAmount")]
    public IWebElement ReceiverAmountInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//button[text()='Calculate Rate']")]
    public IWebElement CalculateRateButton { get; set; }

    [FindsBy(How = How.XPath, Using = "//button[text()='Preview Transaction']")]
    public IWebElement PreviewTransactionButton { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @name='newBeneficiary']")]
    public IWebElement NewBeneficiaryCheckbox { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@type='file' and @name='complianceDocument']")]
    public IWebElement UploadDocumentInput { get; set; }

    public void FillSenderDetails(string userName)
    {
        SearchUserInput.SendKeys(userName);
    }

    public void FillSenderAmount(string amount)
    {
        SenderAmountInput.SendKeys(amount);
    }

    public void FillReceiverAmount(string amount)
    {
        ReceiverAmountInput.SendKeys(amount);
    }

    public void ClickCalculateRate()
    {
        CalculateRateButton.Click();
    }

    public void CheckNewBeneficiaryCheckbox()
    {
        if (!NewBeneficiaryCheckbox.Selected)
            NewBeneficiaryCheckbox.Click();
    }

    public void UploadSupportingDocument(string filePath)
    {
        UploadDocumentInput.SendKeys(filePath);
    }

    public void ClickPreviewTransaction()
    {
        PreviewTransactionButton.Click();
    }

    public bool IsOnCreateTransactionPage()
    {
        return PageHeader.Displayed;
    }
}