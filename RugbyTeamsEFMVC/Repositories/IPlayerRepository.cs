using RugbyTeamsEFMVC.ViewModels;
using RugbyTeamsEFMVC.Models;

namespace RugbyTeamsEFMVC.Repositories
{
    public interface IPlayerRepository
    {
        void AddPlayer(PlayerViewModel player);

        Player UpdatePlayer(Player player);

        void DeletePlayer(int id);

        Player GetPlayerById(int id);

        IEnumerable<Player> GetAllPlayers();

        IEnumerable<Player> GetPlayersByTeamId(int teamId);


    }
}
