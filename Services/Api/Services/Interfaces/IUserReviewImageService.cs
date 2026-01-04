using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IUserReviewImageService
    {
        Task<UserReviewImage> AddAsync(UserReviewImageDto dto, CancellationToken ct = default);
        Task<UserReviewImage?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<UserReviewImage>> GetAllAsync(CancellationToken ct = default);
        Task<UserReviewImage> UpdateAsync(int id, UserReviewImageDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}