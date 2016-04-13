namespace GAB.Core.Domain.ResourcePlanning
{
    public class CapacityCalculator
    {
        public static double CalculateUtilizationForEmployee(ResourcePlan resourcePlan)
        {
            double hoursPlanned = GetHoursPlanned(resourcePlan);

            return hoursPlanned / WorkDayConstants.FullWorkDayDurationInHours * 100;
        }

        public static double CalculateUtilizationForDepartment(ResourcePlan resourcePlan)
        {
            return 0; //TODO: Implement
        }

        private static int GetHoursPlanned(ResourcePlan resourcePlan)
        {
            return (resourcePlan.To - resourcePlan.From).Hours;
        }
    }
}