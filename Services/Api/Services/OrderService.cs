using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repo;
        private readonly IUnitOfWork _uow;

        public OrderService(IRepository<Order> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Order> AddAsync(OrderDto dto, CancellationToken ct = default)
        {
            var entity = new Order
            {
                UserId = dto.UserId,
                Quantity = dto.Quantity,
                Rating = dto.Rating,
                OriginalPrice = dto.OriginalPrice,
                DiscountedPrice = dto.DiscountedPrice,
                TransactionId = dto.TransactionId,
                ProductId = dto.ProductId
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<Order?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<Order>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateAsync(int id, OrderDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.Quantity = dto.Quantity;
            entity.Rating = dto.Rating;
            entity.OriginalPrice = dto.OriginalPrice;
            entity.DiscountedPrice = dto.DiscountedPrice;
            entity.TransactionId = dto.TransactionId;
            entity.ProductId = dto.ProductId;
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