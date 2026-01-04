using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IUserReviewService
    {
        Task<UserReview> AddAsync(UserReviewDto dto, CancellationToken ct = default);
        Task<UserReview?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<UserReview>> GetAllAsync(CancellationToken ct = default);
        Task<UserReview> UpdateAsync(int id, UserReviewDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}