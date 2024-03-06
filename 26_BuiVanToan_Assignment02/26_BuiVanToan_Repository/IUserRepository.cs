using _26_BuiVanToan_BusinessObject;

namespace _26_BuiVanToan_Repository
{
    public interface IUserRepository 
    {
        Task<IEnumerable<User>> GetUsersAsync();
        //User GetDefaultUser();
        Task<User> GetUserAsync(int userId);
        Task<User> AddUserAsync(User newUser);
        Task<User> UpdateUserAsync(User updatedUser);
        Task DeleteUserAsync(int userId);
        Task<User> LoginAsync(string email, string password);
    }
}
