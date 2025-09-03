// using NUnit.Framework;
// using OpenQA.Selenium;
// using Assert = NUnit.Framework.Assert;

// [TestFixture]
// public class CreateTicketTest : BaseTest
// {
//     private CreateTicketPage page;

//     [SetUp]
//     public async Task GoToCreateTicketPage()
//     {
//         driver.Navigate().GoToUrl("https://sit-portal.trackinghub.co.ke/newticket");
//         page = new CreateTicketPage(driver);
//         await page.WaitForElementAsync(By.Id("jobtype"));
//     }

//     [Test]
//     public void VerifyValidJobTypeSelection()
//     {
//         page.SelectJobType("INSTALLATION");
//         Assert.That(page.JobTypeDropdown.GetAttribute("value"), Is.EqualTo("INSTALLATION"));
//     }

//     [Test]
//     public void VerifyValidSubjectInput()
//     {
//         page.EnterSubject("TEST SUBJECT");
//         Assert.That(page.SubjectInput.GetAttribute("value"), Is.EqualTo("TEST SUBJECT"));
//     }

//     [Test]  
//     public void VerifyValidRegNoInput()
//     {
//         page.EnterRegNo("KCD003H");
//         Assert.That(page.RegNoInput.GetAttribute("value"), Is.EqualTo("KCD003H"));
//     }

//     [Test]
//     public void VerifyValidCustomerNameInput()
//     {
//         page.EnterCustomerName("John Doe");
//         Assert.That(page.CustomerNameInput.GetAttribute("value"), Is.EqualTo("John Doe"));
//     }

//     [Test]
//     public void VerifyValidEmailInput()
//     {
//         page.EnterEmail("test@example.com");
//         Assert.That(page.EmailInput.GetAttribute("value"), Is.EqualTo("test@example.com"));
//     }

//     [Test]
//     public void VerifyValidCustomerPhoneInput()
//     {
//         page.EnterCustomerPhone("+254712345678");
//         Assert.That(page.CustomerPhoneInput.GetAttribute("value"), Is.EqualTo("+254712345678"));
//     }

//     [Test]
//     public void VerifyValidContactPhoneInput()
//     {
//         page.EnterContactPhone("+254712345678");
//         Assert.That(page.ContactPhoneInput.GetAttribute("value"), Is.EqualTo("+254712345678"));
//     }

//     [Test]
//     public void VerifyValidVehicleMakeSelection()
//     {
//         page.SelectVehicleMake("TOYOTA");
//         Assert.That(page.VehicleMakeDropdown.GetAttribute("value"), Is.EqualTo("TOYOTA"));
//     }

//     [Test]
//     public void VerifyValidModelInput()
//     {
//         page.EnterModel("Corolla");
//         Assert.That(page.ModelInput.GetAttribute("value"), Is.EqualTo("Corolla"));
//     }

//     [Test]
//     public void VerifyValidColorInput()
//     {
//         page.EnterColor("Red");
//         Assert.That(page.ColorInput.GetAttribute("value"), Is.EqualTo("Red"));
//     }

//     [Test]
//     public void VerifyValidVehicleLocInput()
//     {
//         page.EnterVehicleLoc("Nairobi");
//         Assert.That(page.VehicleLocInput.GetAttribute("value"), Is.EqualTo("Nairobi"));
//     }

//     [Test]
//     public void VerifyValidLoanAmtInput()
//     {
//         page.EnterLoanAmt("10000");
//         Assert.That(page.LoanAmtInput.GetAttribute("value"), Is.EqualTo("10000"));
//     }

