using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_Tests.Pages.Negative
{
    internal class SystemCategoryNegativePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SystemCategoryNegativePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement NameField => wait.Until(d => d.FindElement(By.Name("name")));
        private IWebElement SystemCategoryContextDropdown => wait.Until(d => d.FindElement(By.Id("headlessui-listbox-button-:rg:")));
        private IWebElement CustomerTypeDropdown => wait.Until(d => d.FindElement(By.Id("headlessui-listbox-button-:rj:")));
        private IWebElement DescriptionField => wait.Until(d => d.FindElement(By.Name("description")));
        private IWebElement CreateButton => wait.Until(d => d.FindElement(By.XPath("//button[contains(text(),'Create')]")));
        private IWebElement CancelButton => wait.Until(d => d.FindElement(By.XPath("//button[contains(text(),'Cancel')]")));

        public void EnterName(string name)
        {
            NameField.Clear();
            NameField.SendKeys(name);
        }

        public void SelectSystemCategoryContext()
        {
            SystemCategoryContextDropdown.Click();
            // Add logic to select an option if needed
        }

        public void SelectCustomerType()
        {
            CustomerTypeDropdown.Click();
            // Add logic to select an option if needed
        }

        public void EnterDescription(string description)
        {
            DescriptionField.Clear();
            DescriptionField.SendKeys(description);
        }

        public void ClickCreateButton()
        {
            CreateButton.Click();
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
    }
}
