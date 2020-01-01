using Newtonsoft.Json;
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


            Dictionary<string, Types.Light> lights = await f.GetLights();

            foreach (string id in lights.Keys)
            {
                System.Console.WriteLine(id + ": "+ lights[id].Name  + ": " + lights[id].State.On);

                System.Console.WriteLine(JsonConvert.SerializeObject(lights[id].State));

            }




            System.Console.ReadKey();
        }
    }
}
