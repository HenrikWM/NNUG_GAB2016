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

        public async Task<Employee> GetById(string employeeId)
        {
            string url = string.Format("/api/employees/{0}", employeeId);

            return await GetById(url, employeeId);
        }
    }
}