//     [Test]
//     public void VerifyErrorForMissingJobType()
//     {
//         // Submit without selecting job type
//         page.EnterSubject("TEST SUBJECT");
//         page.EnterRegNo("KCD003H");
//         page.EnterCustomerName("John Doe");
//         page.EnterEmail("test@example.com");
//         page.EnterCustomerPhone("+254712345678");
//         page.EnterContactPhone("+254712345678");
//         page.EnterModel("Corolla");
//         page.EnterColor("Red");
//         page.EnterVehicleLoc("Nairobi");
//         page.EnterLoanAmt("10000");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForShortSubject()
//     {
//         page.EnterSubject("Tes");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForInvalidRegNo()
//     {
//         page.EnterRegNo("INVALID");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForInvalidCustomerName()
//     {
//         page.EnterCustomerName("John123");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForInvalidEmail()
//     {
//         page.EnterEmail("invalid-email");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForInvalidCustomerPhone()
//     {
//         page.EnterCustomerPhone("123456789");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForEmptyModel()
//     {
//         page.SelectVehicleMake("TOYOTA");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForShortColor()
//     {
//         page.EnterColor("R");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForLongVehicleLoc()
//     {
//         page.EnterVehicleLoc("This is a very long vehicle location that exceeds the maximum character limit");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyErrorForNegativeLoanAmt()
//     {
//         page.EnterLoanAmt("-100");
//         page.SubmitForm();
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyNetworkFailureHandling()
//     {
//         // Assuming a method to simulate network failure
//         page.SelectJobType("INSTALLATION");
//         page.EnterSubject("TEST SUBJECT");
//         page.EnterRegNo("KCD003H");
//         page.EnterCustomerName("John Doe");
//         page.EnterEmail("test@example.com");
//         page.EnterCustomerPhone("+254712345678");
//         page.EnterContactPhone("+254712345678");
//         page.EnterModel("Corolla");
//         page.EnterColor("Red");
//         page.EnterVehicleLoc("Nairobi");
//         page.EnterLoanAmt("10000");
//         // Simulate network failure here
//         page.SubmitForm();
//         // Assert for network error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyRapidJobTypeChange()
//     {
//         page.SelectJobType("INSTALLATION");
//         page.SelectJobType("REMOVAL");
//         // Assert that dependent fields are updated accordingly (implementation depends on the actual behavior)
//     }

//     [Test]
//     public void VerifyPasteInvalidData()
//     {
//         // Simulating paste operation
//         page.EnterSubject("Invalid Data");
//         // Assert for error message (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifySubmissionWithoutRequiredDocuments()
//     {
//         page.SelectJobType("INSTALLATION");
//         page.EnterSubject("TEST SUBJECT");
//         page.EnterRegNo("KCD003H");
//         page.EnterCustomerName("John Doe");
//         page.EnterEmail("test@example.com");
//         page.EnterCustomerPhone("+254712345678");
//         page.EnterContactPhone("+254712345678");
//         page.EnterModel("Corolla");
//         page.EnterColor("Red");
//         page.EnterVehicleLoc("Nairobi");
//         page.EnterLoanAmt("10000");
//         page.SubmitForm();
//         // Assert for error message regarding required documents (implementation depends on the actual error message displayed)
//     }

//     [Test]
//     public void VerifyResponsiveForm()
//     {
//         // Resize browser or check responsiveness (implementation depends on the actual behavior)
//     }

//     [Test]
//     public void VerifyUnsavedChangesWarning()
//     {
//         page.EnterSubject("Unsaved Changes");
//         // Simulate navigating away
//         // Assert for warning message (implementation depends on the actual behavior)
//     }

//     [Test]
//     public void VerifyScreenReaderAccessibility()
//     {
//         // Test with screen reader (implementation depends on the actual behavior)
//     }

//     [Test]
//     public void VerifyAutofillDataValidation()
//     {
//         // Simulate browser autofill
//         page.EnterCustomerName("John Doe");
//         // Assert for validation criteria (implementation depends on the actual behavior)
//     }

//     [Test]
//     public void VerifyInternationalCharacterHandling()
//     {
//         page.EnterCustomerName("José");
//         // Assert that the input is accepted (implementation depends on the actual behavior)
//     }

//     [Test]
//     public void VerifyKeyboardNavigation()
//     {
//         // Navigate through fields using keyboard
//         // Assert that all fields are accessible (implementation depends on the actual behavior)
//     }

//     // [TearDown]
//     // public void TearDown()
//     // {
//     //     driver.Quit();
//     // }
// }

