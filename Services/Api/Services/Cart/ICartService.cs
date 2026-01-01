using E2Z.Api.Models;

namespace E2Z.Api.Services.Cart
{
    public interface ICartService
    {
        Task<List<object>> GetUserCartAsync();
        Task<object?> GetCartItemByIdAsync(int cartId);
        Task<object> AddCartItemAsync(CartDetailsDto dto);
        Task<bool> DeleteCartItemAsync(int cartId);

    }
}
