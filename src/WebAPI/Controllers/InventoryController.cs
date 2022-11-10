using Application.Inventory.Commands.SellProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class InventoryController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> SellProduct(SellProductCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
