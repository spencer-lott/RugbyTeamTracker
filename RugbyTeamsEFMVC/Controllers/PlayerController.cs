using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RugbyTeamsEFMVC.Models;
using RugbyTeamsEFMVC.Repositories;
using RugbyTeamsEFMVC.ViewModels;

namespace RugbyTeamsEFMVC.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository) 
        { 
            _playerRepository = playerRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Player> players = _playerRepository.GetAllPlayers();
            return View(players);
        }

        [HttpGet]
        public IActionResult CreatePlayer()
        {
            var teams = _playerRepository.GetAllTeams();
            ViewBag.Teams = new SelectList(teams, "Id", "Name");
            List<string> positions = new List<string>()
            {
                "Loose-head prop",
                "Hooker",
                "Tight-head prop",
                "Second row",
                "Blind-side Flanker",
                "Open-side Flanker",
                "Number 8",
                "Scrum-half",
                "Fly-half",
                "Left wing",
                "Inside center",
                "Outside center",
                "Right wing",
                "Full back"
            };
            ViewBag.Positions = new SelectList(positions);
            return View();
        }

        [HttpPost]
        public IActionResult CreatePlayer(PlayerViewModel player) 
        { 
            if (!ModelState.IsValid) 
            {
                var teams = _playerRepository.GetAllTeams();
                ViewBag.Teams = new SelectList(teams, "Id", "Name");
                List<string> positions = new List<string>()
            {
                "Loose-head prop",
                "Hooker",
                "Tight-head prop",
                "Second row",
                "Blind-side Flanker",
                "Open-side Flanker",
                "Number 8",
                "Scrum-half",
                "Fly-half",
                "Left wing",
                "Inside center",
                "Outside center",
                "Right wing",
                "Full back"
            };
                ViewBag.Positions = new SelectList(positions);
                return View(player);
            }
            _playerRepository.AddPlayer(player);
            return RedirectToAction("Index");
        }
    }
}
