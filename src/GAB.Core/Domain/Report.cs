using Newtonsoft.Json;

namespace GAB.Core.Domain
{
    public class Report
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "utilizationForEmployee")]
        public string UtilizationForEmployee { get; set; }

        [JsonProperty(PropertyName = "utilizationForDepartment")]
        public string UtilizationForDepartment { get; set; }

    }
}