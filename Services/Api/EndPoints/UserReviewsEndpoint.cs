using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class UserReviewsEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/userreviews", auth: "Policy", tags: ["UserReviews"]);
            endPoint.MapGet("/get/{id}", (IUserReviewService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IUserReviewService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IUserReviewService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IUserReviewService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IUserReviewService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IUserReviewService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IUserReviewService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IUserReviewService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IUserReviewService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IUserReviewService service)
        {
            throw new NotImplementedException();
        }
    }
}
