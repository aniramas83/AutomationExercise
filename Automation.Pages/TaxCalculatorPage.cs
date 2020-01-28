using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class TaxCalculatorPage : BasePage
    {
        private IWebDriver _driver;
        public TaxCalculatorPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        private readonly By _dropdownYear = By.Id("ddl-financialYear");
        private readonly By _inputAmount = By.Id("texttaxIncomeAmt");
        private readonly By _radioFullResident = By.XPath("//span[contains(text(),'Resident for full year')]");
        private readonly By _radioNonResident = By.XPath("//span[contains(text(),'Non-resident for full year')]");
        private readonly By _radioPartResident = By.XPath("//span[contains(text(),'Part-year resident')]");
        private readonly By _dropdownNumberOfMonths = By.Id("ddl-residentPartYearMonths");
        private readonly By _buttonSubmit = By.XPath("//button[contains(text(),'Submit')]");
        private readonly By _textCalculationAmount = By.CssSelector("div.white-block span");
        #endregion

        public void CalculateTax(string year, string amount, string residency, string numberOfMonths)
        {
            SelectDropdownByText(_dropdownYear, year);
            FindElement(_inputAmount).SendKeys(amount);
            if (residency.ToLower().Contains("full"))
                FindElement(_radioFullResident).Click();
            else if (residency.ToLower().Contains("non"))
                FindElement(_radioNonResident).Click();
            else if (residency.ToLower().Contains("part"))
            {
                FindElement(_radioPartResident).Click();
                SelectDropdownByText(_dropdownNumberOfMonths, numberOfMonths);
            }
            FindElement(_buttonSubmit).Click();
        }

        public string GetTaxAmount()
        {
            return FindElement(_textCalculationAmount).Text;
        }
    }
}
