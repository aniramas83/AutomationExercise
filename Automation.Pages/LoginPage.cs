using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
	public class LoginPage : BasePage
	{
		private IWebDriver _driver;
		public LoginPage(IWebDriver webDriver) : base(webDriver)
		{
			_driver = webDriver;
		}

		#region Elements
		private readonly By _linkCreatePatient = By.XPath("//a[text()='Create a patient account']");
		#endregion

		public void CreatePatient()
		{
			FindElement(_linkCreatePatient).Click();
		}
	}
}
