using VibeSwipe.Domain.Entities;

namespace VibeSwipe.Domain.Models
{
    public sealed class AccessToken
    {
        public Guid TokenID { get; set; }
        public DateTime ExpiresAt { get; set; }
        public User User { get; set; }
    }
}
