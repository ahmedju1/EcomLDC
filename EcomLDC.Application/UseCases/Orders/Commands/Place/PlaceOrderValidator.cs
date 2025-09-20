using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.Commands.Place
{
    public class PlaceOrderValidator : AbstractValidator<PlaceOrderCommand>
    {
        public PlaceOrderValidator() => RuleFor(x => x.UserId).NotEmpty(); // 34an a3ml validation 3la el userId 34an ma ykonsh fady 
    }
}
