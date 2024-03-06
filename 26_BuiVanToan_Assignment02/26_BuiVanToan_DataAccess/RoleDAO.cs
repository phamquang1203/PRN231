using _26_BuiVanToan_BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_DataAccess
{
    public class RoleDAO
    {
        private static RoleDAO instance;
        private static readonly object instanceLock = new object();
        public RoleDAO()
        {

        }
        public static RoleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoleDAO();
                    }
                    return instance;
                }
            }
        }
     public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            var context = new eStoreContext();
            return await context.Roles.ToListAsync();
        }
        public async Task<Role> GetRoleAsync(int roleId)
        {
            var context = new eStoreContext();
            return await context.Roles.FindAsync(roleId);
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            var context = new eStoreContext();
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
            return role;    
        }
        public async Task<Role> UpdateRoleAsync(Role role)
        {
            if(await GetRoleAsync(role.RoleId)==null)
            {
                throw new Exception();
            }
            var context = new eStoreContext();  
            context.Roles.Update(role);
            await context.SaveChangesAsync();
            return role;
        }
        public async Task DeleteRoleAsync(int roleId) { 
            Role role = await GetRoleAsync(roleId);
            if(role == null)
            {
                throw new Exception();
            }
            var context= new eStoreContext();
            context.Remove(role);
            await context.SaveChangesAsync();
        }
        
    }

 }

    

