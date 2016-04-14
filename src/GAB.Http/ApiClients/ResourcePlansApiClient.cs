using System.Collections.Generic;
using System.Threading.Tasks;
using GAB.Core.Domain;

namespace GAB.Http.ApiClients
{
    public class ResourcePlansApiClient : BaseApiClient<ResourcePlan>
    {
        public ResourcePlansApiClient(string baseUrl) : base(baseUrl)
        {

        }

        public async Task<IEnumerable<ResourcePlan>> Get()
        {
            string url = "/api/resourceplans";

            return await Get(url);
        }

        public async Task<ResourcePlan> GetById(string id)
        {
            string url = string.Format("/api/resourceplans/{0}", id);

            return await GetById(url, id);
        }

        public async Task<ResourcePlan> Create(ResourcePlan resourcePlan)
        {
            string url = "/api/resourceplans";

            return await Create(url, resourcePlan);
        }

        public async Task<bool> Delete(string id)
        {
            string url = string.Format("/api/resourceplans/{0}", id);

            return await Delete(url, id);
        }

        public async Task<bool> Update(ResourcePlan resourcePlan)
        {
            string url = "/api/resourceplans";

            return await Update(url, resourcePlan);
        }
    }
}
