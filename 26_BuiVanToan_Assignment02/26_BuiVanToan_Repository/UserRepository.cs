using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_DataAccess;

namespace _26_BuiVanToan_Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> AddUserAsync(User newUser)
   => await UserDAO.Instance.AddUserAsync(newUser);

        public  async Task DeleteUserAsync(int userId)
       => await UserDAO.Instance.DeleteUserAsync(userId);


        //public async User GetDefaultUser()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<User> GetUserAsync(int userId)
         => await UserDAO.Instance.GetUserAsync(userId);


        public async Task<IEnumerable<User>> GetUsersAsync()
      => await UserDAO.Instance.GetUsersAsync();


        public Task<User> LoginAsync(string email, string password) { throw new NotImplementedException(); }
 

        public async Task<User> UpdateUserAsync(User updatedUser)
       => await UserDAO.Instance.UpdateUserAsync(updatedUser);
    }
}
