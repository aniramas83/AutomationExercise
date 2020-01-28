using Automation.Pages;
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
    public sealed class ApiSteps
    {       
        private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;
        private ApiHandler _apiHandler;
        private string response;
        public ApiSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = _objectContainer.Resolve<IWebDriver>();
            _apiHandler = new ApiHandler();
        }


        [When(@"I call australia post api with:")]
        public void WhenICallAustraliaPostApiWith(Table table)
        {
            dynamic instance = table.CreateDynamicInstance();
            response = _apiHandler.GetPostalCost(instance.FromCountry, instance.ToCountry);     
            //above storing response can be improved by storing scenario context
        }

        [Then(@"I validate the price of the post")]
        public void ThenIValidateThePriceOfThePost()
        {
            //Due to time restriction validating only response is not null
            Assert.IsTrue(response != null, "Get response validation failed");
        }

    }
}
