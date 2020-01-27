using OpenQA.Selenium;
using Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class PersonalDetailsPage : BasePage
    {
        private IWebDriver _driver;
        public PersonalDetailsPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        #region Elements
        //Suggestion to change the id to "FirstName" instead "FirstEmail"
        private readonly By _textBoxFirstName = By.Id("FirstEmail");
        private readonly By _textBoxLastName = By.Id("LastName");
        private readonly By _textBoxDay = By.Id("DayInput");
        private readonly By _dropdownMonth = By.Id("MonthInput");
        private readonly By _textBoxYear = By.Id("YearInput");
        private readonly By _textDateOfbirthError = By.XPath("//div[@class='invalid-feedback']");

        #endregion

        public void InputPersonalDetails(string firstName, string lastName, string dateOfBirth)
        {
            FindElement(_textBoxFirstName).SendKeys(firstName);
            FindElement(_textBoxLastName).SendKeys(lastName);
            var date = DobCalculation(dateOfBirth).Split('-');
            FindElement(_textBoxDay).SendKeys(date[0]);
            SelectDropdownByText(_dropdownMonth, date[1]);
            FindElement(_textBoxYear).SendKeys(date[2]);
        }

        private string DobCalculation(string dateOfBirth)
        {
            switch (dateOfBirth)
            {
                case "16Years":
                    return DateTime.Now.AddYears(-16).ToString("dd-MMM-yyyy");
                case "Over16Years":
                    return DateTime.Now.AddYears(-16).AddDays(-1).ToString("dd-MMM-yyyy");
                case "Under16Years":
                    return DateTime.Now.AddYears(-16).AddDays(1).ToString("dd-MMM-yyyy");
                case "Over120Years":
                    return DateTime.Now.AddYears(-121).ToString("dd-MMM-yyyy");
                default:
                    break;
            }
            var date = dateOfBirth.Split('_');
            var day = DateTime.Now.AddDays(-Convert.ToInt32(date[2].Replace("d", "")));
            var month = day.AddMonths(-Convert.ToInt32(date[1].Replace("m", "")));
            return month.AddYears(-Convert.ToInt32(date[0].Replace("y", ""))).ToString("dd-MMM-yyyy");
        }

       
    }
}
