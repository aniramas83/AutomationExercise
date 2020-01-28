using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class HomePage : BasePage
    {
        private IWebDriver _driver;
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        private readonly By _buttonGlobalSearch = By.CssSelector("button.link-icon.search-toggle.js-popover-toggle");
        private readonly By _inputGlobalSearch = By.CssSelector("input.text.js-autocomplete-input.width-full");
        private By LabelSearchResult(string search) { 
           return By.XPath($"//strong[contains(text(),'{search}')]"); 
        }
        #endregion

        public void ClickGlobalSearch()
        {
            FindElement(_buttonGlobalSearch).Click();
        }

        public void InputSearch(string search)
        {
            FindElement(_inputGlobalSearch).SendKeys(search);
        }

        public void ClickResultContent(string content)
        {
            FindElement(LabelSearchResult(content)).Click();
        }
    }
}
