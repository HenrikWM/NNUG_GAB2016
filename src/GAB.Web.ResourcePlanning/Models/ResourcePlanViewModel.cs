using System;

namespace GAB.Web.ResourcePlanning.Models
{
    public class ResourcePlanViewModel
    {
        public string Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string EmployeeName { get; set; }
    }
}