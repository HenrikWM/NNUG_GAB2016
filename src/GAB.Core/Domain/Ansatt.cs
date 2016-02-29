using Newtonsoft.Json;

namespace GAB.Core.Domain
{
    public class Ansatt
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "navn")]
        public string Navn { get; set; }

        [JsonProperty(PropertyName = "avdeling")]
        public string Avdeling { get; set; }

        [JsonProperty(PropertyName = "rolle")]
        public Rolle? Rolle { get; set; }
    }
}
