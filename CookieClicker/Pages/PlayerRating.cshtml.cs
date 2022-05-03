using CookieClickerLibrary.DataAccess;
using CookieClickerLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CookieClicker.Pages
{
    public class PlayerRatingModel : PageModel
    {
        [BindProperty]
        public List<Player> Players { get; set; }

        private readonly ApplicationDbContext _db;

        public PlayerRatingModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            List<Player> players = _db.Players.OrderByDescending(x => x.Cps).Take(10).ToList();
            if(players != null)
            {
                Players = players;
            }
        }
    }
}
