using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class DeliveryDetailService : IDeliveryDetailService
    {
        private readonly IRepository<DeliveryDetail> _repo;
        private readonly IUnitOfWork _uow;

        public DeliveryDetailService(IRepository<DeliveryDetail> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<DeliveryDetail> AddAsync(DeliveryDetailDto dto, CancellationToken ct = default)
        {
            var entity = new DeliveryDetail
            {
                UserId = dto.UserId,
                DeliveryAddress = dto.DeliveryAddress,
                DeliveryInstructions = dto.DeliveryInstructions,
                IsDelivered = dto.IsDelivered,
                IsCashOnDelivery = dto.IsCashOnDelivery,
                ReturnProduct = dto.ReturnProduct
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<DeliveryDetail?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<DeliveryDetail>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<DeliveryDetail> UpdateAsync(int id, DeliveryDetailDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.DeliveryAddress = dto.DeliveryAddress;
            entity.DeliveryInstructions = dto.DeliveryInstructions;
            entity.IsDelivered = dto.IsDelivered;
            entity.IsCashOnDelivery = dto.IsCashOnDelivery;
            entity.ReturnProduct = dto.ReturnProduct;
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