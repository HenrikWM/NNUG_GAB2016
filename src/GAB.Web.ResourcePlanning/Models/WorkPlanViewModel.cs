using System;
using System.Collections.Generic;
using GAB.Core.Domain;

namespace GAB.Web.ResourcePlanning.Models
{
    public class WorkPlanViewModel
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Description { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<ResourcePlanViewModel> ResourcePlans { get; set; }
    }
}
