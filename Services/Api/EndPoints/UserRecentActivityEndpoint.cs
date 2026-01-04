using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class UserRecentActivityEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/userrecentactivity", auth: "Policy", tags: ["UserRecentActivity"]);
            endPoint.MapGet("/get/{id}", (IUserRecentActivityService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IUserRecentActivityService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IUserRecentActivityService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IUserRecentActivityService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IUserRecentActivityService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IUserRecentActivityService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IUserRecentActivityService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IUserRecentActivityService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IUserRecentActivityService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IUserRecentActivityService service)
        {
            throw new NotImplementedException();
        }
    }
}
