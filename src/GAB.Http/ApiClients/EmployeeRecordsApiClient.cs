using System.Collections.Generic;
using System.Threading.Tasks;
using GAB.Core.Domain;

namespace GAB.Http.ApiClients
{
    public class EmployeeRecordsApiClient : BaseApiClient<Employee, Employee>
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

        public async Task<Employee> GetById(string id)
        {
            string url = string.Format("/api/employees/{0}", id);

            return await GetById(url, id);
        }

        public async Task<Employee> Create(Employee employee)
        {
            string url = "/api/employees";

            return await Create(url, employee);
        }

        public async Task<bool> Delete(string id)
        {
            string url = string.Format("/api/employees/{0}", id);

            return await Delete(url, id);
        }

        public async Task<bool> Update(Employee employee)
        {
            string url = "/api/employees";

            return await Update(url, employee);
        }
    }
}