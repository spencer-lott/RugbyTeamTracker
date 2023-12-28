using RugbyTeamsEFMVC.Models;

namespace RugbyTeamsEFMVC.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        
        Team GetById(int id);

        Team Add(Team team);

        Team Update(Team team); 

        void Delete(int id); 

    }
}
