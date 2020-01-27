using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class LocationPage : BasePage
    {
        private IWebDriver _driver;
        public LocationPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        //Suggestion to change the id to "FirstName" instead "FirstEmail"
        private readonly By _inputTimezones = By.Id("timezones");
        private readonly By _dropdownOptions = By.XPath("//div[contains(@class,'ng-option')]");
        private readonly By _dropdownCountry = By.Id("Country");
        private readonly By _inputState = By.Id("code");
        private readonly By _textBoxZip = By.Id("PostCode");

        #endregion

        public void InputLocationDetails(string timezone, string country, string state, string zip)
        {
            //Timezone selection
            FindElement(_inputTimezones).Click();
            var timezones = FindElements(_dropdownOptions);
            timezones.First(x => x.Text.Equals(timezone)).Click();
            //Country selection
            SelectDropdownByText(_dropdownCountry, country);
            //State selection
            FindElement(_inputState).Click();
            var states = FindElements(_dropdownOptions);
            states.First(x => x.Text.Equals(state)).Click();
            //Post code input
            FindElement(_textBoxZip).SendKeys(zip);
        }
    }
}
