using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class DeliveryDetailsEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/deliverydetails", auth: "Policy", tags: ["DeliveryDetails"]);
            endPoint.MapGet("/get/{id}", (IDeliveryDetailService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IDeliveryDetailService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IDeliveryDetailService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IDeliveryDetailService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IDeliveryDetailService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IDeliveryDetailService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IDeliveryDetailService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IDeliveryDetailService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IDeliveryDetailService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IDeliveryDetailService service)
        {
            throw new NotImplementedException();
        }
    }
}
