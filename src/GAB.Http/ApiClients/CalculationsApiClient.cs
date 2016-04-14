using System.Threading.Tasks;
using GAB.Core.Domain;

namespace GAB.Http.ApiClients
{
    public class CalculationsApiClient : BaseApiClient<ResourcePlan, Report>
    {
        public CalculationsApiClient(string baseUrl) 
            : base(baseUrl)
        {
        }

        public async Task<Report> CalculateCapacity(ResourcePlan resourcePlan)
        {
            const string url = "/api/calculations/capacity/resourceplan";

            return await Create(url, resourcePlan);
        }
    }
}