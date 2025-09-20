using EcomLDC.Application.Interfaces.Products;
using EcomLDC.Domain.Entities.Products;
using EcomLDC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Repositories.Products
{
    public class ProductRepository(EcomLDCDbContext db) : IProductRepository
    {
        public Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default) // 34an at2kd en al product name msh mwgod abl ma a3ml add lel product
            => db.Products.AnyAsync(p => p.Name == name, ct); // AnyAsync hya method mwgoda fl Entity Framework bt2kd en fe ay record mwgod fl database byshbah al condition ally ana 3ayzo

        public async Task AddAsync(Product p, CancellationToken ct = default)
            => await db.Products.AddAsync(p, ct); // AddAsync hya method mwgoda fl Entity Framework bt3ml add lel entity fel database

        public async Task<Product?> GetByIdAsync(Guid id, bool includeDeleted, CancellationToken ct = default)
            => await db.Products.FirstOrDefaultAsync(p => p.id == id && (includeDeleted || !p.IsDeleted), ct); // FirstOrDefaultAsync hya method mwgoda fl Entity Framework btgeb awl record byshbah al condition ally ana 3ayzo w lw ma l2tsh byrg3 null

        public async Task<(IReadOnlyList<Product> items, int total)> GetPagedAsync(
            int page, int size, bool includeOutOfStock, CancellationToken ct = default)
        {
            var q = db.Products.AsNoTracking().Where(p => !p.IsDeleted); // AsNoTracking hya method mwgoda fl Entity Framework bt5ly al query de read-only w msh hayb2a fe tracking lel entities ely etgeb (de btefdal fl performance lma akon msh 3ayz a3ml update 3la al entities de)
            if (!includeOutOfStock) q = q.Where(p => p.StockQty > 0); // lw msh 3ayz a3ml include lel products ely ma3ndhash stock (ya3ni stockQty = 0)

            var total = await q.CountAsync(ct); // CountAsync hya method mwgoda fl Entity Framework bte3ml count lel records ely byshbah al condition ally ana 3ayzo
            var items = await q //
                .OrderBy(p => p.Name)
                .Skip((page - 1) * size)// Skip hya method mwgoda fl Entity Framework bt5od 3dd mn el records w bt5aly el query ybda2 mn el record ely ba3do (de btefdal fl pagination 34an a3ml skip lel records ely 3mlt fetch abl kda)
                .Take(size) // Take hya method mwgoda fl Entity Framework bt5od 3dd mo3ayan mn el records
                .ToListAsync(ct); // ToListAsync hya method mwgoda fl Entity Framework btgeb el results fl list

            return (items, total);
        }

        public void Update(Product p) => db.Products.Update(p);

        public async Task<bool> SoftDeleteAsync(Guid id, CancellationToken ct = default)
        {
            var p = await db.Products.FirstOrDefaultAsync(x => x.id == id && !x.IsDeleted, ct); // lw al product ma kansh deleted abl kda
            if (p is null) return false;
            p.IsDeleted = true;
            p.UpdatedAtTime = DateTime.UtcNow;
            return true;
        }

        public async Task<bool> RestoreAsync(Guid id, CancellationToken ct = default)
        {
            var p = await db.Products.FirstOrDefaultAsync(x => x.id == id && x.IsDeleted, ct);
            if (p is null) return false;
            p.IsDeleted = false;
            p.UpdatedAtTime = DateTime.UtcNow;
            return true;
        }
        // cart w order
        public Task<List<Product>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default)
    => db.Products.Where(p => ids.Contains(p.id)).ToListAsync(ct); //ids.Contains(p.id)) btefdal fl performance 34an bt5ly al query ygeb el products ely mwgodin fl ids bs w msh kol el products ely fel database
    }
}
