using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IUserRecentActivityService
    {
        Task<UserRecentActivity> AddAsync(UserRecentActivityDto dto, CancellationToken ct = default);
        Task<UserRecentActivity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<UserRecentActivity>> GetAllAsync(CancellationToken ct = default);
        Task<UserRecentActivity> UpdateAsync(int id, UserRecentActivityDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}