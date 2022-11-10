using Application.Inventory.Queries.GetProductsSummary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    public class SummaryController : ApiControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<ProductsSummaryViewModel>> Get()
        {
            return await Mediator.Send(new GetProductsSummaryQuery());
        }
    }
}
