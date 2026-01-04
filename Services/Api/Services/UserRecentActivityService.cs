using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class UserRecentActivityService : IUserRecentActivityService
    {
        private readonly IRepository<UserRecentActivity> _repo;
        private readonly IUnitOfWork _uow;

        public UserRecentActivityService(IRepository<UserRecentActivity> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<UserRecentActivity> AddAsync(UserRecentActivityDto dto, CancellationToken ct = default)
        {
            var entity = new UserRecentActivity
            {
                UserId = dto.UserId,
                ProductClicked = dto.ProductClicked,
                LastVisitedTime = dto.LastVisitedTime,
                VisitedOccurences = dto.VisitedOccurences
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<UserRecentActivity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<UserRecentActivity>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRecentActivity> UpdateAsync(int id, UserRecentActivityDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.UserId = dto.UserId;
            entity.ProductClicked = dto.ProductClicked;
            entity.LastVisitedTime = dto.LastVisitedTime;
            entity.VisitedOccurences = dto.VisitedOccurences;
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