using TextilesGeomar.API.Models;

namespace TextilesGeomar.API.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Address { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public string Password { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
    }
}
