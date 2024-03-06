using _26_BuiVanToan_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_BuiVanToan_Repository
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetPublishersAsync();
        Task<Publisher> GetPublisherAsync(int publisherId);
        Task<Publisher> AddPublisherAsync(Publisher newPublisher);
        Task<Publisher> UpdatePublisherAsync(Publisher updatedPublisher);
        Task DeletePublisherAsync(int publisherId);
    }
}
