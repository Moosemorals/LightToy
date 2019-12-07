using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LightToy
{
    internal class Fetcher
    {
        private static readonly HttpClient http = new HttpClient();

        private string hubIP;
        private string userID;

        public Fetcher(string HubIP, string UserID)
        {
            hubIP = HubIP;
            userID = UserID;
        }

        private Uri BuildUri(string path)
        {
            return new UriBuilder
            {
                Scheme = "http",
                Host = hubIP,
                Path = "/api/" + userID + path
            }.Uri; 
        }

        internal async Task<JToken> Get(string path)
        {
            Uri target = BuildUri(path);
            HttpResponseMessage resp = await http.GetAsync(target);

            if (resp.IsSuccessStatusCode)
            {
                string raw = await resp.Content.ReadAsStringAsync();
                return JToken.Parse(raw);
            }

            throw new FetchException(resp);
        }

        internal async Task<JToken> Post(string path, JObject body)
        {

            Uri target = BuildUri(path);

            StringContent content = new StringContent(body.ToString());
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage resp = await http.PostAsync(target, content);

            if (resp.IsSuccessStatusCode)
            {
                return JToken.Parse(await resp.Content.ReadAsStringAsync());
            }

            throw new FetchException(resp);
        }


        public async Task<JObject> GetLights()
        {
            return await Get("/lights") as JObject;
        }

        public async Task<JObject> GetRules()
        {
            return await Get("/rules") as JObject;
        }

        internal class FetchException : Exception
        {

            public HttpResponseMessage responseMessage { get; private set; }

            public FetchException(HttpResponseMessage resp) : base(resp.StatusCode.ToString())
            {
                this.responseMessage = resp;
            }
        }

    }

}
