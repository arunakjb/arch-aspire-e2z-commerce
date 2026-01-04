using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repo;
        private readonly IUnitOfWork _uow;

        public ProductService(IRepository<Product> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Product> AddAsync(ProductDto dto, CancellationToken ct = default)
        {
            var entity = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category,
                ProductImageId = dto.ProductImageId,
                Features = dto.Features,
                IsReturnApplicable = dto.IsReturnApplicable,
                CreationTime = dto.CreationTime
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<Product?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateAsync(int id, ProductDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.Name = dto.Name;
            entity.Price = dto.Price;
            entity.Category = dto.Category;
            entity.ProductImageId = dto.ProductImageId;
            entity.Features = dto.Features;
            entity.IsReturnApplicable = dto.IsReturnApplicable;
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