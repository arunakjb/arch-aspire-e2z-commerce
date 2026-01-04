using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class ReturnDetailsEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/returndetails", auth: "Policy", tags: ["ReturnDetails"]);
            endPoint.MapGet("/get/{id}", (IReturnDetailService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IReturnDetailService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IReturnDetailService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IReturnDetailService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IReturnDetailService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IReturnDetailService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IReturnDetailService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IReturnDetailService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IReturnDetailService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IReturnDetailService service)
        {
            throw new NotImplementedException();
        }
    }
}
