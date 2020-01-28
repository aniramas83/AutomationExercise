using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Automation.Pages
{
    public class ApiHandler
    {

        public string GetPostalCost(string countryFrom, string countryTo)
        {
            var uri = $"https://digitalapi.auspost.com.au/postage/v4/catalogue/service.json?category=INTERNATIONAL&from={countryFrom}&to={countryTo}";
            HttpWebRequest webRequest =
                WebRequest.Create(uri) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json;charset=utf-8";
            webRequest.Headers.Add("AUTH-KEY", "62b9613ddab3f8cdaf89c47c0234729e");
           
            var httpResponse = (HttpWebResponse)webRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
