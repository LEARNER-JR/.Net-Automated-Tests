using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class ExRatesNegativeTest
{
    private IWebDriver _driver;
    private ExRatesNegativePage _inputFieldPage;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/dashboard");
        _inputFieldPage = new ExRatesNegativePage(_driver);
    }

    [Test]
    public void TestSpecialCharactersInput()
    {
        _inputFieldPage.EnterText("@#$%");
        string inputValue = _inputFieldPage.GetInputValue();

        Assert.That(
            inputValue.Contains("@") || inputValue.Contains("#") ||
            inputValue.Contains("$") || inputValue.Contains("%"),
            Is.False,
            "Special characters should not be accepted."
        );
    }

    [Test]
    public void TestEmptyInputSubmission()
    {
        _inputFieldPage.ClearInput();
        // Example if submit button & error message exist:
        // _driver.FindElement(By.Id("submit-button")).Click();
        // string errorMessage = _driver.FindElement(By.Id("error-message")).Text;
        // Assert.That(errorMessage, Is.EqualTo("This field is required."));
    }

    [Test]
    public void TestAutocompleteOnEmptyInput()
    {
        _inputFieldPage.ClearInput();
        // Example if suggestions are implemented:
        // bool suggestionsVisible = _inputFieldPage.AreSuggestionsVisible();
        // Assert.That(suggestionsVisible, Is.False, "Autocomplete suggestions should not appear when input is empty.");
    }

    [Test]
    public void TestLongStringInput()
    {
        string longString = new string('a', 300); // Assuming 300 exceeds the limit
        _inputFieldPage.EnterText(longString);
        string inputValue = _inputFieldPage.GetInputValue();

        Assert.That(inputValue.Length, Is.LessThanOrEqualTo(255), "Input should not exceed character limit.");
    }

    [Test]
    public void TestInvalidDataTypes()
    {
        _inputFieldPage.EnterText("12345");
        string inputValue = _inputFieldPage.GetInputValue();

        Assert.That(long.TryParse(inputValue, out _), Is.False, "Input should not accept numbers.");
    }

    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
}
