using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class UserReviewImagesEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/userreviewimages", auth: "Policy", tags: ["UserReviewImages"]);
            endPoint.MapGet("/get/{id}", (IUserReviewImageService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IUserReviewImageService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IUserReviewImageService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IUserReviewImageService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IUserReviewImageService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IUserReviewImageService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IUserReviewImageService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IUserReviewImageService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IUserReviewImageService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IUserReviewImageService service)
        {
            throw new NotImplementedException();
        }
    }
}
