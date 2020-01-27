using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class AccountDetailsPage : BasePage
    {
        private IWebDriver _driver;
        public AccountDetailsPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        private readonly By _textBoxEmail = By.Id("Email");
        private readonly By _textBoxConfirmEmail = By.Id("ConfirmEmail");
        private readonly By _textBoxPassword = By.Id("Password");
        private readonly By _textBoxConfirmPassword = By.Id("ConfirmPassword");
        private readonly By _buttonNext = By.XPath("//li[contains(text(),'Next')]");
        private readonly By _buttonBack = By.XPath("//li[contains(text(),'Back')]");
        #endregion

        public void InputAccountDetails(string email, string confirmEmail, string password, string confirmPassword)
        {
            FindElement(_textBoxEmail).SendKeys(email);
            if (!string.IsNullOrEmpty(confirmEmail))
                FindElement(_textBoxConfirmEmail).SendKeys(confirmEmail);
            if (!string.IsNullOrEmpty(password))
                FindElement(_textBoxPassword).SendKeys(password);
            if (!string.IsNullOrEmpty(confirmPassword))
                FindElement(_textBoxConfirmPassword).SendKeys(confirmPassword);
        }

        public void ClickNext()
        {
            FindElement(_buttonNext).Click();
        }

    }
}
