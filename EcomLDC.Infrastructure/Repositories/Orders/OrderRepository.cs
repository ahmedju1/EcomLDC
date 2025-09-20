using EcomLDC.Application.Interfaces.Orders;
using EcomLDC.Domain.Entities.Orders;
using EcomLDC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Repositories.Orders
{
    public class OrderRepository(EcomLDCDbContext db) : IOrderRepository
    {
        public async Task<(IReadOnlyList<Order> items, int total)> GetPagedForUserAsync(Guid userId, int page, int size, CancellationToken ct = default)
        {
            var q = db.Orders.AsNoTracking()
                .Where(o => o.UserId == userId && !o.IsDeleted)
                .OrderByDescending(o => o.CreatedAtTime);

            var total = await q.CountAsync(ct);
            var items = await q.Skip((page - 1) * size).Take(size)
                               .Include(o => o.Items)
                               .ToListAsync(ct);
            return (items, total);
        }

        public Task<Order?> GetDetailsForUserAsync(Guid userId, Guid orderId, CancellationToken ct = default) =>
            db.Orders.AsNoTracking().Include(o => o.Items) // 34an a3ml include lel items ely mwgoda fel order da  //LEFT JOIN [OrderItems] AS [i] ON [o].[Id] = [i].[OrderId]
        // FirstOrDefaultAsync hya method mwgoda fl Entity Framework btgeb awl record byshbah al condition ally ana 3ayzo w lw ma l2tsh byrg3 null
               .FirstOrDefaultAsync(o => o.id == orderId && o.UserId == userId && !o.IsDeleted, ct); 

        public async Task<bool> SoftDeleteAsync(Guid userId, Guid orderId, CancellationToken ct = default)
        {
            var order = await db.Orders.FirstOrDefaultAsync(o => o.id == orderId && o.UserId == userId && !o.IsDeleted, ct);
            if (order is null) return false;
            order.IsDeleted = true;
            order.UpdatedAtTime = DateTime.Now;
            return true;
        }

        //order ----  lw 7bt a3ml update lel order status fl future
        public async Task AddAsync(Order order, CancellationToken ct = default) // 34an a3ml add lel order fl database
    => await db.Orders.AddAsync(order, ct); // AddAsync hya method mwgoda fl Entity Framework bt3ml add lel entity fel database
    }
}
