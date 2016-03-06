using System;

namespace GAB.Core.Domain.ResourcePlanning
{
    public class WorkDayDates
    {
        public static DateTime GetStartTime(DateTime startDate)
        {
            DateTime startTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, 8, 0, 0); // 08:00        

            return startTime;
        }

        public static DateTime GetEndTime(DateTime startDate)
        {
            DateTime startTime = GetStartTime(startDate);
            DateTime endTime = startTime.AddHours(8); // Start + 8 hrs

            return endTime;
        }
    }
}
