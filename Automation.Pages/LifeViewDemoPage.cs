using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class LifeViewDemoPage : BasePage
    {
        private IWebDriver _driver;
        public LifeViewDemoPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        private readonly By _inputName = By.Id("wffm0635571898ed434b8db4317b0d7a8d19_Sections_0__Fields_0__Value");
        private readonly By _inputCompany = By.Id("wffm0635571898ed434b8db4317b0d7a8d19_Sections_0__Fields_1__Value");
        private readonly By _inputEmail = By.Id("wffm0635571898ed434b8db4317b0d7a8d19_Sections_0__Fields_2__Value");
        private readonly By _inputPhone = By.Id("wffm0635571898ed434b8db4317b0d7a8d19_Sections_0__Fields_3__Value");
        private readonly By _inputPreferedDate = By.Id("wffm0635571898ed434b8db4317b0d7a8d19_Sections_0__Fields_4__Value");
        private readonly By _inputRequestDetails = By.Id("wffm0635571898ed434b8db4317b0d7a8d19_Sections_0__Fields_6__Value");
        private readonly By _radioAmPm = By.Id("wffm0635571898ed434b8db4317b0d7a8d19_Sections_0__Fields_5__Value");


        #endregion

        public void InputName(string name)
        {
            FindElement(_inputName).SendKeys(name);
        }

        public void InputDemoForm(FormFields formFields, string value)
        {
            switch (formFields)
            {
                case FormFields.Name:
                    InputDemoData(_inputName, value);
                    break;
                case FormFields.Company:
                    InputDemoData(_inputCompany, value);
                    break;
                case FormFields.Email:
                    InputDemoData(_inputEmail, value);
                    break;
                case FormFields.Phone:
                    InputDemoData(_inputPhone, value);
                    break;
                case FormFields.TimeStandard:
                    if (!string.IsNullOrEmpty(value))
                    {
                        FindElements(_radioAmPm).First(x => x.GetAttribute("value").ToLower().Equals(value.ToLower())).Click();
                    }
                    break;
                case FormFields.Details:
                    InputDemoData(_inputRequestDetails, value);
                    break;
                case FormFields.Date:
                    if (!string.IsNullOrEmpty(value))
                    {
                        FindElement(_inputPreferedDate).Clear();
                        FindElement(_inputPreferedDate).SendKeys(value);
                    }
                    break;
                default:
                    break;
            }
        }

        private void InputDemoData(By locator, string value)
        {
            if (!string.IsNullOrEmpty(value))
                FindElement(locator).SendKeys(value);
        }


        public enum FormFields
        {
            Name,
            Company,
            Email,
            Phone,
            TimeStandard,
            Details,
            Date
        }
    }
}
