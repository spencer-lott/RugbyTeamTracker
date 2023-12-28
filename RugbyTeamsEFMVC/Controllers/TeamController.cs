using Microsoft.AspNetCore.Mvc;
using RugbyTeamsEFMVC.Models;
using RugbyTeamsEFMVC.Repositories;

namespace RugbyTeamsEFMVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Team> teams = _teamRepository.GetAll();
            return View(teams);
        }

        public IActionResult GetTeamById(int id) 
        { 
            Team team = _teamRepository.GetById(id);
            List<Team> teams = new List<Team>();
            teams.Add(team);
            return View("Index", teams);
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTeam(Team team) 
        { 
            if (!ModelState.IsValid) 
            {
                return View(team);
            }
            Team newTeam = _teamRepository.Add(team);
            return View("Index");
        }

        [HttpGet]
        public IActionResult EditTeam(int id) 
        {
            Team team = _teamRepository.GetById(id);
            return View(team);
        }

        [HttpPost]
        public IActionResult EditTeam(Team modifiedData)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedData);
            }
            Team team = _teamRepository.GetById(modifiedData.Id);
            team.Name = modifiedData.Name;
            team.City = modifiedData.City;
            team.State = modifiedData.State;
            Team updatedTeam = _teamRepository.Update(team);
            return View("Index");
        }

        public IActionResult DeleteTeam(int id)
        {
            _teamRepository.Delete(id);
            return View("Index");
        }
    }
}
