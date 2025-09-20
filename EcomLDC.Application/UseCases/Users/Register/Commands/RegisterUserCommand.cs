using Ecom.SharedKernel;
using EcomLDC.Application.UseCases.Users.User.DataModels;
using MediatR;

namespace EcomLDC.Application.UseCases.Users.Register.Commands
{
    public record RegisterUserCommand(string Username, string Email, string Password)
        : IRequest<Result<UserDto>>; // IRequest mn MediatR 34an a3ml request w a7dd al handler al mwgwd fl handler
}
