using Application.Inventory.Commands.SellProduct;
using Application.Products.Commands.UpdateProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class ProductController : ApiControllerBase
    {
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeStatus(Guid id, ChangeProductStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
