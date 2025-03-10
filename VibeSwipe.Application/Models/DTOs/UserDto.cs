using VibeSwipe.Domain.Entities;

namespace VibeSwipe.Application.Models.DTOs
{
    public record UserDto(string FirstName, string LastName, string Email, DateTime LastOnline)
    {
        public static UserDto FromUser(User user) 
            => new UserDto(user.FirstName, user.LastName, user.Email, user.LastOnline);
    }
}
