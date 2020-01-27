using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class CommonPage : BasePage
    {
        private IWebDriver _driver;
        public CommonPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        private readonly By _textDateErrorMsg = By.XPath("//div[@class='invalid-feedback']");

        #endregion
        public string GetInputErrorMsg()
        {
            return FindElement(_textDateErrorMsg).Text;
        }

    }
}
