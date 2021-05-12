using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Automation.Pages
{
    public class LoanCalculatorPage : BasePage
    {
        private IWebDriver _driver;
        public LoanCalculatorPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        private readonly By _buttonSingleApplication = By.Id("application_type_single");
        private readonly By _buttonJointApplication = By.Id("application_type_joint");
        private readonly By _dropdownDependants = By.XPath("//select[@title='Number of dependants']");
        private readonly By _buttonHomeBorrower = By.Id("borrow_type_home");
        private readonly By _buttonInvestmentBorrower = By.Id("borrow_type_investment");
        private readonly By _textboxIncomeBeforeTax = By.XPath("//*[@id='q2q1i1']/following-sibling::input");
        private readonly By _textboxOtherIncome = By.XPath("//*[@id='q2q2i1']/following-sibling::input");
        private readonly By _textboxIncomeBeforeTaxApplicant2 = By.XPath("//*[@id='q2q3i1']/following-sibling::input");
        private readonly By _textboxOtherIncomeApplicant2 = By.XPath("//*[@id='q2q4i1']/following-sibling::input");
        private readonly By _textboxExpenses = By.Id("expenses");
        private readonly By _textboxOtherLoans = By.Id("otherloans");
        private readonly By _textboxCredits = By.Id("credit");
        private readonly By _textboxHomeLoans = By.Id("homeloans");
        private readonly By _textboxOtherCommitments = By.XPath("//*[@id='q3q4i1']/following-sibling::input");
        private readonly By _buttonWorkOutHowMuchIborrow = By.Id("btnBorrowCalculater");
        private readonly By _textBorrowEstimate = By.Id("borrowResultTextAmount");
        private readonly By _buttonStartOver = By.XPath("//div[@class='borrow__result text--white clearfix']//button[@aria-label='Start over']");

        #endregion

        public void InputYourDetails(ApplicationType type, string dependants, LoanPurpose purpose)
        {
            FindElement(type == ApplicationType.Single ?
                _buttonSingleApplication : _buttonJointApplication).Click();

            SelectDropdownByText(_dropdownDependants, dependants);

            FindElement(purpose == LoanPurpose.HomeToLiveIn ?
                _buttonHomeBorrower : _buttonInvestmentBorrower).Click();
        }

        public void InputYourEarnings(decimal income, decimal otherIncome)
        {
            FindElement(_textboxIncomeBeforeTax).SendKeys(income.ToString());
            FindElement(_textboxOtherIncome).SendKeys(otherIncome.ToString());
        }

        public void InputYourEarnings_AdditionalApplicant(decimal income, decimal otherIncome)
        {
            FindElement(_textboxIncomeBeforeTaxApplicant2).SendKeys(income.ToString());
            FindElement(_textboxOtherIncomeApplicant2).SendKeys(otherIncome.ToString());
        }

        public void InputYourExpenses(decimal expense, decimal homeLoans, decimal otherLoans, decimal commitmments, decimal creditCard)
        {
            FindElement(_textboxExpenses).SendKeys(expense.ToString());
            FindElement(_textboxHomeLoans).SendKeys(homeLoans.ToString());
            FindElement(_textboxOtherLoans).SendKeys(otherLoans.ToString());
            FindElement(_textboxOtherCommitments).SendKeys(commitmments.ToString());
            FindElement(_textboxCredits).SendKeys(creditCard.ToString());
        }

        public void ClickBorrowCalculate() => FindElement(_buttonWorkOutHowMuchIborrow).Click();

        public void ClickStartOver() => FindElement(_buttonStartOver).Click();

        public string GetBorrowEstimate()
        {
            var text = FindElement(_textBorrowEstimate).Text;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(driver =>
            {
                text = FindElement(_textBorrowEstimate).Text;
                return driver.FindElement(_textBorrowEstimate).Text.Equals(text);
            });
            return text;
        }

        public string GetApplicationTypeStatus(ApplicationType type)
        {
            return FindElement(type == ApplicationType.Single ? _buttonSingleApplication : _buttonJointApplication)
                .GetAttribute("checked");
        }

        public string GetLoanPurposeStatus(LoanPurpose purpose)
        {
            return FindElement(purpose == LoanPurpose.HomeToLiveIn ? _buttonHomeBorrower : _buttonInvestmentBorrower)
                .GetAttribute("checked");
        }

        public string GetDependants()
        {
            var dropdown = FindElement(_dropdownDependants);
            var selectedVal = new SelectElement(dropdown);
            return selectedVal.SelectedOption.Text;
        }

        public string GetIncomeBeforeTax() => FindElement(_textboxIncomeBeforeTax).GetAttribute("value");
        public string GetOtherIncome() => FindElement(_textboxOtherIncome).GetAttribute("value");

        public string GetExpenses() => FindElement(_textboxExpenses).GetAttribute("value");
        public string GetHomeLoanRepayments() => FindElement(_textboxHomeLoans).GetAttribute("value");
        public string GetOtherLoanRepayments() => FindElement(_textboxOtherLoans).GetAttribute("value");
        public string GetOtherCommitments() => FindElement(_textboxOtherCommitments).GetAttribute("value");
        public string GetCreditCardLimit() => FindElement(_textboxCredits).GetAttribute("value");

        public enum ApplicationType
        {
            Single,
            Joint
        }

        public enum LoanPurpose
        {
            HomeToLiveIn,
            Investment
        }
    }
}
