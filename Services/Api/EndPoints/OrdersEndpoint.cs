using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class OrdersEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/orders", auth: "Policy", tags: ["Orders"]);
            endPoint.MapGet("/get/{id}", (IOrderService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IOrderService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IOrderService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IOrderService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IOrderService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IOrderService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IOrderService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IOrderService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IOrderService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IOrderService service)
        {
            throw new NotImplementedException();
        }
    }
}
