using EcomLDC.Application.Interfaces.Carts;
using EcomLDC.Domain.Entities.Carts;
using EcomLDC.Domain.Entities.Users;
using EcomLDC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Repositories.Carts
{
    public class CartRepository(EcomLDCDbContext db) : ICartRepository
    {
        public Task<Cart?> GetForUserAsync(Guid userId, CancellationToken ct = default) =>
            db.Carts.Include(c => c.Items) // Include hya method mwgoda fl Entity Framework bt5ly al query ygeb el related entities (fl hal da bgeb el cart items ely mwgoda fl cart)
                    .FirstOrDefaultAsync(c => c.UserId == userId, ct);

        public async Task ClearAsync(Guid cartId, CancellationToken ct = default)
        {
            var items = db.CartItems.Where(i => i.CartId == cartId);
            db.CartItems.RemoveRange(items); // RemoveRange hya method mwgoda fl Entity Framework btms7 kaza entity fl database fl nafs el wa2t //b3ml foreach 3la kol wa7da w bms7ha
            var cart = await db.Carts.FirstOrDefaultAsync(c => c.id == cartId, ct);
            if (cart is not null) cart.UpdatedAtTime = DateTime.Now;
        }

        public async Task<bool> UpdateQtyAsync(Guid userId, Guid itemId, int quantity, CancellationToken ct = default)
        {
            var item = await db.CartItems
                .Join(db.Carts, i => i.CartId, c => c.id, (i, c) => new { i, c }) // b3ml join ben el cart items w el carts 34an at2kd en el item dah mwgod fl cart bta3 el user dah
                .Where(x => x.i.Id == itemId && x.c.UserId == userId) // ba5od el item ely byshbah al condition ally ana 3ayzo
                .Select(x => x.i) // ba5od el cart item bas msh el cart
                .FirstOrDefaultAsync(ct); // FirstOrDefaultAsync hya method mwgoda fl Entity Framework btgeb awl record byshbah al condition ally ana 3ayzo w lw ma l2tsh byrg3 null

            //SELECT TOP(1) [i].[Id], [i].[CartId], [i].[Quantity], [i].[PriceAtAdd], [i].[ProductId], [i].[ProductName]
            // FROM[CartItems] AS[i]
            //INNER JOIN[Carts] AS[c] ON[i].[CartId] = [c].[Id]
            //WHERE[i].[Id] = @itemId AND[c].[UserId] = @userId;


            if (item is null) return false;

            item.Quantity = quantity;
            var cart = await db.Carts.FirstAsync(c => c.id == item.CartId, ct); // ba5od el cart bta3t el item 34an a3ml update lel updatedAtTime
            cart.UpdatedAtTime = DateTime.Now;
            return true;
        }

        public async Task<bool> RemoveItemAsync(Guid userId, Guid itemId, CancellationToken ct = default)
        {
            var tuple = await db.CartItems
                .Join(db.Carts, i => i.CartId, c => c.id, (i, c) => new { i, c })
                .Where(x => x.i.Id == itemId && x.c.UserId == userId)
                .FirstOrDefaultAsync(ct);


            /* SELECT TOP(1) 
     [i].[Id], [i].[CartId], [i].[Quantity], [i].[PriceAtAdd], [i].[ProductId], [i].[ProductName],
     [c].[Id], [c].[UserId], [c].[UpdatedAtTime], [c].[CreatedAtTime]
 INNER JOIN[Carts] AS[c] ON[i].[CartId] = [c].[Id]
 WHERE[i].[Id] = @itemId AND[c].[UserId] = @userId;*/

            if (tuple is null) return false;

            db.CartItems.Remove(tuple.i);
            tuple.c.UpdatedAtTime = DateTime.Now;
            return true;
        }

        public async Task<Cart> EnsureForUserAsync(Guid userId, CancellationToken ct = default)
        {
            var c = await GetForUserAsync(userId, ct);
            if (c is not null) return c;

            c = new Cart { UserId = userId };
            await db.Carts.AddAsync(c, ct);
            await db.SaveChangesAsync(ct); // 34an a7fz el cart el gdida fl database w a5od el id bta3ha
            return c;
        }

        public async Task AddItemAsync(Guid cartId, CartItem item, CancellationToken ct = default) => await db.CartItems.AddAsync(item, ct);
  

  public Task<CartItem?> GetItemForUserAsync(Guid userId, Guid productId, CancellationToken ct = default) =>
        db.CartItems.Join(db.Carts, i => i.CartId, c => c.id, (i, c) => new { i, c })
                    .Where(x => x.c.UserId == userId && x.i.ProductId == productId)
                    .Select(x => x.i)
                    .FirstOrDefaultAsync(ct);
    }
}
