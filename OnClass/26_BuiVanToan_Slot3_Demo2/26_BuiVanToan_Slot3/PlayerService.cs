using _26_BuiVanToan_Slot3.Dto.Player;
using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_Slot3
{


    public class PlayerService : IPlayerService
    {
        private readonly CodeFirstDemoContext _dbContext;

    public PlayerService(CodeFirstDemoContext dbContext)
        {
            _dbContext = dbContext;
        }
 
        public Task CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlayerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            throw new NotImplementedException();
        }

        Task<GetPlayerDetailResponse> IPlayerService.GetPlayerDetailAsync(int id)
        {
            throw new NotImplementedException();
        }
    }


}
