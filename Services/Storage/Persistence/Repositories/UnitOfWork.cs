using E2Z.DB.ORM.Context;
using E2Z.DB.ORM.Repositories.Interfaces;
namespace E2Z.DB.ORM.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly E2ZDbContext _db;
        public UnitOfWork(E2ZDbContext db) => _db = db;

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
