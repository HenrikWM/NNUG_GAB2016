using System;

namespace GAB.Core.Domain.ResourcePlanning
{
    public class WorkDayDates
    {
        public static DateTime GetFullDayStartTime(DateTime startDate)
        {
            DateTime startTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, 8, 0, 0); // 08:00        

            return startTime;
        }

        public static DateTime GetFullDayEndTime(DateTime startDate, int workDayDurationInHours = WorkDayConstants.FullWorkDayDurationInHours)
        {
            DateTime startTime = GetFullDayStartTime(startDate);
            DateTime endTime = startTime.AddHours(workDayDurationInHours);

            return endTime;
        }
    }
}
