using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

            Fetcher f = new Fetcher();


            JObject lights = await f.GetRules();

            System.Console.WriteLine(lights.ToString());




            System.Console.ReadKey();
        }
    }
}
