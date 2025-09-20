
using EcomLDC.Application.UseCases.Products.Query.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcomLDC.Api.Controllers
{
    [ApiController] // dah el controller dah api controller msh mvc controller
    [Route("api/products")] // dah el base route bta3 el controller
    public class ProductsController(IMediator mediator) : ControllerBase // ControllerBase msh Controller 3shan msh 3ayz el views
    {
        [HttpGet] // GET api/products
        // [FromQuery] 34an ygeb el parameters mn el query string bta3 el request 
        public async Task<IActionResult> List([FromQuery] int page = 1, [FromQuery] int size = 12, [FromQuery] bool includeOutOfStock = true, CancellationToken ct = default) 
        {
            var res = await mediator.Send(new GetProductsQuery(page, size, includeOutOfStock), ct); // b3t el query lel handler 
            return Ok(res.Value); // 200 OK + body (el body hya el list bta3t el products) List + Pagination + availability (AC) 
           
        }

        [HttpGet("{id:guid}")] // GET api/products/{id}
        public async Task<IActionResult> Details([FromRoute] Guid id, CancellationToken ct) // [FromRoute] 34an ygeb el id mn el route bta3 el request
        {
            var res = await mediator.Send(new GetProductByIdQuery(id), ct);// b3t el query lel handler 
            if (!res.IsSuccess) return NotFound(new { error = res.Error }); // 404 Not Found + body (el body hya el error message) 
            return Ok(res.Value); // 200 OK + body (el body hya el product details)
        }
    }
}
