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
            var newPlayer = new Player()
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Notes = player.Notes,
                Position = player.Position,
                HeightFt = player.HeightFt,
                HeightIn = player.HeightIn,
                Weight = player.Weight,
                TeamId = player.TeamId
            };
            _context.Players.Add(newPlayer);
            _context.SaveChanges();
        }

        public void DeletePlayer(int id)
        {
            Player player = _context.Players.Find(id);
            if(player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Players;
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.Find(id);
        }

        public Player UpdatePlayer(Player updatedPlayer)
        {
            _context.Update(updatedPlayer);
            _context.SaveChanges();
            return updatedPlayer;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams;
        }

        IEnumerable<Player> IPlayerRepository.GetPlayersByTeamId(int teamId)
        {
            return _context.Players.Where(a => a.TeamId == teamId).ToList();
        }
    }
}
