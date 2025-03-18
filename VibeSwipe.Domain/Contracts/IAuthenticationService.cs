using VibeSwipe.Domain.Models;

namespace VibeSwipe.Domain.Contracts
{
    public interface IAuthenticationService
    {
        Task<AccessToken?> AuthenticateUserAsync(string email, string hashedPassword);
        Task<AccessToken?> AuthenticateTokenAsync(Guid tokenId);

    }
}
