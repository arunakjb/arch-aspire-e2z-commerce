namespace E2Z.Api.Infrastructure.Identity
{
    public interface IUserContext
    {
        Guid UserId { get; }
        string? Email { get; }
        string? Name { get; }
    }
}
