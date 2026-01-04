using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class UserReviewImageService : IUserReviewImageService
    {
        private readonly IRepository<UserReviewImage> _repo;
        private readonly IUnitOfWork _uow;

        public UserReviewImageService(IRepository<UserReviewImage> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<UserReviewImage> AddAsync(UserReviewImageDto dto, CancellationToken ct = default)
        {
            var entity = new UserReviewImage
            {
                BlobUrl = dto.BlobUrl,
                ReviewId = dto.ReviewId
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<UserReviewImage?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<UserReviewImage>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserReviewImage> UpdateAsync(int id, UserReviewImageDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.BlobUrl = dto.BlobUrl;
            entity.ReviewId = dto.ReviewId;
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