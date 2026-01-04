using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class UserProfileEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/userprofile", auth: "Policy", tags: ["UserProfile"]);
            endPoint.MapGet("/get/{userId}", (IUserProfileService service, Guid userId) => GetByIdAsync(service, userId));
            endPoint.MapGet("/get/all", (IUserProfileService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IUserProfileService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{userId}", (IUserProfileService service, Guid userId) => DeleteByIdAsync(service, userId));
            endPoint.MapPut("/update/{userId}", (IUserProfileService service, Guid userId) => UpdateAsync(service, userId));
        }

        private static async Task UpdateAsync(IUserProfileService service, Guid userId)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IUserProfileService service, Guid userId)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IUserProfileService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IUserProfileService service, Guid userId)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IUserProfileService service)
        {
            throw new NotImplementedException();
        }
    }
}
