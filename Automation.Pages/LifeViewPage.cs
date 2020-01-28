using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
	public class LifeViewPage : BasePage
	{
		private IWebDriver _driver;
		public LifeViewPage(IWebDriver webDriver) : base(webDriver)
		{
			_driver = webDriver;
		}

		#region Elements
		private readonly By _buttonRequestDemo = By.XPath("//span[contains(text(),'Request a demo')]");
		
		#endregion

		public void ClickRequestDemo()
		{
			FindElement(_buttonRequestDemo).Click();
		}
	}
}
