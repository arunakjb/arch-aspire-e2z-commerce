using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddAsync(ProductDto dto, CancellationToken ct = default);
        Task<Product?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default);
        Task<Product> UpdateAsync(int id, ProductDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}