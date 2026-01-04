using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class ProductImagesEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/productimages", auth: "Policy", tags: ["ProductImages"]);
            endPoint.MapGet("/get/{id}", (IProductImageService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IProductImageService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IProductImageService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IProductImageService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IProductImageService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IProductImageService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IProductImageService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IProductImageService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IProductImageService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IProductImageService service)
        {
            throw new NotImplementedException();
        }
    }
}
