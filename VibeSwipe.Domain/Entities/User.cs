using System.ComponentModel.DataAnnotations;

namespace VibeSwipe.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; set; }

        [Required]
        [Length(6, 30)]
        public string Username { get; set; } = default!;

        [Required]
        [Length(1, 30)]
        public string FirstName { get; set; } = default!;

        [Required]
        [Length(1, 50)]
        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;
        public string HashedPassword { get; set; } = default!;
        public bool ConfirmedEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastOnline { get; set; }
    }
}
