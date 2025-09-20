using EcomLDC.Application.UseCases.Users.Login.Commands;
using EcomLDC.Application.UseCases.Users.Register.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomLDC.Api.Controllers
{
    [ApiController] // 34an yb2a el controller dah api controller msh mvc controller
    [Route("api/users")] //dah el base route bta3 el controller 
    public class UsersController(IMediator mediator) //bst5dm el mediator 3shan yb3t el commands lel handlers
        : ControllerBase // ControllerBase msh Controller 3shan msh 3ayz el views
    {

        [HttpPost("register")] // POST api/users/register
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken ct) // [FromBody] 34an ygeb el command mn el body bta3 el request
        {
            if (!ModelState.IsValid) // lw fe ay validation errors fl command (hayeb2a fe errors lw el user ma3mlsh el required fields aw 3ml validation rules ghalat)
                return ValidationProblem(ModelState); // 400 Bad Request + body (el body hya el errors) 

            var result = await mediator.Send(command, ct);// b3t el command lel handler

            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error }); // 400 Bad Request + body (el body hya el error message)

            // 201 Created + body
            return CreatedAtAction(nameof(Register), new { id = result.Value.Id }, result.Value); // CreatedAtAction hya method bt3ml 201 Created w btgeb el location header w el body (el body hya el user al gdyd)
        }


        [HttpPost("login")] // POST api/users/login 
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command, CancellationToken ct) // [FromBody] 34an ygeb el command mn el body bta3 el request
        {
            if (!ModelState.IsValid) // 400 Bad Request + body (el body hya el errors) 
                return ValidationProblem(ModelState); // ValidationProblem hya method btgeb el errors mn el ModelState w btrg3ha fl body bta3 el response 

            var result = await mediator.Send(command, ct); // b3t el command lel handler 34an y3ml login w ygeb el token lw el login kan naje7 aw ygeb error lw el login ma kansh naje7 (ya3ni lw el username aw el password ghalat)

            if (!result.IsSuccess) // lw el login ma kansh naje7
            {

                var status = result.Error?.Contains("Invalid") == true ? StatusCodes.Status401Unauthorized // 401 lw el message fih "Invalid" "Invalid username or password"
                                                                       : StatusCodes.Status404NotFound; // 404 lw el message fih "not registered" aw ay message tany "Username is not registered"
                return StatusCode(status, new { error = result.Error }); // 401 aw 404 + body (el body hya el error message) 
            }

            return Ok(result.Value); // 200 OK + body (el body hya el token)
        }
    }
}
