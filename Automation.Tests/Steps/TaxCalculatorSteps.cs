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
    public sealed class TaxCalculatorSteps
    {

        private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;
        private TaxCalculatorPage _taxCalculatorPage;
        public TaxCalculatorSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = _objectContainer.Resolve<IWebDriver>();
            _taxCalculatorPage = new TaxCalculatorPage(_driver);
        }

        [Given(@"I am at the tax calculator page")]
        public void GivenIAmAtTheTaxCalculatorPage()
        {
            //Launch the web portal
            _driver.Navigate().GoToUrl(Settings.TaxSiteUrl);
            _driver.Manage().Window.Maximize();
        }

        [When(@"I enter all required options as:")]
        public void WhenIEnterAllRequiredOptionsAs(Table table)
        {
            var taxCalc = table.CreateInstance<TaxCalcModel>();
            _taxCalculatorPage.CalculateTax(taxCalc.Year, taxCalc.Amount, taxCalc.Residency, taxCalc.NumberOfMonths);
        }

        [Then(@"I verify the tax calculation is not null")]
        public void ThenIVerifyTheTaxCalculationIsNotNull()
        {
            var amount = _taxCalculatorPage.GetTaxAmount();
            var tax = Convert.ToDecimal(amount.Replace("$", ""));
            Assert.IsTrue(tax > 0, "Tax calculation validation failed");
        }

    }
}
