using Newtonsoft.Json;

namespace GAB.Core.Domain
{
    public class Report
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "utilizationForEmployeeInPercent")]
        public double UtilizationForEmployeeInPercent { get; set; }

        [JsonProperty(PropertyName = "utilizationForDepartmentInPercent")]
        public double UtilizationForDepartmentInPercent { get; set; }

    }
}