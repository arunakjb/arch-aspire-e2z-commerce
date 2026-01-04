using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class ReturnDetailService : IReturnDetailService
    {
        private readonly IRepository<ReturnDetail> _repo;
        private readonly IUnitOfWork _uow;

        public ReturnDetailService(IRepository<ReturnDetail> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<ReturnDetail> AddAsync(ReturnDetailDto dto, CancellationToken ct = default)
        {
            var entity = new ReturnDetail
            {
                ProductId = dto.ProductId,
                UserId = dto.UserId,
                Reason = dto.Reason,
                IsCancelled = dto.IsCancelled,
                DeliveryId = dto.DeliveryId
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<ReturnDetail?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<ReturnDetail>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnDetail> UpdateAsync(int id, ReturnDetailDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.ProductId = dto.ProductId;
            entity.UserId = dto.UserId;
            entity.Reason = dto.Reason;
            entity.IsCancelled = dto.IsCancelled;
            entity.DeliveryId = dto.DeliveryId;
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