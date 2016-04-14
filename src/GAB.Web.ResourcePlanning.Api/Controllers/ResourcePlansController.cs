using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using GAB.Core.Domain;
using GAB.Core.Domain.ResourcePlanning;
using GAB.Core.Repositories.DocumentDB;

namespace GAB.Web.ResourcePlanning.Api.Controllers
{
    public class ResourcePlansController : ApiController
    {      
        [HttpGet]
        [Route("api/resourceplans")]
        // GET: api/ResourcePlans
        public IQueryable<ResourcePlan> GetResourcePlans()
        {
            return DocumentDBRepository<ResourcePlan>.GetAllItems().AsQueryable();
        }

        // GET: api/ResourcePlans/5
        [HttpGet]
        [Route("api/resourceplans/{id}")]
        [ResponseType(typeof(ResourcePlan))]
        public IHttpActionResult GetResourcePlan(string id)
        {
            ResourcePlan resourcePlan = DocumentDBRepository<ResourcePlan>.GetItem(rp => rp.Id == id);
            if (resourcePlan == null)
            {
                return NotFound();
            }

            return Ok(resourcePlan);
        }

        // PUT: api/ResourcePlans/5
        [HttpPut]
        [Route("api/resourceplans")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResourcePlan([FromBody]ResourcePlan resourcePlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(resourcePlan.Id))
            {
                return BadRequest();
            }

            var existingResourcePlans = DocumentDBRepository<ResourcePlan>.GetAllItems();
            if (ResourcePlanOverlapping.HasOverlapping(resourcePlan, existingResourcePlans))
            {
                return new BadRequestErrorMessageResult(
                    string.Format(
                        "New resource plan starting on {0} would overlap with existing resource plan for employee {1}",
                        resourcePlan.From, resourcePlan.EmployeeId), this);
            }

            await DocumentDBRepository<ResourcePlan>.UpdateItemAsync(resourcePlan.Id, resourcePlan);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ResourcePlans
        [HttpPost]
        [Route("api/resourceplans")]
        [ResponseType(typeof(ResourcePlan))]
        public async Task<IHttpActionResult> PostResourcePlan(ResourcePlan resourcePlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingResourcePlans = DocumentDBRepository<ResourcePlan>.GetAllItems();
            if (ResourcePlanOverlapping.HasOverlapping(resourcePlan, existingResourcePlans))
            {
                return new BadRequestErrorMessageResult(
                    string.Format(
                        "New resource plan starting on {0} would overlap with existing resource plan for employee {1}",
                        resourcePlan.From, resourcePlan.EmployeeId), this);
            }

            await DocumentDBRepository<ResourcePlan>.CreateItemAsync(resourcePlan);

            return Created("api/resourceplans/{id}", new {id = resourcePlan.Id});
        }

        // DELETE: api/ResourcePlans/5
        [HttpDelete]
        [Route("api/resourceplans/{id}")]
        [ResponseType(typeof(ResourcePlan))]
        public async Task<IHttpActionResult> DeleteResourcePlan(string id)
        {
            var resourcePlan = DocumentDBRepository<ResourcePlan>.GetItem(rp => rp.Id == id);
            if (resourcePlan == null) return NotFound();

            await DocumentDBRepository<ResourcePlan>.DeleteItemAsync(id);

            return Ok(resourcePlan);
        }
    }
}