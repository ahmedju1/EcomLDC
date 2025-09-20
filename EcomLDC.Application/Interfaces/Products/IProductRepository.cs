using EcomLDC.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default); // 34an at2kd en al product name msh mwgod abl ma a3ml add lel product
        Task AddAsync(Product p, CancellationToken ct = default); // 34an a3ml add lel product al gdyd
        Task<Product?> GetByIdAsync(Guid id, bool includeDeleted, CancellationToken ct = default); // 34an agib al product 3la asas al id bta3o
        Task<(IReadOnlyList<Product> items, int total)> GetPagedAsync(int page, int size, bool includeOutOfStock, CancellationToken ct = default); // 34an agib list mn el products bta3ty b pagination
        void Update(Product p); // 34an a3ml update lel product
        Task<bool> SoftDeleteAsync(Guid id, CancellationToken ct = default); // 34an a3ml soft delete lel product (soft delete ya3ni msh bams7 el product mn el database bs basht8l 3la enoh msh hayban fl results)
        Task<bool> RestoreAsync(Guid id, CancellationToken ct = default); // 34an arga3 el product ely etms7 soft delete


        //cart w order
        // 34an agib list mn el products 3la asas list mn el ids bta3thom (de mohema lma ab3t order w 3ayz agib el products ely fel order da)
        Task<List<Product>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default); 
    }
}
