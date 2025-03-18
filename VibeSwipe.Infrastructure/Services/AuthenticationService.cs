using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using VibeSwipe.Domain.Contracts;
using VibeSwipe.Domain.Contracts.Repos;
using VibeSwipe.Domain.Entities;
using VibeSwipe.Domain.Models;
using VibeSwipe.Infrastructure.Options;

namespace VibeSwipe.Infrastructure.Services
{
    public sealed class AuthenticationService : BackgroundService, IAuthenticationService
    {
        private readonly IUserRepo _userRepo;
        private readonly IOptions<AuthenticationOptions> _options;

        private List<AccessToken> tokenStore = new();

        public AuthenticationService(IUserRepo userRepo, IOptions<AuthenticationOptions> options)
        {
            _userRepo = userRepo;
            _options = options;
        }

        public async Task<AccessToken?> AuthenticateUserAsync(string email, string hashedPassword)
        {
            var user = await _userRepo.GetUserByEmail(email);

            if (user is null || user.HashedPassword != hashedPassword)
                return null;

            return CreateToken(user);
        }

        public async Task<AccessToken?> AuthenticateTokenAsync(Guid tokenId)
        {
            var token = tokenStore.Where(x => x.TokenID == tokenId).FirstOrDefault();

            if (token is null || token.ExpiresAt < DateTime.Now)
            {
                tokenStore.Remove(token);
                return null;
            }

            token.ExpiresAt = DateTime.Now + _options.Value.AccessTokenLifeTime;

            return token;
        }

        private AccessToken CreateToken(User user)
        {
            return new AccessToken
            {
                TokenID = Guid.NewGuid(),
                User = user,
                ExpiresAt = DateTime.Now + _options.Value.AccessTokenLifeTime
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            tokenStore.RemoveAll(x => x.ExpiresAt < DateTime.Now);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}
