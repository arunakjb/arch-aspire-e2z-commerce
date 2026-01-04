using E2Z.DB.ORM.Models;

namespace E2Z.DB.ORM.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<CartDetail>
    {
        Task<List<CartDetail>> ListByUserAsync(Guid userId, CancellationToken ct = default);
        Task<CartDetail?> GetByIdForUserAsync(int id, Guid userId, CancellationToken ct = default);
    }
}
