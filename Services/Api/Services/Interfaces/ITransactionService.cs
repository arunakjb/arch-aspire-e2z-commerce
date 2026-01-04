using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> AddAsync(TransactionDto dto, CancellationToken ct = default);
        Task<Transaction?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken ct = default);
        Task<Transaction> UpdateAsync(int id, TransactionDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}