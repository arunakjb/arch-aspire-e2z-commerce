using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddAsync(OrderDto dto, CancellationToken ct = default);
        Task<Order?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<Order>> GetAllAsync(CancellationToken ct = default);
        Task<Order> UpdateAsync(int id, OrderDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}