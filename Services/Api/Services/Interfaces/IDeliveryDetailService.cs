using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IDeliveryDetailService
    {
        Task<DeliveryDetail> AddAsync(DeliveryDetailDto dto, CancellationToken ct = default);
        Task<DeliveryDetail?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<DeliveryDetail>> GetAllAsync(CancellationToken ct = default);
        Task<DeliveryDetail> UpdateAsync(int id, DeliveryDetailDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}