using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<ProductImage> AddAsync(ProductImageDto dto, CancellationToken ct = default);
        Task<ProductImage?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<ProductImage>> GetAllAsync(CancellationToken ct = default);
        Task<ProductImage> UpdateAsync(int id, ProductImageDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}