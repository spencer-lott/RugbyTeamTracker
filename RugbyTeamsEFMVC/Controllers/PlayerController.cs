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

        private void PositionsListViewBag()
        {
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
            //List<string> positions = new List<string>()
            //{
            //    "Loose-head prop",
            //    "Hooker",
            //    "Tight-head prop",
            //    "Second row",
            //    "Blind-side Flanker",
            //    "Open-side Flanker",
            //    "Number 8",
            //    "Scrum-half",
            //    "Fly-half",
            //    "Left wing",
            //    "Inside center",
            //    "Outside center",
            //    "Right wing",
            //    "Full back"
            //};
            //ViewBag.Positions = new SelectList(positions);
            PositionsListViewBag();
            return View();
        }

        [HttpPost]
        public IActionResult CreatePlayer(PlayerViewModel player) 
        { 
            if (!ModelState.IsValid) 
            {
                var teams = _playerRepository.GetAllTeams();
                ViewBag.Teams = new SelectList(teams, "Id", "Name");
                //    List<string> positions = new List<string>()
                //{
                //    "Loose-head prop",
                //    "Hooker",
                //    "Tight-head prop",
                //    "Second row",
                //    "Blind-side Flanker",
                //    "Open-side Flanker",
                //    "Number 8",
                //    "Scrum-half",
                //    "Fly-half",
                //    "Left wing",
                //    "Inside center",
                //    "Outside center",
                //    "Right wing",
                //    "Full back"
                //};
                //    ViewBag.Positions = new SelectList(positions);
                PositionsListViewBag();
                return View(player);
            }
            _playerRepository.AddPlayer(player);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPlayer(int id) 
        {
            Player player = _playerRepository.GetPlayerById(id);
            var data = new PlayerViewModel()
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
            var teams = _playerRepository.GetAllTeams();
            ViewBag.Teams = new SelectList(teams, "Id", "Name");
            //List<string> positions = new List<string>()
            //{
            //    "Loose-head prop",
            //    "Hooker",
            //    "Tight-head prop",
            //    "Second row",
            //    "Blind-side Flanker",
            //    "Open-side Flanker",
            //    "Number 8",
            //    "Scrum-half",
            //    "Fly-half",
            //    "Left wing",
            //    "Inside center",
            //    "Outside center",
            //    "Right wing",
            //    "Full back"
            //};
            //ViewBag.Positions = new SelectList(positions);
            PositionsListViewBag();
            return View(data);
        }

        [HttpPost]
        public IActionResult EditPlayer(PlayerViewModel modifiedData)
        {
            if(!ModelState.IsValid)
            {
                return View(modifiedData);
            }
            Player player = _playerRepository.GetPlayerById(modifiedData.Id);
            player.FirstName = modifiedData.FirstName;
            player.LastName = modifiedData.LastName;
            player.Notes = modifiedData.Notes;
            player.Position = modifiedData.Position;
            player.HeightFt = modifiedData.HeightFt;
            player.HeightIn = modifiedData.HeightIn;
            player.Weight = modifiedData.Weight;
            player.TeamId = modifiedData.TeamId;
            _playerRepository.UpdatePlayer(player);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePlayer(int id) 
        { 
            _playerRepository.DeletePlayer(id);
            return RedirectToAction("Index");
        }
    }
}
