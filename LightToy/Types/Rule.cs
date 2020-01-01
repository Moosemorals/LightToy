using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LightToy.Types
{
    public class Rule
    {

        public Rule()
        {
            Conditions = new List<Condition>();
            Actions = new List<Action>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lasttriggered")]
        public DateTime LastTriggered { get; set; }

        [JsonProperty("timestriggered")]
        public uint TimesTriggered { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("conditions")]
        public ICollection<Condition> Conditions { get; set; }

        [JsonProperty("actions")]
        public ICollection<Action> Actions { get; set; }
    }

    public class Condition
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("operator"), JsonConverter(typeof(StringEnumConverter))]
        public OperatorType Oerator { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }

    public class Action
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("method")]
        // TODO: This should be an enum?
        public string Method { get; set; }
    }

    public enum OperatorType
    {
        eq, gt, lt, dx, ddx,
        stable, 
        [EnumMember(Value = "not stable")]
        notStable,
        @in, 
        [EnumMember(Value = "not in")]
        notIn
    }
}
