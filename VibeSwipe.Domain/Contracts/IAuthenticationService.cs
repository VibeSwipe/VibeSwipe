using VibeSwipe.Domain.Models;

namespace VibeSwipe.Domain.Contracts
{
    public interface IAuthenticationService
    {
        Task<AccessToken> AuthenticateUser(string email, string hashedPassword);

    }
}
