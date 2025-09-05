using EcomLDC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetAllAsync(Guid id);
        Task AddAsync(Order order); 
    }
}
