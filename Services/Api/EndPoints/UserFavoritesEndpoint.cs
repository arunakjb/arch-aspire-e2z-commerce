using E2Z.Api.Extensions;
using E2Z.Api.Services.Interfaces;

namespace E2Z.Api.EndPoints
{
    public static class UserFavoritesEndpoint
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endPoint = app.CreateGroup<string>("/api/userfavorites", auth: "Policy", tags: ["UserFavorites"]);
            endPoint.MapGet("/get/{id}", (IUserFavoriteService service, int id) => GetByIdAsync(service, id));
            endPoint.MapGet("/get", (IUserFavoriteService service) => GetAllAsync(service));
            endPoint.MapPost("/add", (IUserFavoriteService service) => AddAsync(service));
            endPoint.MapDelete("/delete/{id}", (IUserFavoriteService service, int id) => DeleteByIdAsync(service, id));
            endPoint.MapPut("/update/{id}", (IUserFavoriteService service, int id) => UpdateAsync(service, id));
        }

        private static async Task UpdateAsync(IUserFavoriteService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task DeleteByIdAsync(IUserFavoriteService service, int id)
        {
            throw new NotImplementedException();
        }

        private static async Task GetAllAsync(IUserFavoriteService service)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> GetByIdAsync(IUserFavoriteService service, int id)
        {
            throw new NotImplementedException();
        }

        public static async Task<IResult> AddAsync(IUserFavoriteService service)
        {
            throw new NotImplementedException();
        }
    }
}
