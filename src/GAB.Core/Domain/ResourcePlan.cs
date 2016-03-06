using System;
using GAB.Core.Domain.ResourcePlanning;
using Newtonsoft.Json;

namespace GAB.Core.Domain
{
    public class ResourcePlan
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "from")]
        public DateTime From { get; set; }

        [JsonProperty(PropertyName = "to")]
        public DateTime To { get; set; }

        [JsonProperty(PropertyName = "employeeId")]
        public string EmployeeId { get; set; }
        
        public static ResourcePlan CreateForToday(string employeeId)
        {
            return new ResourcePlan
            {
                From = WorkDayDates.GetStartTime(DateTime.UtcNow),
                To = WorkDayDates.GetEndTime(DateTime.UtcNow),
                EmployeeId = employeeId
            };
        }
    }
}