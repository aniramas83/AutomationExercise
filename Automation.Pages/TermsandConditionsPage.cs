using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class TermsandConditionsPage : BasePage
    {
        private IWebDriver _driver;
        public TermsandConditionsPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        private readonly By _checkBoxAgree = By.XPath("//input[@id='agreeToTermsAndConditionsInput']");
        private readonly By _labelAgree = By.XPath("//label[contains(text(),'Agree to the Terms & Conditions')]");
        private readonly By _buttonConfirm = By.XPath("//li[contains(text(),'Confirm')]");
        #endregion

        public void AgreeTCs(Checkbox status)
        {
            switch (status)
            {
                case Checkbox.Check:
                    if (_driver.FindElement(_checkBoxAgree).GetAttribute("data-value") == "false")
                        FindElement(_labelAgree).Click();
                    break;
                case Checkbox.Uncheck:
                    if (_driver.FindElement(_checkBoxAgree).GetAttribute("data-value") == "true")
                        FindElement(_labelAgree).Click();
                    break;
                default:
                    break;
            }
        }

        public void ClickConfirm()
        {
            FindElement(_buttonConfirm).Click();
        }

        public enum Checkbox
        {
            Check,
            Uncheck
        }

    }
}
