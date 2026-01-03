using E2Z.DB.ORM.Context;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Repositories
{
    public class CartRepository : Repository<CartDetail>, ICartRepository
    {
        public CartRepository(E2ZDbContext db) : base(db) { }

        public Task<List<CartDetail>> ListByUserAsync(Guid userId, CancellationToken ct = default)
        {
            return _set.AsNoTracking()
                       .Where(cd => cd.UserId == userId)
                       .ToListAsync(ct);
        }
        public Task<CartDetail?> GetByIdForUserAsync(int id, Guid userId, CancellationToken ct = default)
        {
            return _set.AsNoTracking()
                       .FirstOrDefaultAsync(cd => cd.ID == id && cd.UserId == userId, ct);
        }
    }
}
