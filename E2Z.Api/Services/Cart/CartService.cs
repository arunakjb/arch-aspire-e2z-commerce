using E2Z.Api.Models;

namespace E2Z.Api.Services.Cart
{
    public class CartService : ICartService
    {
        public Task<object> AddCartItemAsync(CartDetailsDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCartItemAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<object?> GetCartItemByIdAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> GetUserCartAsync()
        {
            throw new NotImplementedException();
        }
    }
}
