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
    }
}
