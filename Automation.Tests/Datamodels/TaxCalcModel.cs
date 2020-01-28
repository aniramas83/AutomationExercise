using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Tests.Datamodels
{
    public class TaxCalcModel
    {
        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("Residency")]
        public string Residency { get; set; }

        [JsonProperty("NumberOfMonths")]
        public string NumberOfMonths { get; set; }
    }
}
