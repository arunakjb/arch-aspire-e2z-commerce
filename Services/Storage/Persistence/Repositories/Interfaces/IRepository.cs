using System.Linq.Expressions;

namespace E2Z.DB.ORM.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<TEntity>> ListAsync(CancellationToken ct = default);
        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        Task AddAsync(TEntity entity, CancellationToken ct = default);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
