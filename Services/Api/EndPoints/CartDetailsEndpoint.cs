using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class CartDetailsEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/cartdetails", auth: "Policy", tags: ["CartDetails"]);

            endPoint.MapGet("/get/{cartId}", (ICartService cartService, int cartId) => GetByIdAsync(cartService, cartId));

            endPoint.MapGet("/get", (ICartService cartService) => GetAllAsync(cartService));

            endPoint.MapPost("/add", (ICartService cartService) => AddAsync(cartService));

            endPoint.MapDelete("/delete/{cartId}", (ICartService cartService, int cartId) => DeleteCartById(cartService, cartId));

            endPoint.MapPut("/update/{cartId}", (ICartService cartService, int cartId) => UpdateAsync(cartService, cartId));
        }

        private static async Task UpdateAsync(ICartService cartService, int cartId)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteCartById(ICartService cartService, int cartId)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(ICartService cartService)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(ICartService cartService, int cartId)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(ICartService cartService)
        {
            throw new NotImplementedException();
        }
    }
}
