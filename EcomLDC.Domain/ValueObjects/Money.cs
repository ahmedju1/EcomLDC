using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.ValueObjects
{
    // Encapsulation
    public record Money(decimal Amount, string Currency)   //  record (Immutable)
    {
        //Encapsulation
        public static Money zero (string currency) => new(0, currency);

    }
}
