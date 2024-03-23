using _26_BuiVanToan_Slot3.Dto.Player;

namespace _26_BuiVanToan_Slot3
{


    public interface IPlayerService {

        Task CreatePlayerAsync(CreatePlayerRequest playerRequest);

        Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest);

        Task<bool> DeletePlayerAsync(int id);

        Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id);

    }

}
