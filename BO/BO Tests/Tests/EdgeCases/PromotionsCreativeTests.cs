using BO_Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class PromotionCreativeTests : BaseTest
{
    private LoginPositivePage _loginPage;
    private PromotionCreativePage _promotionPage;

    [SetUp]
    public void Setup()
    {
        base.SetUp();
        _loginPage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPage.PerformPositiveLogin();

        _promotionPage = ServiceProvider.GetRequiredService<PromotionCreativePage>();
        _promotionPage.NavigateToPromotionsPage();
        _promotionPage.ClickAddPromotionButton();
        _promotionPage.WaitForPageLoad();
    }

    [Test]
    public void RapidFormFillAndSubmit()
    {
        for (int i = 0; i < 10; i++)
        {
            _promotionPage.FillPromotionName("Promo " + i);
            _promotionPage.SelectPromotionType("Customer");
            _promotionPage.SelectCondition("None");
            _promotionPage.SelectPlatform("All");
            _promotionPage.SelectChannel("Select Channel");
            _promotionPage.SelectDiscountType("Select discount type");
            _promotionPage.SubmitForm();
        }

        // Example: Assert that 10 promotions appear in the list
        Assert.That(_promotionPage.GetPromotionCount(), Is.GreaterThanOrEqualTo(10),
            "Expected at least 10 promotions after rapid submissions.");
    }

    [Test]
    public void SpecialCharactersInPromotionName()
    {
        string specialChars = "!@#$%^&*()_+";
        _promotionPage.FillPromotionName(specialChars);

        Assert.That(_promotionPage.PromotionNameInput.GetAttribute("value"), Is.EqualTo(specialChars),
            "Promotion name input did not retain special characters.");

        _promotionPage.SubmitForm();

        // Example: Verify validation/error message
        Assert.That(_promotionPage.IsValidationMessageDisplayed(), Is.True,
            "Expected validation message for special characters.");
    }

    [Test]
    public void RapidDropdownSelections()
    {
        _promotionPage.SelectPromotionType("Customer");
        _promotionPage.SelectCondition("None");
        _promotionPage.SelectPlatform("All");
        _promotionPage.SelectChannel("Select Channel");
        _promotionPage.SelectDiscountType("Select discount type");

        // Example: Assert that selected values are displayed correctly
        Assert.That(_promotionPage.GetSelectedPromotionType(), Is.EqualTo("Customer"));
        Assert.That(_promotionPage.GetSelectedCondition(), Is.EqualTo("None"));
        Assert.That(_promotionPage.GetSelectedPlatform(), Is.EqualTo("All"));
    }

    [Test]
    public void ValidPromotionCodeClearedBeforeSubmission()
    {
        _promotionPage.FillPromotionName("ValidPromoCode");
        _promotionPage.PromotionNameInput.Clear();

        Assert.That(_promotionPage.PromotionNameInput.GetAttribute("value"), Is.Empty,
            "Promotion name input should be cleared.");

        // Example: Assert that submission is disabled or blocked
        Assert.That(_promotionPage.IsSubmitButtonEnabled(), Is.False,
            "Submit button should be disabled when promotion name is empty.");
    }

    [Test]
    public void KeyboardNavigationAccessibility()
    {
        _promotionPage.PromotionNameInput.SendKeys(Keys.Tab);
        Assert.That(_promotionPage.PromotionTypeDropdown.Displayed, Is.True,
            "Promotion type dropdown should be visible after tabbing.");

        _promotionPage.PromotionTypeDropdown.SendKeys(Keys.Tab);
        Assert.That(_promotionPage.ConditionDropdown.Displayed, Is.True,
            "Condition dropdown should be visible after tabbing.");
    }

    [Test]
    public void UsabilityTestByUnfamiliarUser()
    {
        // Simulate actions by an unfamiliar user
        _promotionPage.FillPromotionName("Promo Test");
        _promotionPage.SelectPromotionType("Customer");
        _promotionPage.SelectCondition("None");
        _promotionPage.SelectPlatform("All");
        _promotionPage.SelectChannel("Select Channel");
        _promotionPage.SelectDiscountType("Select discount type");
        _promotionPage.SubmitForm();

        // Example: Verify success notification or confirmation
        Assert.That(_promotionPage.IsSuccessMessageDisplayed(), Is.True,
            "Expected success message after submitting a valid promotion form.");
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}
