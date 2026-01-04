using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IRepository<ProductImage> _repo;
        private readonly IUnitOfWork _uow;

        public ProductImageService(IRepository<ProductImage> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<ProductImage> AddAsync(ProductImageDto dto, CancellationToken ct = default)
        {
            var entity = new ProductImage
            {
                BlobUrl = dto.BlobUrl,
                LastUpdated = dto.LastUpdated,
                ProductId = dto.ProductId
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<ProductImage?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<ProductImage>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductImage> UpdateAsync(int id, ProductImageDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.BlobUrl = dto.BlobUrl;
            entity.LastUpdated = dto.LastUpdated;
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