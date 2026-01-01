using E2Z.Api.Extensions;

namespace E2Z.Api.EndPoints
{
    public static class CartDetailsEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/cartdetails",auth: "Policy", tags: ["CartDetails"]);

            endPoint.MapGet("/get/{cartId}", GetByIdAsync);

            endPoint.MapGet("/get", GetAllAsync);

            endPoint.MapPost("/add", AddAsync);

            endPoint.MapDelete("/delete/{cartId}", DeleteCartById);

            endPoint.MapPut("/update/{cartId}", UpdateAsync);
        }

        private static async Task UpdateAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteCartById(int cartId)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync()
        {
            throw new NotImplementedException(); 
        }
    }
}
