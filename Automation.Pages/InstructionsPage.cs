using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
	public class InstructionsPage : BasePage
	{
		private IWebDriver _driver;
		public InstructionsPage(IWebDriver webDriver) : base(webDriver)
		{
			_driver = webDriver;
		}

		#region Elements
		private readonly By _buttonStart = By.XPath("//li[contains(text(),'Start')]");
		private readonly By _textInstructionsPage = By.CssSelector("div.wizard-step-container");
		#endregion

		public void ClickStart()
		{
			FindElement(_buttonStart).Click();
		}

		public string GetInstructionsText()
		{
			return FindElement(_textInstructionsPage).Text;
		}
	}
}
