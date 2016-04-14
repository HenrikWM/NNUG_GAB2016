using System.Collections.Generic;
using System.Threading.Tasks;
using GAB.Core.Domain;

namespace GAB.Http.ApiClients
{
    public class ReportsApiClient : BaseApiClient<Report, Report>
    {
        public ReportsApiClient(string baseUrl) 
            : base(baseUrl)
        {
        }

        public async Task<IEnumerable<Report>> Get()
        {
            string url = "/api/reports";

            return await Get(url);
        }

        public async Task<Report> Create(Report report)
        {
            string url = "/api/reports";

            return await Create(url, report);
        }
    }
}