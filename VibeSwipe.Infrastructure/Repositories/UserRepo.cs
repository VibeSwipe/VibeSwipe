using Microsoft.EntityFrameworkCore;
using VibeSwipe.Domain.Contracts.Repos;
using VibeSwipe.Domain.Entities;
using VibeSwipe.Infrastructure.Persistance;

namespace VibeSwipe.Infrastructure.Repositories
{
    public sealed class UserRepo : IUserRepo
    {
        private readonly AppDbContext _db;

        public UserRepo(AppDbContext db)
        {
            _db = db;
        }

        public Task<User?> AddUser()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public Task<bool> RemoveUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
