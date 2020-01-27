using OpenQA.Selenium;
using Automation.Core;
using TechTalk.SpecFlow;
using Automation.Pages;
using BoDi;
using Automation.Configuration;
using TechTalk.SpecFlow.Assist;
using Automation.Tests.Datamodels;
using NUnit.Framework;
using Automation.Tests.Text;
using System;

namespace Automation.Tests.Steps
{
    [Binding]
    public class CreateAPatientAccountSteps
    {
        private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;
        private AccountDetailsPage _accountDetailsPage;
        private PersonalDetailsPage _personalDetailsPage;
        private LocationPage _locationPage;
        private CookiesPage _cookiesPage;
        private TermsandConditionsPage _termsandConditionsPage;
        private FinishedPage _finishedPage;
        private CommonPage _commonPage;
        public CreateAPatientAccountSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = _objectContainer.Resolve<IWebDriver>();
            _accountDetailsPage = new AccountDetailsPage(_driver);
            _personalDetailsPage = new PersonalDetailsPage(_driver);
            _locationPage = new LocationPage(_driver);
            _cookiesPage = new CookiesPage(_driver);
            _termsandConditionsPage = new TermsandConditionsPage(_driver);
            _finishedPage = new FinishedPage(_driver);
            _commonPage = new CommonPage(_driver);
        }

        [Given(@"I am at create patient account page")]
        public void GivenIAmAtCreatePatientAccountPage()
        {
            //Launch the web portal
            _driver.Navigate().GoToUrl(Settings.SiteUrl);
            _driver.Manage().Window.Maximize();
            //Click on create patient link to start the customer creation process
            var loginPage = new LoginPage(_driver);
            loginPage.CreatePatient();
        }

        [Given(@"I start the account creation process")]
        public void GivenIStartTheAccountCreationProcess()
        {
            var instructionsPage = new InstructionsPage(_driver);
            instructionsPage.ClickStart();
        }

        [When(@"I input all account details")]
        public void WhenIInputAllAccountDetails(Table table)
        {
            var accountDetails = table.CreateInstance<AccountDetailsModel>();
            _accountDetailsPage.InputAccountDetails(accountDetails.Email, accountDetails.confirmEmail,
                accountDetails.Password, accountDetails.ConfirmPassword);
            _accountDetailsPage.ClickNext();
        }

        [When(@"I input all account details without proceeding to next page")]
        public void WhenIInputAllAccountDetailsWithoutProceedingToNextPage(Table table)
        {
            var accountDetails = table.CreateInstance<AccountDetailsModel>();
            _accountDetailsPage.InputAccountDetails(accountDetails.Email, accountDetails.confirmEmail,
                accountDetails.Password, accountDetails.ConfirmPassword);
        }


        [When(@"I input all personal details")]
        public void WhenIInputAllPersonalDetails(Table table)
        {
            var accountDetails = table.CreateInstance<AccountDetailsModel>();
            _personalDetailsPage.InputPersonalDetails(accountDetails.FirstName,
                accountDetails.LastName, accountDetails.DateOfBirth);
            _accountDetailsPage.ClickNext();
        }

        [When(@"I Input all location details")]
        public void WhenIInputAllLocationDetails(Table table)
        {
            var accountDetails = table.CreateInstance<AccountDetailsModel>();
            _locationPage.InputLocationDetails(accountDetails.TimeZone,
                accountDetails.Country, accountDetails.State, accountDetails.Zip);
            _accountDetailsPage.ClickNext();
        }

        [When(@"I agree to cookies policy")]
        public void WhenIAgreeToCookiesPolicy()
        {
            _cookiesPage.AgreeCookiesPolicy(CookiesPage.Checkbox.Check);
            _accountDetailsPage.ClickNext();
        }

        [When(@"I agree to terms and conditions")]
        public void WhenIAgreeToTermsAndConditions()
        {
            _termsandConditionsPage.AgreeTCs(TermsandConditionsPage.Checkbox.Check);
            _termsandConditionsPage.ClickConfirm();
        }

        [Then(@"I verify the account creation")]
        public void ThenIVerifyTheAccountCreation()
        {
            var fullText = _finishedPage.GetAccountCreationText().Replace("\r\n", " ");
            Assert.IsTrue(fullText.Contains(Text.Text.AccountCreationShortMsg + " " + Text.Text.AccountCreationFullMsg),
                "Account creation message validation failed");
        }

        [Then(@"I verify ""(.*)"" date of birth error message is displayed")]
        public void ThenIVerifyDateOfBirthErrorMessageIsDisplayed(string years)
        {
            if(years== "Under16Years")
                Assert.AreEqual(Text.Text.DateOfBirthErrorMsg_Undersixteen,
                _commonPage.GetInputErrorMsg(), "Date of birth error message validation failed");
            else
                Assert.AreEqual(Text.Text.DateOfBirthErrorMsg_Over120,
                _commonPage.GetInputErrorMsg(), "Date of birth error message validation failed");
        }


        [Then(@"I verify email and password mismatch error message is displayed")]
        public void ThenIVerifyEmailAndPasswordMismatchErrorMessageIsDisplayed()
        {
            Assert.AreEqual(Text.Text.EmailConfirmationError,
              _commonPage.GetInputErrorMsg(), "Confirmation email error message validation failed");
        }

        [Then(@"I verify invalid email error message is displayed")]
        public void ThenIVerifyInvalidEmailErrorMessageIsDisplayed()
        {
            Assert.AreEqual(Text.Text.InvalidEmailError,
              _commonPage.GetInputErrorMsg(), "Invalid email error message validation failed");
        }

        [Then(@"I verify insecure password error message is displayed")]
        public void ThenIVerifyInsecurePasswordErrorMessageIsDisplayed()
        {
            Assert.AreEqual(Text.Text.InsecurePasswordError,
              _commonPage.GetInputErrorMsg(), "Insecure password error message validation failed");
        }

    }
}
