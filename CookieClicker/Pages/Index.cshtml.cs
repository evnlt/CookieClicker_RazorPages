using CookieClickerLibrary.DataAccess;
using CookieClickerLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieClicker.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {

        [BindProperty]
        public Player Player { get; set; }
        [BindProperty]
        public List<Building> Buildings { get; set; }

        private UserAccount _userAccount;
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            _userAccount = _db.UserAccounts.Where(x => x.Nickname == User.Identity.Name).First();
            var player = _db.Players.Where(x => x.UserId == _userAccount.Id).First();
            if (player != null)
            {
                player.Buildings = _db.Buildings.Where(x => x.PlayerId == player.Id).ToList();
                if(player.Buildings != null)
                {
                    Player = player;
                    Buildings = player.Buildings;
                    return Page();
                }
            }
            return RedirectToPage("/Error");
        }

        public void OnPost()
        {
            var player = Player;
            if(player != null)
            {
                player.Buildings = Buildings;
                if(Buildings != null)
                {
                    _db.Players.Update(player);
                    foreach (var building in Buildings)
                    {
                        _db.Buildings.Update(building);
                    }
                    _db.SaveChanges();
                }
            }
        }
    }
}
