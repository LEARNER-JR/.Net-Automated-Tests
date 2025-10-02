using BO_Tests.Pages.Negative;
using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BO_Tests.Tests.Negative
{
    internal class SystemCategoryNegativeTest : BaseTest
    {
    //    [TestFixture]
        private LoginPositivePage _loginPage;
        private SystemCategoryNegativePage _systemCategoryNegativePage;

        [SetUp]
        public void SetUp()
        {
            base.SetUp();
            _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
            _loginPage.PerformPositiveLogin();

            _systemCategoryNegativePage = ServiceProvider.GetRequiredService<SystemCategoryNegativePage>();
            _systemCategoryNegativePage.NavigateToSystemCategoryPage();
            _systemCategoryNegativePage.WaitForPageLoad();
        }

        [Test]
        public void SubmitFormWithoutName_ShouldNotSubmitAndShowError()
        {
            _systemCategoryNegativePage.EnterName("");
            _systemCategoryNegativePage.ClickCreateButton();
            // Add assertion for error message
        }

        [Test]
        public void SubmitFormWithInvalidName_ShouldHandleError()
        {
            _systemCategoryNegativePage.EnterName("Invalid@Name");
            _systemCategoryNegativePage.ClickCreateButton();
            // Add assertion for error message
        }

        [Test]
        public void SubmitWithoutSelectingSystemCategory_ShouldShowError()
        {
            _systemCategoryNegativePage .EnterName("Valid Name");
            _systemCategoryNegativePage.SelectCustomerType(); // Ensure this doesn't select anything
            _systemCategoryNegativePage.ClickCreateButton();
            // Add assertion for error message
        }

        [Test]
        public void SubmitWithEmptyDescription_ShouldNotSubmitAndShowError()
        {
            _systemCategoryNegativePage.EnterName("Valid Name");
            _systemCategoryNegativePage.SelectSystemCategoryContext();
            _systemCategoryNegativePage.SelectCustomerType();
            _systemCategoryNegativePage.EnterDescription("");
            _systemCategoryNegativePage.ClickCreateButton();
            // Add assertion for error message
        }

        [Test]
        public void CreateButtonShouldBeDisabled_WhenRequiredFieldsAreEmpty()
        {
            _systemCategoryNegativePage.EnterName("");
            Assert.IsFalse(_systemCategoryNegativePage.IsCreateButtonEnabled());
        }

        [Test]
        public void ClickCreateWithoutSelections_ShouldNotSubmit()
        {
            _systemCategoryNegativePage.EnterName("Valid Name");
            _systemCategoryNegativePage.ClickCreateButton();
            // Add assertion for error message
        }
    }
}
