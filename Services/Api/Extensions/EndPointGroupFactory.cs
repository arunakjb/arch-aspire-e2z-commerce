namespace E2Z.Api.Extensions
{
    public static class EndPointGroupFactory
    {
        public static RouteGroupBuilder CreateGroup<T>(this IEndpointRouteBuilder app,
            string prefix,
            string? auth = null,
            string[]? tags = null
            )
        {
            var group = app.MapGroup(prefix)
                .WithTags(tags ?? [typeof(T).Name]);

            if (!string.IsNullOrEmpty(auth))
                group.RequireAuthorization(auth);

            return group;
        }

        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            EndPoints.CartDetailsEndpoint.MapEndpoints(app);
            EndPoints.DeliveryDetailsEndpoint.MapEndpoints(app);
            EndPoints.OrdersEndpoint.MapEndpoints(app);
            EndPoints.ProductsEndpoint.MapEndpoints(app);
            EndPoints.ProductImagesEndpoint.MapEndpoints(app);
            EndPoints.UserProfileEndpoint.MapEndpoints(app);
            EndPoints.UserReviewsEndpoint.MapEndpoints(app);
            EndPoints.ReturnDetailsEndpoint.MapEndpoints(app);
            EndPoints.TransactionsEndpoint.MapEndpoints(app);
            EndPoints.UserFavoritesEndpoint.MapEndpoints(app);
            EndPoints.UserProfileEndpoint.MapEndpoints(app);
            EndPoints.UserRecentActivityEndpoint.MapEndpoints(app);

        }
    }
}
