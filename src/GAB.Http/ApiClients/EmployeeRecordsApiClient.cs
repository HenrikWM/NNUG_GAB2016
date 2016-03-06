using System.Collections.Generic;
using System.Threading.Tasks;
using GAB.Core.Domain;

namespace GAB.Http.ApiClients
{
    public class EmployeeRecordsApiClient : BaseApiClient<Employee>
    {
        public EmployeeRecordsApiClient(string baseUrl) 
            : base(baseUrl)
        {
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            string url = "/api/employees";

            return await Get(url);
        }

        public async Task<Employee> GetById(string employeeId)
        {
            string url = string.Format("/api/employees/{0}", employeeId);

            return await GetById(url, employeeId);
        }

        public async Task<Employee> Create(Employee employee)
        {
            string url = "/api/employees";

            return await Create(url, employee);
        }
    }
}