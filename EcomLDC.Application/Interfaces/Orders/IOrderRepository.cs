using EcomLDC.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.Interfaces.Orders
{
    public interface IOrderRepository
    {
        Task<(IReadOnlyList<Order> items, int total)> GetPagedForUserAsync(Guid userId, int page, int size, CancellationToken ct = default); // 34an agib list mn el orders bta3ty b pagination
        Task<Order?> GetDetailsForUserAsync(Guid userId, Guid orderId, CancellationToken ct = default); // 34an agib al order details 3la asas al id bta3o w asas el user id 34an at2kd en el order dah leel user dah
        Task<bool> SoftDeleteAsync(Guid userId, Guid orderId, CancellationToken ct = default); // 34an a3ml soft delete lel order (soft delete ya3ni msh bams7 el order mn el database bs basht8l 3la enoh msh hayban fl results)

        //order ----  lw 7bt a3ml update lel order status fl future
        Task AddAsync(EcomLDC.Domain.Entities.Orders.Order order, CancellationToken ct = default); // 34an a3ml add lel order fl database

    }
}
