using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class UserReviewService : IUserReviewService
    {
        private readonly IRepository<UserReview> _repo;
        private readonly IUnitOfWork _uow;

        public UserReviewService(IRepository<UserReview> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<UserReview> AddAsync(UserReviewDto dto, CancellationToken ct = default)
        {
            var entity = new UserReview
            {
                ProductId = dto.ProductId,
                Rating = dto.Rating,
                Comments = dto.Comments,
                UserImageId = dto.UserImageId,
                UserId = dto.UserId
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<UserReview?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<UserReview>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserReview> UpdateAsync(int id, UserReviewDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.ProductId = dto.ProductId;
            entity.Rating = dto.Rating;
            entity.Comments = dto.Comments;
            entity.UserImageId = dto.UserImageId;
            entity.UserId = dto.UserId;
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) return false;
            _repo.Remove(entity);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}