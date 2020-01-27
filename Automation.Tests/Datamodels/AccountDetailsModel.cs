using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Tests.Datamodels
{
    public class AccountDetailsModel
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("confirmEmail")]
        public string confirmEmail { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("DateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("TimeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Zip")]
        public string Zip { get; set; }
    }
}
