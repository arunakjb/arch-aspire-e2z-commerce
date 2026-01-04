using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfile> AddAsync(UserProfileDto dto, CancellationToken ct = default);
        Task<UserProfile?> GetByIdAsync(Guid userId, CancellationToken ct = default);
        Task<IEnumerable<UserProfile>> GetAllAsync(CancellationToken ct = default);
        Task<UserProfile> UpdateAsync(Guid userId, UserProfileDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(Guid userId, CancellationToken ct = default);
    }
}