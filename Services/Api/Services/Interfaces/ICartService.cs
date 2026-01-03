using E2Z.Api.Models;
using E2Z.DB.ORM.Models;

namespace E2Z.Api.Services.Interfaces
{
    public interface ICartService
    {
        Task<List<CartDetail>> GetUserCartAsync(CancellationToken ct = default);
        Task<CartDetail?> GetCartItemByIdAsync(int cartId, CancellationToken ct = default);
        Task<CartDetail> AddCartItemAsync(CartDetailsDto dto, CancellationToken ct = default);
        Task<bool> DeleteCartItemAsync(int cartId, CancellationToken ct = default);
    }
}
