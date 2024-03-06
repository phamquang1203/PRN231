using _26_BuiVanToan_BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_DataAccess
{
    public class PublisherDAO

    {
        private static PublisherDAO instance;
        public static readonly object instanceLock = new object();
        public PublisherDAO() { }
        public static PublisherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PublisherDAO();

                    }
                    return instance;
                }
            }
        }
        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            var db = new eStoreContext();
            return await db.Publishers.ToListAsync();
        }
        public  async Task<Publisher> GetPublisherAsync(int pulisherId)
        {
            var dbcontext= new eStoreContext();
            return await dbcontext.Publishers.FindAsync(pulisherId);
        }
        public async Task<Publisher> AddPublisherAsync(Publisher publisher) {
            var context = new eStoreContext();
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();
            return publisher;
        }
        public async Task<Publisher> UpdatePublisherAsync(Publisher publisher) { 
            if(await GetPublisherAsync(publisher.PublisherId) == null)
            {
                throw new Exception();
            }
            var context = new eStoreContext();
             context.Publishers.Update(publisher);
            await context.SaveChangesAsync();
            return publisher;
                }
        public async Task DeletePublisherAsync(int publisherId) { 
            Publisher publisher = await GetPublisherAsync(publisherId);
            if(publisher == null)
            {
                throw new Exception();
            }
            var context =  new eStoreContext();
             context.Publishers.Remove(publisher);
            await context.SaveChangesAsync();
        }

    }
}
