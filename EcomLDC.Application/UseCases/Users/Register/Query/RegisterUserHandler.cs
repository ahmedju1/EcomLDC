using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces;
using EcomLDC.Application.Interfaces.Users;
using EcomLDC.Application.Security;
using EcomLDC.Application.UseCases.Users.Register.Commands;
using EcomLDC.Application.UseCases.Users.User.DataModels;
using EcomLDC.Domain.Entities.Users;
using MediatR;

namespace EcomLDC.Application.UseCases.Users.Register.Query
{
    public class RegisterUserHandler(
     IUserRepository repo,
     IUnitOfWork uow,
     IPasswordHasher hasher) : IRequestHandler<RegisterUserCommand, Result<UserDto>> // IRequestHandler interface betwarrath menno w tektob feeh el logic beta3 el use case.
    {
        public async Task<Result<UserDto>> Handle(RegisterUserCommand request, CancellationToken ct) // el method di hya elly betetnady lma yete3ml el registration w hya elly hatetnady
        {
            if (await repo.ExistsByUsernameAsync(request.Username, ct)) // bta5od el username mn el request w bt2kd en msh mwgod 2bl kda
                return Result.Failure<UserDto>("Username already exists"); // lw mwgod btrg3 error message

            if (await repo.ExistsByEmailAsync(request.Email, ct)) // bta5od el email mn el request w bt2kd en msh mwgod 2bl kda
                return Result.Failure<UserDto>("Email already exists"); // lw mwgod btrg3 error message

            var user = new EcomLDC.Domain.Entities.Users.User // lw msh mwgod b3ml user gdyd
            {
                Username = request.Username, // ba5od el username mn el request
                Email = request.Email, // ba5od el email mn el request
                PasswordHash = hasher.Hash(request.Password), // ba5od el password mn el request w ba3ml hash lel password 34an a7fazha b2a mn gheir ma a7faz el password bta3t el user 3ala 6abe3tha
                Role = UserRole.Customer // by default kol el users el gdod bykon role bta3hom customer
            };

            await repo.AddAsync(user, ct); // ba3ml add lel user el gdyd fel database
            await uow.SaveChangesAsync(ct); // ba7faz el changes fel database

            var dto = new UserDto(user.id, user.Username, user.Email, user.Role.ToString()); // ba3ml map ben el user entity w ben el UserDto 34an arg3 el data lel client
            return Result.Success(dto); // barg3 el dto fel result w ba3ml success lel operation
        }
    }
}
