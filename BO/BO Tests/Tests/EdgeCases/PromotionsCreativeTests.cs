using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class PromotionTests
{
    private IWebDriver _driver;
    private PromotionPage _promotionPage;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://sit-ui.upesimts.com/promotions/create");
        _promotionPage = new PromotionPage(_driver);
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

        // Add assertions to verify the expected outcome after rapid submissions
    }

    [Test]
    public void SpecialCharactersInPromotionName()
    {
        string specialChars = "!@#$%^&*()_+";
        _promotionPage.FillPromotionName(specialChars);
        Assert.AreEqual(specialChars, _promotionPage.PromotionNameInput.GetAttribute("value"));
        _promotionPage.SubmitForm();

        // Add assertions to verify the expected outcome
    }

    [Test]
    public void RapidDropdownSelections()
    {
        _promotionPage.SelectPromotionType("Customer");
        _promotionPage.SelectCondition("None");
        _promotionPage.SelectPlatform("All");
        _promotionPage.SelectChannel("Select Channel");
        _promotionPage.SelectDiscountType("Select discount type");

        // Add assertions to verify the expected outcome
    }

    [Test]
    public void ValidPromotionCodeClearedBeforeSubmission()
    {
        _promotionPage.FillPromotionName("ValidPromoCode");
        _promotionPage.PromotionNameInput.Clear();
        Assert.AreEqual("", _promotionPage.PromotionNameInput.GetAttribute("value"));

        // Add assertions to verify the expected outcome
    }

    [Test]
    public void KeyboardNavigationAccessibility()
    {
        _promotionPage.PromotionNameInput.SendKeys(Keys.Tab);
        Assert.IsTrue(_promotionPage.PromotionTypeDropdown.Displayed);

        _promotionPage.PromotionTypeDropdown.SendKeys(Keys.Tab);
        Assert.IsTrue(_promotionPage.ConditionDropdown.Displayed);

        // Continue to navigate through all fields and assert visibility
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

        // Add feedback assertions based on expected usability outcomes
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}