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
                From = WorkDayDates.GetFullDayStartTime(DateTime.UtcNow),
                To = WorkDayDates.GetFullDayEndTime(DateTime.UtcNow),
                EmployeeId = employeeId
            };
        }
        
        public static ResourcePlan Create(string employeeId, string department, DateTime startAt, DateTime endsAt)
        {
            EnsureStartAndEndAreOnSameDay(startAt, endsAt);

            return new ResourcePlan
            {
                From = startAt,
                To = endsAt,
                EmployeeId = employeeId
            };
        }

        private static void EnsureStartAndEndAreOnSameDay(DateTime startAt, DateTime endsAt)
        {
            if (startAt.Year != endsAt.Year ||
                startAt.Month != endsAt.Month ||
                startAt.Day != endsAt.Day)
                throw new InvalidOperationException(string.Format("{0} and {1} must be on the same day", startAt, endsAt));
        }
    }
}