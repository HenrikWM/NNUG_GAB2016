using Newtonsoft.Json;

namespace GAB.Core.Domain
{
    using System.ComponentModel;

    public class Report
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "employeeName")]
        [DisplayName("Employee name")]
        public string EmployeeName { get; set; }

        [JsonProperty(PropertyName = "employeeDepartment")]
        [DisplayName("Employee department")]
        public string EmployeeDepartment { get; set; }

        [JsonProperty(PropertyName = "utilizationForEmployeeInPercent")]
        [DisplayName("Utilization % (Employee)")]
        public double UtilizationForEmployeeInPercent { get; set; }

        [JsonProperty(PropertyName = "utilizationForDepartmentInPercent")]
        [DisplayName("Utilization % (Department)")]
        public double UtilizationForDepartmentInPercent { get; set; }
    }
}