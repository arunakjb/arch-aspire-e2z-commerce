using E2Z.DB.ORM.Context;
namespace E2Z.DB.ORM.Repositories.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly E2ZDbContext _db;
        public UnitOfWork(E2ZDbContext db) => _db = db;

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
