using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IUserFavoriteService
    {
        Task<UserFavorite> AddAsync(UserFavoriteDto dto, CancellationToken ct = default);
        Task<UserFavorite?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<UserFavorite>> GetAllAsync(CancellationToken ct = default);
        Task<UserFavorite> UpdateAsync(int id, UserFavoriteDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}