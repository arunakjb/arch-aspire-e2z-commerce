namespace E2Z.Api.Infrastructure.Identity
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Guid UserId => Guid.Parse(_httpContextAccessor.HttpContext!.User?.FindFirst("sub")!.Value ?? Guid.Empty.ToString());
        public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirst("email")?.Value;
        public string? Name => _httpContextAccessor.HttpContext?.User?.FindFirst("name")?.Value;
    }
}
