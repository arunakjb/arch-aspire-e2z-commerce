using E2Z.Api.Infrastructure.Identity;
using E2Z.Api.Models;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.Api.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repo;
        private readonly IRepository<Product> _products;
        private readonly IUnitOfWork _uow;
        private readonly IUserContext _user;

        public CartService(ICartRepository repo,
                       IRepository<Product> products,
                       IUnitOfWork uow,
                       IUserContext user)
        {
            _repo = repo;
            _products = products;
            _uow = uow;
            _user = user;
        }

        public async Task<CartDetail> AddCartItemAsync(CartDetailsDto dto, CancellationToken ct = default)
        {
            var productExists = await _products.AnyAsync(p => p.ID == dto.ProductId, ct);
            if (!productExists) throw new ArgumentException("Product not found");

            var entity = new CartDetail
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                UserId = _user.UserId,
                IsBought = false,
                IsDeleted = false
            };

            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity;

        }

        public async Task<bool> DeleteCartItemAsync(int cartId, CancellationToken ct = default)
        {
            var cart = await _repo.GetByIdForUserAsync(cartId, _user.UserId, ct);
            if (cart is null) return false;

            _repo.Remove(cart);
            await _uow.SaveChangesAsync(ct);
            return true;
        }

        public Task<CartDetail?> GetCartItemByIdAsync(int cartId, CancellationToken ct = default)
        {
            return _repo.GetByIdForUserAsync(cartId, _user.UserId, ct);
        }

        public Task<List<CartDetail>> GetUserCartAsync(CancellationToken ct = default)
        {
            return _repo.ListByUserAsync(_user.UserId, ct);
        }
    }
}