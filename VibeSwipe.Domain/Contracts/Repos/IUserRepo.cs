using VibeSwipe.Domain.Entities;

namespace VibeSwipe.Domain.Contracts.Repos
{
    public interface IUserRepo
    {
        Task<List<User>> GetUsers();
        Task<User?> AddUser();
        Task<bool> RemoveUser();
        Task<User?> GetUserByEmail(string email);
        Task<User> UpdateUser(User user);
    }
}
