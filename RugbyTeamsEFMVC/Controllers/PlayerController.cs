using Microsoft.AspNetCore.Mvc;
using RugbyTeamsEFMVC.Models;
using RugbyTeamsEFMVC.Repositories;

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
    }
}
