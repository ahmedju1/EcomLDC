using Ecom.SharedKernel;
using EcomLDC.Application.UseCases.User.Login.DataModels;
using MediatR;


namespace EcomLDC.Application.UseCases.Users.Login.Commands
{
    public record LoginUserCommand(string Username, string Password)
        : IRequest<Result<LoginDto>>; // IRequest mn MediatR 34an a3ml request w a7dd al handler al mwgwd fl handler
}
