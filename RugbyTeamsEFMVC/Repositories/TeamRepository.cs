using Microsoft.IdentityModel.Tokens;
using RugbyTeamsEFMVC.Context;
using RugbyTeamsEFMVC.Models;

namespace RugbyTeamsEFMVC.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamDbContext _context;

        public TeamRepository(TeamDbContext context) 
        { 
            _context = context;
        }
        public IEnumerable<Team> GetAll()
        {
            return _context.Teams;

        }
        public Team GetById(int id)
        {
            return _context.Teams.Find(id);
        }

        public Team Add(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team;
        }

        public void Delete(int id)
        {
            Team team = _context.Teams.Find(id);
            if (team != null) 
            { 
                _context.Teams.Remove(team);
                _context.SaveChanges();
            }
        }


        public Team Update(Team teamModified)
        {
            _context.Update(teamModified);
            _context.SaveChanges();
            return teamModified;
        }
    }
}
