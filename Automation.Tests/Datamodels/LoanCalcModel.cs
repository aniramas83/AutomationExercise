using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Tests.Datamodels
{
    public class LoanCalcModel
    {
        [JsonProperty("ApplicationType")]
        public string ApplicationType { get; set; }

        [JsonProperty("Dependants")]
        public string Dependants { get; set; }

        [JsonProperty("PropertyPurpose")]
        public string PropertyPurpose { get; set; }

        [JsonProperty("IncomeBeforeTax")]
        public decimal IncomeBeforeTax { get; set; }

        [JsonProperty("OtherIncome")]
        public decimal OtherIncome { get; set; }

        [JsonProperty("LivingExpenses")]
        public decimal LivingExpenses { get; set; }

        [JsonProperty("CurrentHlRepay")]
        public decimal CurrentHlRepay { get; set; }

        [JsonProperty("OtherLoanRepay")]
        public decimal OtherLoanRepay { get; set; }

        [JsonProperty("OtherCommitments")]
        public decimal OtherCommitments { get; set; }

        [JsonProperty("CreditCardLimit")]
        public decimal CreditCardLimit { get; set; }
    }
}
