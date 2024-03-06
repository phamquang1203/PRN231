using _26_BuiVanToan_BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_DataAccess
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();

        private UserDAO()
        {

        }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var context = new eStoreContext();
            return await context.Users.Include(u => u.Publisher).Include(u => u.Role).ToListAsync();    
        }
        public async Task<User> GetUsersAsync(string email)
        {
            var context = new eStoreContext();
            return await context.Users.Include(u => u.Publisher)
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u=>u.EmailAddress.Equals(email.ToLower()));
        }
        public async Task<User> GetUserAsync(int userId)
        {
            var db = new eStoreContext();
            return await db.Users
                .Include(user => user.Publisher)
                .Include(user => user.Role)
                .SingleOrDefaultAsync(user => user.UserId == userId);
        }

        public async Task<User> AddUserAsync(User user)
        {
            if(GetUsersAsync(user.EmailAddress)!=null) {
                throw new Exception();

            }
            var context = new eStoreContext();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUserAsync(User user)
        {
            if (GetUsersAsync(user.EmailAddress) != null)
            {
                throw new Exception();

            }
            var context = new eStoreContext();
             context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteUserAsync(int userID)
        {
            User user = await GetUserAsync(userID);
            if (user==null)
            {
                throw new Exception();

            }
            var context = new eStoreContext();
            context.Users.Remove(user);
            await context.SaveChangesAsync();
       
        }
    }
}
