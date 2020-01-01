using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightToy.Types
{
    public class Light
    {
        [JsonIgnore]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public LightState State { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("modelid")]
        public string ModelID { get; set; }

        [JsonProperty("uniqueid")]
        public string UniqueID { get; set; }

        [JsonProperty("manufacturename")]
        public string ManufactureName { get; set; }

        [JsonProperty("luminaireuniqueid")]
        public string LuminareUniqueId { get; set; }

        [JsonProperty("streaming")]
        public bool Streaming { get; set; }


    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class LightState { 
        
        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("bri")]
        public uint? Brightness { get; set; }

        [JsonProperty("hue")]
        public uint? Hue { get; set; }

        [JsonProperty("sat")]
        public uint? Saturation { get; set; }

        [JsonProperty("xy")]
        public float[] XY { get; set; }

        [JsonProperty("ct")]
        public uint? ColorTemperature { get; set; }

        [JsonProperty("alert")]
        public string Alert { get; set; }

        [JsonProperty("effect")]
        public string Effect { get; set; }

        [JsonProperty("colormode"), JsonConverter(typeof(StringEnumConverter))]
        public ColorModeType ColourMode { get; set; }

        [JsonProperty("reachable")]
        public bool? Reachable { get; set; }
    }

    public enum ColorModeType
    {
        hs, xy, ct
    }
}
