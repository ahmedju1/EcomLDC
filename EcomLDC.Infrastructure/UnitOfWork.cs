using EcomLDC.Application.Interfaces;
using EcomLDC.Infrastructure.Persistence;

namespace EcomLDC.Infrastructure
{
    public class UnitOfWork(EcomLDCDbContext db) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => db.SaveChangesAsync(ct);
    }
}
