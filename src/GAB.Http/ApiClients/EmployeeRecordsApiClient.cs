using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GAB.Core.Domain;

namespace GAB.Http.ApiClients
{
    public class EmployeeRecordsApiClient
    {
        private readonly string _baseUrl;

        public EmployeeRecordsApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<Employee> GetById(string employeeId)
        {
            string url = string.Format("/api/employees/{0}", employeeId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Employee>();
                }
            }
            return null;
        }
    }
}