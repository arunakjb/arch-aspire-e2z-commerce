using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class ProductsEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/products", auth: "Policy", tags: ["Products"]);
            endPoint.MapGet("/get/{id}", (IProductService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IProductService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IProductService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IProductService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IProductService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IProductService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IProductService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IProductService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IProductService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IProductService service)
        {
            throw new NotImplementedException();
        }
    }
}
