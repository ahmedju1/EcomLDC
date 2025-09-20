using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.SharedKernel
{
   
    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOnTime { get; } = DateTime.UtcNow;
    }
}
