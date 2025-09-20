using EcomLDC.Application.UseCases.Users.Login.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Users.Register.Commands
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand> // AbstractValidator class gahiz FluentValidation betwarrath menno w tektob feeh qawa3ed el ta7a22 (Validation Rules) lel no3 T badal ma tektob if-statements motakarrera fel handler.
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty(); // RuleFor method bt5od expression bet3arref el property elly 3ayz a7ot 3aleha el rule w fe el example da ana 3ayz a7ot rule 3ala el Username property.
            RuleFor(x => x.Password).NotEmpty(); // RuleFor method bt5od expression bet3arref el property elly 3ayz a7ot 3aleha el rule w fe el example da ana 3ayz a7ot rule 3ala el Password property.
        }
    }
}
