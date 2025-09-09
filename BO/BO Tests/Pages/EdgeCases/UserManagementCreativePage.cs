using OpenQA.Selenium;

public class UserManagementCreativePage : BasePage
{
    public UserManagementCreativePage(IWebDriver driver) : base(driver) { }

    public By FormFieldEmail => By.Id("email");
    public By FormFieldPhone => By.Id("phone");
    public By SubmitButton => By.Id("submit");
    public By ErrorMessage => By.ClassName("error-message");

    public void FillEmail(string email)
    {
        driver.FindElement(FormFieldEmail).SendKeys(email);
    }

    public void FillPhone(string phone)
    {
        driver.FindElement(FormFieldPhone).SendKeys(phone);
    }

    public void SubmitForm()
    {
        driver.FindElement(SubmitButton).Click();
    }

    public string GetErrorMessage()
    {
        return driver.FindElement(ErrorMessage).Text;
    }
}