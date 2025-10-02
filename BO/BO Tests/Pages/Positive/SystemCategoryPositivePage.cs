using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_Tests.Pages.Positive
{
    internal class SystemCategoryPositivePage
    {
            private readonly IWebDriver _driver;
            private readonly WebDriverWait _wait;

            public SystemCategoryPositivePage(IWebDriver driver)
            {
                _driver = driver;
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }

            public IWebElement NameInput => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("name")));
            public IWebElement SystemCategoryButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("headlessui-listbox-button-:rg:")));
            public IWebElement CustomerTypeButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("headlessui-listbox-button-:rj:")));
            public IWebElement DescriptionTextarea => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("description")));
            public IWebElement CreateButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Create')]")));
            public IWebElement CancelButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Cancel')]")));

            public void EnterName(string name)
            {
                NameInput.Clear();
                NameInput.SendKeys(name);
            }

            public void SelectSystemCategory(string option)
            {
                SystemCategoryButton.Click();
                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[contains(text(), '{option}')]"))).Click();
            }

            public void SelectCustomerType(string option)
            {
                CustomerTypeButton.Click();
                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[contains(text(), '{option}')]"))).Click();
            }

            public void EnterDescription(string description)
            {
                DescriptionTextarea.Clear();
                DescriptionTextarea.SendKeys(description);
            }

            public void ClickCreate()
            {
                CreateButton.Click();
            }

            public void ClickCancel()
            {
                CancelButton.Click();
            }

            public bool IsCreateButtonEnabled()
            {
                return CreateButton.Enabled;
            }
        internal void NavigateToSystemCategoryPage()
        {
            throw new NotImplementedException();
        }

        internal void WaitForPageLoad()
        {
            throw new NotImplementedException();
        }

        internal object GetSuccessMessage()
        {
            throw new NotImplementedException();
        }
    }
}
