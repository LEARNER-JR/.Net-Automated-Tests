using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class ExRatesPositiveTest
{
    private IWebDriver _driver;
    private ExRatesPositivePage _inputFieldPage;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://sitwebapp.upesimts.com/dashboard");
        _inputFieldPage = new ExRatesPositivePage(_driver);
    }

    [Test]
    public void VerifyPlaceholderTextIsDisplayed()
    {
        Assert.That(_inputFieldPage.GetPlaceholderText(), Is.EqualTo("Select to filter"));
    }

    [Test]
    public void CheckAutocompleteSuggestions()
    {
        _inputFieldPage.TypeInInputField("valid term");
        // Assuming suggestions appear after typing
        var suggestion = _driver.FindElement(By.XPath("//div[contains(@class, 'css-19bb58m')]"));
        Assert.That(suggestion.Displayed, Is.True);
    }

    [Test]
    public void EnsureInputFieldAcceptsText()
    {
        string inputText = "Test Input";
        _inputFieldPage.TypeInInputField(inputText);
        Assert.That(_inputFieldPage.GetInputFieldValue(), Is.EqualTo(inputText));
    }

    [Test]
    public void TestSelectingOptionFromAutocomplete()
    {
        _inputFieldPage.TypeInInputField("valid term");
        _inputFieldPage.SelectAutocompleteOption("Option Text"); // Replace with actual option text
        Assert.That(_inputFieldPage.GetInputFieldValue(), Is.EqualTo("Option Text"));
    }

    [Test]
    public void ValidateInputFieldCanBeCleared()
    {
        _inputFieldPage.TypeInInputField("Some text");
        _inputFieldPage.ClearInputField();
        Assert.That(_inputFieldPage.GetInputFieldValue(), Is.EqualTo(""));
        Assert.That(_inputFieldPage.GetPlaceholderText(), Is.EqualTo("Select to filter"));
    }

    [Test]
    public void ConfirmInputFieldIsAccessibleViaKeyboard()
    {
        _inputFieldPage.FocusInputField();
        Assert.That(_driver.SwitchTo().ActiveElement(), Is.EqualTo(_inputFieldPage.InputFieldElement));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}