namespace GAB.Core.Domain.ResourcePlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ResourcePlanOverlapping
    {
        public static bool HasOverlapping(ResourcePlan resourcePlan, IEnumerable<ResourcePlan> resourcePlans)
        {
            if (resourcePlan == null)
                throw new InvalidOperationException("resourcePlan is missing");

            if (resourcePlans == null || resourcePlans.Any() == false) return false;

            foreach (ResourcePlan existingResourcePlan in resourcePlans)
            {
                // Intersects at the end
                if (resourcePlan.From >= existingResourcePlan.From &&
                    resourcePlan.To <= existingResourcePlan.To &&
                    resourcePlan.EmployeeId.Equals(existingResourcePlan.EmployeeId, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                // Intersects at the start
                if (resourcePlan.From <= existingResourcePlan.From && 
                    resourcePlan.To >= existingResourcePlan.To && 
                    resourcePlan.EmployeeId.Equals(existingResourcePlan.EmployeeId, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                // Intersects at the middle
                if (resourcePlan.From <= existingResourcePlan.From && 
                    resourcePlan.To > existingResourcePlan.From &&
                    resourcePlan.EmployeeId.Equals(existingResourcePlan.EmployeeId, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }

            return false;
        }
    }
}