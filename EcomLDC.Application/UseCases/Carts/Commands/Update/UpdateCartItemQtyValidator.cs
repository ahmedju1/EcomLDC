using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Commands.Update
{
    public class UpdateCartItemQtyValidator : AbstractValidator<UpdateCartItemQtyCommand>
    {
        public UpdateCartItemQtyValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ItemId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0); // quantity mynfa3sh tkon a2al mn 0
        }
    }
}
