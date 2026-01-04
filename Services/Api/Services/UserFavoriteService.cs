using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class UserFavoriteService : IUserFavoriteService
    {
        private readonly IRepository<UserFavorite> _repo;
        private readonly IUnitOfWork _uow;

        public UserFavoriteService(IRepository<UserFavorite> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<UserFavorite> AddAsync(UserFavoriteDto dto, CancellationToken ct = default)
        {
            var entity = new UserFavorite
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                CreationTime = dto.CreationTime
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<UserFavorite?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<UserFavorite>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserFavorite> UpdateAsync(int id, UserFavoriteDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.UserId = dto.UserId;
            entity.ProductId = dto.ProductId;
            entity.CreationTime = dto.CreationTime;
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