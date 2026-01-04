namespace E2Z.Api.Models
{
    public class UserProfileDto
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Preferences { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime? CreationTime { get; set; }
        public bool? IsLoggedIn { get; set; }
        public DateTime? LastLoggedInTime { get; set; }
    }
}