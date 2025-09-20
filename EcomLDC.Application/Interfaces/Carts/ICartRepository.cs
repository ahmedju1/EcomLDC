using EcomLDC.Domain.Entities.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.Interfaces.Carts
{
    public interface ICartRepository
    {
        Task<Cart?> GetForUserAsync(Guid userId, CancellationToken ct = default);
        Task ClearAsync(Guid cartId, CancellationToken ct = default);

        // (Update + remove)return true if item found and updated, false if not found (34an lw el item msh mwgod fl cart ma a3mlsh update w arga3 false)
        Task<bool> UpdateQtyAsync(Guid userId, Guid itemId, int quantity, CancellationToken ct = default);
        Task<bool> RemoveItemAsync(Guid userId, Guid itemId, CancellationToken ct = default);

        // (Add) lw ma kansh fe cart bta3 el user da 3ml wa7ed gedid w arga3o, lw kan mwgod arga3o kda
        Task<Cart> EnsureForUserAsync(Guid userId, CancellationToken ct = default); // dah 3ashan lw el user 3ayz y7ot item fel cart w ma kansh 3ando cart abl kda a3ml wa7ed gedid

        Task AddItemAsync(Guid cartId, CartItem item, CancellationToken ct = default); // 34an a3ml add lel item fel cart

        Task<CartItem?> GetItemForUserAsync(Guid userId, Guid productId, CancellationToken ct = default); // 34an at2kd en el product msh mwgod abl ma a3ml add lel item fel cart


    }
}
