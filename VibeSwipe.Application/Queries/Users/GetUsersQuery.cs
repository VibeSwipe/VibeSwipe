using MediatR;
using Microsoft.Extensions.Logging;
using VibeSwipe.Application.Models.DTOs;
using VibeSwipe.Domain.Contracts.Repos;

namespace VibeSwipe.Application.Queries.Users
{
    public sealed record GetUsersQuery() : IRequest<List<UserDto>?>;

    public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>?>
    {
        private readonly IUserRepo _userRepo;
        private readonly ILogger<GetUsersQueryHandler> _logger;

        public GetUsersQueryHandler(IUserRepo userRepo, ILogger<GetUsersQueryHandler> logger)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        public async Task<List<UserDto>?> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepo.GetUsers();
                return users.Select(x => UserDto.FromUser(x)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug("Error while getting users: {e}", e.Message);
                return null;
            }
        }
    }
}
