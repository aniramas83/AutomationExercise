using Automation.Core;
using Automation.Pages;
using Automation.Tests.Datamodels;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automation.Tests.Steps
{
    [Binding]
    public sealed class LoanCalculatorSteps
    {

        private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;
        private LoanCalculatorPage _loanCalculatorPage;
        public LoanCalculatorSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = _objectContainer.Resolve<IWebDriver>();
            _loanCalculatorPage = new LoanCalculatorPage(_driver);
        }

        [Given(@"I am at loan calculator page")]
        public void GivenIAmAtTheTaxCalculatorPage()
        {
            _driver.Navigate().GoToUrl(Settings.WebUrl);
            _driver.Manage().Window.Maximize();
        }

        [When(@"I enter your details as:")]
        public void WhenIEnterYourDetailsAs(Table table)
        {
            var loanCalc = table.CreateInstance<LoanCalcModel>();

            if (!new List<string> { "0", "1", "2", "3", "4", "5+" }.Contains(loanCalc.Dependants))
                Assert.Fail("Given value for dependant is not valid, please correct it");
            var type = (LoanCalculatorPage.ApplicationType)Enum.Parse(typeof(LoanCalculatorPage.ApplicationType), loanCalc.ApplicationType, true);
            var purpose = (LoanCalculatorPage.LoanPurpose)Enum.Parse(typeof(LoanCalculatorPage.LoanPurpose), loanCalc.PropertyPurpose, true);
            _loanCalculatorPage.InputYourDetails(type, loanCalc.Dependants, purpose);

        }

        [When(@"I enter your earnings as:")]
        public void WhenIEnterYourEarningsAs(Table table)
        {
            var loanCalc = table.CreateInstance<LoanCalcModel>();
            _loanCalculatorPage.InputYourEarnings(loanCalc.IncomeBeforeTax, loanCalc.OtherIncome);

        }

        [When(@"I enter your expenses as:")]
        public void WhenIEnterYourExpensesAs(Table table)
        {
            var loanCalc = table.CreateInstance<LoanCalcModel>();
            _loanCalculatorPage.InputYourExpenses(loanCalc.LivingExpenses, loanCalc.CurrentHlRepay, loanCalc.OtherLoanRepay,
                loanCalc.OtherCommitments, loanCalc.CreditCardLimit);

        }

        [Then(@"I verify borrowing estimate is ""(.*)""")]
        public void ThenIVerifyBorrowingEstimateIs(string limit)
        {
            _loanCalculatorPage.ClickBorrowCalculate();
            var actualLimit = _loanCalculatorPage.GetBorrowEstimate();
            Assert.AreEqual(limit, actualLimit, 
                $"Estimated borrow limit is not matching expected - Expected: {limit} Actual:{actualLimit}");
        }

        [Given(@"I entered required details for borrowing calculation")]
        public void GivenIEnteredRequiredDetailsForBorrowingCalculation()
        {
            _loanCalculatorPage.InputYourDetails(LoanCalculatorPage.ApplicationType.Joint, "2", LoanCalculatorPage.LoanPurpose.Investment);
            _loanCalculatorPage.InputYourEarnings(90000, 1000);
            _loanCalculatorPage.InputYourEarnings_AdditionalApplicant(70000, 2000);
            _loanCalculatorPage.InputYourExpenses(1000, 200, 100, 250, 10000);

        }

        [When(@"I click on start over to start over the application")]
        public void WhenIClickOnStartOverToStartOverTheApplication()
        {
            _loanCalculatorPage.ClickBorrowCalculate();
            _loanCalculatorPage.ClickStartOver();
        }

        [Then(@"I verify all the field values are set to default")]
        public void ThenIVerifyAllTheFieldValuesAreSetToDefault()
        {
            //Validate all your details default values
            Assert.IsTrue(_loanCalculatorPage.GetApplicationTypeStatus(LoanCalculatorPage.ApplicationType.Single) == "true", 
                "Application type single is not selected as part of start over");
            
            Assert.IsTrue(_loanCalculatorPage.GetDependants() == "0", "Dependants option 0 is not selected as part of start over");

            Assert.IsTrue(_loanCalculatorPage.GetLoanPurposeStatus(LoanCalculatorPage.LoanPurpose.HomeToLiveIn)=="true",
                "Loan purpose home to live in is not selected as part of start over");

            //Validate all your earnings default values
            Assert.IsTrue(_loanCalculatorPage.GetIncomeBeforeTax() == "0",
                "Income before tax is not set to default value of 0 as part of start over");
            Assert.IsTrue(_loanCalculatorPage.GetOtherIncome() == "0",
               "Other income is not set to default value of 0 as part of start over");

            //Validate all your expenses default values
            Assert.IsTrue(_loanCalculatorPage.GetExpenses() == "0",
               "Expenses is not set to default value of 0 as part of start over");
            Assert.IsTrue(_loanCalculatorPage.GetHomeLoanRepayments() == "0",
               "Home loan repayments is not set to default value of 0 as part of start over");
            Assert.IsTrue(_loanCalculatorPage.GetOtherLoanRepayments() == "0",
               "Other loan payments is not set to default value of 0 as part of start over");
            Assert.IsTrue(_loanCalculatorPage.GetOtherCommitments() == "0",
               "Other commitments is not set to default value of 0 as part of start over");
            Assert.IsTrue(_loanCalculatorPage.GetCreditCardLimit() == "0",
               "Credit card limit is not set to default value of 0 as part of start over");
        }


    }
}
