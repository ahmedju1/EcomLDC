using EcomLDC.Api.Auth;
using EcomLDC.Application.UseCases.Orders.Commands.Delete;
using EcomLDC.Application.UseCases.Orders.Commands.Place;
using EcomLDC.Application.UseCases.Orders.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomLDC.Api.Controllers
{
    [ApiController]
    [Route("api/orders")] // dah el base route bta3 el controller
    [Authorize] // 34an yb2a el controller dah api controller msh mvc controller w el user lazm ykwn authenticated 34an y3ml access lel endpoints
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        [HttpGet] // GET api/orders
        public async Task<IActionResult> List([FromQuery] int page = 1, [FromQuery] int size = 10, CancellationToken ct = default)
        {
            var userId = User.GetUserIdOrThrow(); // bgeb el user id mn el token bta3o
            var res = await mediator.Send(new GetMyOrdersQuery(userId, page, size), ct); // b3t el query lel handler 
            return Ok(res.Value); // dah el list bta3t el orders bta3ty (AC) :contentReference[oaicite:10]{index=10}
        }

        [HttpGet("{id:guid}")] // GET api/orders/{id}
        public async Task<IActionResult> Details([FromRoute] Guid id, CancellationToken ct)
        {
            var userId = User.GetUserIdOrThrow(); 
            var res = await mediator.Send(new GetMyOrderByIdQuery(userId, id), ct); // b3t el query lel handler 
            if (!res.IsSuccess) return NotFound(new { error = res.Error });
            return Ok(res.Value); // w dah details bta3t el order (items + prices ...) (AC) :contentReference[oaicite:11]{index=11}
        }

        [HttpDelete("{id:guid}")] // DELETE api/orders/{id}
        public async Task<IActionResult> SoftDelete([FromRoute] Guid id, CancellationToken ct)
        {
            var userId = User.GetUserIdOrThrow(); 
            var res = await mediator.Send(new DeleteMyOrderCommand(userId, id), ct); // b3t el command lel handler
            if (!res.IsSuccess) return NotFound(new { error = res.Error });
            return NoContent(); // w dah lw 7b2a 3ayz ams7 el order (AC) :contentReference[oaicite:12]{index=12
        }

        [HttpPost] // POST /api/orders
        public async Task<IActionResult> Place(CancellationToken ct)
        {
            var userId = User.GetUserIdOrThrow();

            var res = await mediator.Send(new PlaceOrderCommand(userId), ct); // b3t el command lel handler 

            if (!res.IsSuccess)
            {
                // law kan el error "Out of stock: ..." 
                var status = res.Error?.StartsWith("Out of stock") == true
                    ? StatusCodes.Status409Conflict //arga3 409 Conflict lw kan fe products ma3ndhash stock kfaya
                    : StatusCodes.Status400BadRequest; // lw kan error tany arga3 400 Bad Request 
                //StatusCode hya method mwgoda fl ControllerBase bt3ml return lel status code ely ana 3ayzo w bta5od el body bta3 el response
                return StatusCode(status, new { error = res.Error }); // w dah lw 7b2a 3ayz a3ml place lel order 
            }

            // 201 Created + OrderId
            return Created($"/api/orders/{res.Value}", new { orderId = res.Value }); // Created hya method mwgoda fl ControllerBase bt3ml return 201 Created w bta5od el location bta3 el resource ely et3ml create w body bta3 el response
        }
    }
}
