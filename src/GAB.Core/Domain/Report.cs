using Newtonsoft.Json;

namespace GAB.Core.Domain
{
    public class Report
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }


    }
}