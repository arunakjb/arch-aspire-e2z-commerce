using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _repo;
        private readonly IUnitOfWork _uow;

        public TransactionService(IRepository<Transaction> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Transaction> AddAsync(TransactionDto dto, CancellationToken ct = default)
        {
            var entity = new Transaction
            {
                UserId = dto.UserId,
                PaymentMode = dto.PaymentMode,
                DeliveryId = dto.DeliveryId,
                AmountPaid = dto.AmountPaid,
                DiscountedAmount = dto.DiscountedAmount,
                IsTransactionSuccess = dto.IsTransactionSuccess,
                TransactionTime = dto.TransactionTime,
                InvoiceNumber = dto.InvoiceNumber
            };
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;
        }

        public Task<Transaction?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction> UpdateAsync(int id, TransactionDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) throw new KeyNotFoundException();
            entity.UserId = dto.UserId;
            entity.PaymentMode = dto.PaymentMode;
            entity.DeliveryId = dto.DeliveryId;
            entity.AmountPaid = dto.AmountPaid;
            entity.DiscountedAmount = dto.DiscountedAmount;
            entity.IsTransactionSuccess = dto.IsTransactionSuccess;
            entity.TransactionTime = dto.TransactionTime;
            entity.InvoiceNumber = dto.InvoiceNumber;
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