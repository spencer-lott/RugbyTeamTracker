using RugbyTeamsEFMVC.Context;
using RugbyTeamsEFMVC.Models;
using RugbyTeamsEFMVC.ViewModels;

namespace RugbyTeamsEFMVC.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly TeamDbContext _context;

        public PlayerRepository(TeamDbContext context)
        {
            _context = context;
        }
        public void AddPlayer(PlayerViewModel player)
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Players;
        }

        public Player GetPlayerById(int id)
        {
            throw new NotImplementedException();
        }

        public Player UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Player> IPlayerRepository.GetPlayersByTeamId(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}
