using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IRepository<UserProfile> _repo;
        private readonly IUnitOfWork _uow;

        public UserProfileService(IRepository<UserProfile> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<UserProfile> AddAsync(UserProfileDto dto, CancellationToken ct = default)
        {
            var entity = new UserProfile
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Gender = dto.Gender,
                Preferences = dto.Preferences,
                Email = dto.Email,
                Address = dto.Address,
                CreationTime = dto.CreationTime,
                IsLoggedIn = dto.IsLoggedIn,
                LastLoggedInTime = dto.LastLoggedInTime
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<UserProfile?> GetByIdAsync(Guid userId, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(userId, ct);
        }

        public Task<IEnumerable<UserProfile>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfile> UpdateAsync(Guid userId, UserProfileDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(userId, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.Name = dto.Name;
            entity.Gender = dto.Gender;
            entity.Preferences = dto.Preferences;
            entity.Email = dto.Email;
            entity.Address = dto.Address;
            entity.CreationTime = dto.CreationTime;
            entity.IsLoggedIn = dto.IsLoggedIn;
            entity.LastLoggedInTime = dto.LastLoggedInTime;
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid userId, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(userId, ct);
            if (entity == null) return false;
            _repo.Remove(entity);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}