using EcomLDC.Api.Auth;
using EcomLDC.Application.UseCases.Carts.Commands.Add;
using EcomLDC.Application.UseCases.Carts.Commands.Remove;
using EcomLDC.Application.UseCases.Carts.Commands.Update;
using EcomLDC.Application.UseCases.Carts.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomLDC.Api.Controllers
{
    [ApiController] // 34an yb2a el controller dah api controller msh mvc controller
    [Route("api/cart")] // dah el base route bta3 el controller 
    [Authorize] // 34an el user lazm ykwn authenticated 34an y3ml access lel endpoints
    public class CartController(IMediator mediator) : ControllerBase
    {
        // 1- View Cart
        // hna bgeb el cart bta3 el user elly 3amel login bas
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var userId = User.GetUserIdOrThrow();
            var res = await mediator.Send(new GetMyCartQuery(userId), ct); // b3t el query lel handler
            return Ok(res.Value);
        }

        // 2- Update quantity (qty=0 => remove)
        // hna b3ml update lel quantity bta3 ay item fel cart bta3y
        [HttpPatch("items/{itemId:guid}")] // PATCH api/cart/items/{itemId} w ast5dm el verb PATCH 34an ana bas b3ml update 3la part mn el resource msh koloh
        public async Task<IActionResult> UpdateQty([FromRoute] Guid itemId, [FromBody] UpdateQtyBody body, CancellationToken ct) // hna bygeb el itemId mn el route w el body mn el request body
        {
            var userId = User.GetUserIdOrThrow();
            var res = await mediator.Send(new UpdateCartItemQtyCommand(userId, itemId, body.Quantity), ct);
            if (!res.IsSuccess) return NotFound(new { error = res.Error });
            return NoContent();
        }

        // 3) Remove item 
        [HttpDelete("items/{itemId:guid}")] // DELETE api/cart/items/{itemId}
        public async Task<IActionResult> Remove([FromRoute] Guid itemId, CancellationToken ct)
        {
            var userId = User.GetUserIdOrThrow();
            var res = await mediator.Send(new RemoveCartItemCommand(userId, itemId), ct);
            if (!res.IsSuccess) return NotFound(new { error = res.Error });
            return NoContent();
        }

        public record UpdateQtyBody(int Quantity);// hna 3ayz a3ml bind lel body bta3 el request lma yb3t el user el quantity el gdida bta3t el item fl cart

        [HttpPost("items")] // POST api/cart/items
        public async Task<IActionResult> AddItem([FromBody] AddBody body, CancellationToken ct)
        {
            var userId = User.GetUserIdOrThrow();
            var res = await mediator.Send(new AddCartItemCommand(userId, body.ProductId, body.Quantity), ct);

            if (!res.IsSuccess)
            {
                var status = res.Error == "Product is out of stock" ? StatusCodes.Status409Conflict
                                                                    : StatusCodes.Status400BadRequest;
                return StatusCode(status, new { error = res.Error });
            }

           
            return StatusCode(StatusCodes.Status201Created);
        }

        public record AddBody(Guid ProductId, int Quantity); // hna 3ayz a3ml bind lel body bta3 el request lma yb3t el user el productId w el quantity bta3t el item elly 3ayz a3ml add lel cart
    }
}
