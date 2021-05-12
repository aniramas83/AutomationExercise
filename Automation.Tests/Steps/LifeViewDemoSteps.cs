using OpenQA.Selenium;
using Automation.Core;
using TechTalk.SpecFlow;
using Automation.Pages;
using BoDi;
using Automation.Configuration;
using TechTalk.SpecFlow.Assist;
using Automation.Tests.Datamodels;
using NUnit.Framework;

namespace Automation.Tests.Steps
{
    [Binding]
    public class LifeViewDemoSteps
    {
        private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;
        private HomePage _homePage;
        private LifeViewPage _lifeViewPage;
        private LifeViewDemoPage _lifeViewDemoPage;
        public LifeViewDemoSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = _objectContainer.Resolve<IWebDriver>();
            _homePage = new HomePage(_driver);
            _lifeViewPage = new LifeViewPage(_driver);
            _lifeViewDemoPage = new LifeViewDemoPage(_driver);
        }

        [Given(@"I am at MLC home page")]
        public void GivenIAmAtCreatePatientAccountPage()
        {
            //Launch the web portal
            _driver.Navigate().GoToUrl(Settings.WebUrl);
            _driver.Manage().Window.Maximize();
        }

        [When(@"I search for ""(.*)"" on the homepage")]
        public void WhenISearchForOnTheHomepage(string search)
        {
            //Search for lifeview
            _homePage.ClickGlobalSearch();
            _homePage.InputSearch(search);
        }

        [When(@"I select the ""(.*)"" resulted link")]
        public void WhenISelectTheResultedLink(string content)
        {
            //Select the lifeview link
            _homePage.ClickResultContent(content);
        }

        [When(@"I request a demo")]
        public void WhenIRequestADemo()
        {
            //Click request a demo link
            _lifeViewPage.ClickRequestDemo();
        }

        [When(@"I input demo data as:")]
        public void WhenIInputDemoDataAs(Table table)
        {
            var formDetails = table.CreateInstance<DemoFormModel>();
            _lifeViewDemoPage.InputDemoForm(LifeViewDemoPage.FormFields.Name, formDetails.Name);
            _lifeViewDemoPage.InputDemoForm(LifeViewDemoPage.FormFields.Company, formDetails.Company);
            _lifeViewDemoPage.InputDemoForm(LifeViewDemoPage.FormFields.Phone, formDetails.Phone);
            _lifeViewDemoPage.InputDemoForm(LifeViewDemoPage.FormFields.Email, formDetails.Email);
            _lifeViewDemoPage.InputDemoForm(LifeViewDemoPage.FormFields.Date, formDetails.Date);
            _lifeViewDemoPage.InputDemoForm(LifeViewDemoPage.FormFields.TimeStandard, formDetails.TimeStandard);
            _lifeViewDemoPage.InputDemoForm(LifeViewDemoPage.FormFields.Details, formDetails.Details);
        }

        [Then(@"I submit the request form")]
        public void ThenIClickSubmitTheRequestForm()
        {
           //ignoring the step since submission is not requested as part of the scenario
        }

    }
}
