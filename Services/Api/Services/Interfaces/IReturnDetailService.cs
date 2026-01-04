using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface IReturnDetailService
    {
        Task<ReturnDetail> AddAsync(ReturnDetailDto dto, CancellationToken ct = default);
        Task<ReturnDetail?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<ReturnDetail>> GetAllAsync(CancellationToken ct = default);
        Task<ReturnDetail> UpdateAsync(int id, ReturnDetailDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}