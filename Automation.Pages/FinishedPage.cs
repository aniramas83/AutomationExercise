using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
	public class FinishedPage : BasePage
	{
		private IWebDriver _driver;
		public FinishedPage(IWebDriver webDriver) : base(webDriver)
		{
			_driver = webDriver;
		}

		#region Elements
		private readonly By _buttonDone = By.XPath("//li[contains(text(),'Done')]");
		private readonly By _textFinishedPage = By.CssSelector("div.wizard-step-container");
		#endregion

		public void ClickDone()
		{
			FindElement(_buttonDone).Click();
		}

		public string GetAccountCreationText()
		{
			return FindElement(_textFinishedPage).Text;
		}
	}
}
