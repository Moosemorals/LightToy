using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LightToy
{
    class Program
    {

        private static HttpClient http = new HttpClient();

        static async Task Main(string[] args)
        {


            string hubIP = ConfigurationManager.AppSettings.Get("hubIP");
            string hubID = ConfigurationManager.AppSettings.Get("hubID");

            Fetcher f = new Fetcher(hubIP, hubID);


            JObject lights = await f.GetRules();

            System.Console.WriteLine(lights.ToString());




            System.Console.ReadKey();
        }
    }
}
