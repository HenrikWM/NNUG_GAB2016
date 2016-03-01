using Newtonsoft.Json;

namespace GAB.Core.Domain
{
    public class Employee
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "navn")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "avdeling")]
        public string Department { get; set; }

        [JsonProperty(PropertyName = "rolle")]
        public Role? Role { get; set; }
    }
}
