using BO_Tests.Pages.Positive;
using BO_Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BO_Tests.Tests.Positive
{
    [TestFixture]
    public class SystemCategoryPositiveTest : BaseTest
    {
        private LoginPositivePage _loginPage;
        private SystemCategoryPositivePage _systemCategoryPositivePage;

        [SetUp]
        public void Setup()
        {
            base.SetUp();
            _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
            _loginPage.PerformPositiveLogin();

            _systemCategoryPositivePage = ServiceProvider.GetRequiredService<SystemCategoryPositivePage>();
            _systemCategoryPositivePage.NavigateToSystemCategoryPage();
            _systemCategoryPositivePage.WaitForPageLoad();
        }

        [Test]
        public void VerifySystemCategoryFormSubmissionSuccessfully()
        {
            // Fill in all fields
            _systemCategoryPositivePage.EnterName("John Doe");
            _systemCategoryPositivePage.SelectSystemCategory("Option 1");
            _systemCategoryPositivePage.SelectCustomerType("Type A");
            _systemCategoryPositivePage.EnterDescription("This is a test description.");

            // Verify Create button is enabled
            Assert.That(_systemCategoryPositivePage.IsCreateButtonEnabled(), Is.True,
                "Create button should be enabled when all required fields are filled.");

            // Submit form
            _systemCategoryPositivePage.ClickCreate();

            // Critical assertion – replace with actual success verification
            Assert.That(_systemCategoryPositivePage.GetSuccessMessage(),
                Does.Contain("System category created successfully"),
                "Expected success message was not displayed after form submission.");
        }

        [Test]
        public void VerifyCancelClearsFormFields()
        {
            // Fill in fields
            _systemCategoryPositivePage.EnterName("John Doe");
            _systemCategoryPositivePage.SelectSystemCategory("Option 1");
            _systemCategoryPositivePage.SelectCustomerType("Type A");
            _systemCategoryPositivePage.EnterDescription("This is a test description.");

            // Cancel action
            _systemCategoryPositivePage.ClickCancel();

            // Assert fields are cleared
            Assert.That(_systemCategoryPositivePage.NameInput.GetAttribute("value"),
                Is.Empty, "Name field should be cleared after cancel.");

            Assert.That(_systemCategoryPositivePage.SystemCategoryButton.Text,
                Is.EqualTo("Select..."), "System category dropdown should reset to default after cancel.");

            Assert.That(_systemCategoryPositivePage.CustomerTypeButton.Text,
                Is.EqualTo("Select..."), "Customer type dropdown should reset to default after cancel.");

            Assert.That(_systemCategoryPositivePage.DescriptionTextarea.Text,
                Is.Empty, "Description field should be cleared after cancel.");
        }

        [TearDown]
        public void Teardown()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
