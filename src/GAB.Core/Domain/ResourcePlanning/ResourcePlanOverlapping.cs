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
                throw new InvalidOperationException("resourcePlan is empty");

            if (resourcePlans == null || resourcePlans.Any() == false) return false;

            foreach (ResourcePlan existingResourcePlan in resourcePlans)
            {
                // Skip if existing plan belongs to different employee
                if (resourcePlan.EmployeeId.Equals(existingResourcePlan.EmployeeId, StringComparison.InvariantCultureIgnoreCase) == false)
                    continue;

                // Intersects at the end
                if (resourcePlan.From >= existingResourcePlan.From &&
                    resourcePlan.To <= existingResourcePlan.To)
                    return true;

                // Intersects at the start
                if (resourcePlan.From <= existingResourcePlan.From && 
                    resourcePlan.To >= existingResourcePlan.To)
                    return true;

                // Intersects at the middle
                if (resourcePlan.From <= existingResourcePlan.From && 
                    resourcePlan.To > existingResourcePlan.From)
                    return true;
            }

            return false;
        }
    }
}