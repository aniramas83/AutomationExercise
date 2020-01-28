using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Tests.Datamodels
{
    public class DemoFormModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Company")]
        public string Company { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("TimeStandard")]
        public string TimeStandard { get; set; }
       
        [JsonProperty("Details")]
        public string Details { get; set; }
    }
}
