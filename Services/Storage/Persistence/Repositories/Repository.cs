using E2Z.DB.ORM.Context;
using E2Z.DB.ORM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E2Z.DB.ORM.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly E2ZDbContext _db;
        protected readonly DbSet<TEntity> _set;

        public Repository(E2ZDbContext db)
        {
            _db = db;
            _set = db.Set<TEntity>();
        }

        public Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
       => _set.FindAsync([id], ct).AsTask();

        public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _set.FindAsync([id], ct).AsTask();
        public Task<List<TEntity>> ListAsync(CancellationToken ct = default)
            => _set.AsNoTracking().ToListAsync(ct);

        public Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
            => _set.AsNoTracking().Where(predicate).ToListAsync(ct);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
            => _set.AnyAsync(predicate, ct);

        public Task AddAsync(TEntity entity, CancellationToken ct = default)
            => _set.AddAsync(entity, ct).AsTask();

        public void Update(TEntity entity) => _set.Update(entity);

        public void Remove(TEntity entity) => _set.Remove(entity);

    }
}
