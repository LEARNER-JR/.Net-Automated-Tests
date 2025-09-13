using NUnit.Framework;
using BO_Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class PromotionTests : BaseTest
{
    private LoginPositivePage _loginPositivePage;
    private PromotionPositivePage _promotionPage;

    [SetUp]
    public void Setup()
    {
        base.SetUp();

        _loginPositivePage = ServiceProvider.GetRequiredService<LoginPositivePage>();
        _loginPositivePage.PerformPositiveLogin();
        _promotionPage = ServiceProvider.GetRequiredService<PromotionPositivePage>();

        _promotionPage.NavigateToPromotionPage();
        _promotionPage.ClickCreatePromotion(); // Open the create promotion form
        _promotionPage.WaitForPageLoad();
    }

    [Test]
    public void Test_EnterValidPromotionName()
    {
        _promotionPage.EnterPromotionName("Summer Sale");
        Assert.That(_promotionPage.PromotionNameInput.GetAttribute("value"), Is.EqualTo("Summer Sale"));
    }

    [Test]
    public void Test_SelectValidPromotionType()
    {
        _promotionPage.SelectPromotionType("Customer");
        Assert.That(_promotionPage.PromotionTypeDropdown.Text, Is.EqualTo("Customer"));
    }

    [Test]
    public void Test_InputTransactionAndDiscountAmounts()
    {
        _promotionPage.EnterMinimumTransaction("100");
        _promotionPage.EnterDiscountAmount("10");
        Assert.That(_promotionPage.MinimumTransactionInput.GetAttribute("value"), Is.EqualTo("100"));
        Assert.That(_promotionPage.DiscountAmountInput.GetAttribute("value"), Is.EqualTo("10"));
    }

    [Test]
    public void Test_SelectStartAndEndDates()
    {
        _promotionPage.SelectStartDate("2023-10-01");
        _promotionPage.SelectEndDate("2023-10-31");
        Assert.That(_promotionPage.StartDateInput.GetAttribute("value"), Is.EqualTo("2023-10-01"));
        Assert.That(_promotionPage.EndDateInput.GetAttribute("value"), Is.EqualTo("2023-10-31"));
    }

    [Test]
    public void Test_CheckSingleUseCheckbox()
    {
        _promotionPage.ToggleSingleUseCheckbox();
        Assert.That(_promotionPage.SingleUseCheckbox.Selected, Is.True);
    }

    [Test]
    public void Test_AddPromotionButtonEnabled()
    {
        _promotionPage.EnterPromotionName("Summersale");
        _promotionPage.SelectPromotionType("Customer");
        _promotionPage.EnterMinimumTransaction("100");
        _promotionPage.EnterDiscountAmount("10");
        _promotionPage.SelectStartDate("2023-10-01");
        _promotionPage.SelectEndDate("2023-10-31");
        _promotionPage.ToggleSingleUseCheckbox();
        Assert.That(_promotionPage.IsAddPromotionButtonEnabled(), Is.True);
    }
}
