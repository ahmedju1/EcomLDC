using EcomLDC.Application.UseCases.Users.Register.Commands;
using FluentValidation;


namespace EcomLDC.Application.UseCases.Users.Register.Commands
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
        // AbstractValidator class gahiz FluentValidation betwarrath menno w tektob feeh qawa3ed el ta7a22 (Validation Rules) lel no3 T badal ma tektob if-statements motakarrera fel handler.
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3).MaximumLength(50); // al username between 3 and 50 characters
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(200); // email max length 200 characters
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6); // password minimum length 6 characters
        }
    }
}
