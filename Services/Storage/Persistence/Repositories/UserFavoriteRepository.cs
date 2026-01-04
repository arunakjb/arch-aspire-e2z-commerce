using E2Z.DB.ORM.Context;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.DB.ORM.Repositories
{
    public class UserFavoriteRepository : Repository<UserFavorite>, IUserFavoriteRepository
    {
        public UserFavoriteRepository(E2ZDbContext context) : base(context) { }
        // Add custom methods if needed
    }
}