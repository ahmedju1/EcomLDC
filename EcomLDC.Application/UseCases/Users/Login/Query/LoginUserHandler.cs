using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces.Users;
using EcomLDC.Application.Security;
using EcomLDC.Application.UseCases.User.Login.DataModels;
using EcomLDC.Application.UseCases.Users.Login.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Users.Login.Query
{
    public class LoginUserHandler(
        IUserRepository repo,
        IPasswordHasher hasher,
        IJwtTokenService jwt) : IRequestHandler<LoginUserCommand, Result<LoginDto>> // IRequestHandler mn MediatR 34an a3ml handler ll request ally 3mltaha fl command
    {
        public async Task<Result<LoginDto>> Handle(LoginUserCommand request, CancellationToken ct) // Handle method hya al method al ra2ysya fl handler w hya ally btetnfd lma y3ml user request
        {
            var user = await repo.GetByUsernameAsync(request.Username, ct); // GetByUsernameAsync hya method mwgoda fl repository 34an agib al user 3la asas al username bta3o
            if (user is null)
                return Result.Failure<LoginDto>("Username is not registered"); // lw al user ma l2tsh byrg3 error

            if (!hasher.Verify(request.Password, user.PasswordHash)) // Verify hya method mwgoda fl IPasswordHasher 34an at2kd en al password ally adkhaltaha sah
                return Result.Failure<LoginDto>("Invalid username or password"); // lw al password msh sah byrg3 error

            var token = jwt.Create(user);   // Create hya method mwgoda fl IJwtTokenService 34an a3ml token lel user lma y3ml login
            return Result.Success(new LoginDto(token)); // lw kol 7aga kda mashi byrg3 el token fel result w ba3ml success lel operation
        }
    }
}
