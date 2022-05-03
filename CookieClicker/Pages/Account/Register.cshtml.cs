using CookieClickerLibrary.DataAccess;
using CookieClickerLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CookieClicker.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserAccount UserAccount { get; set; }
        private readonly ApplicationDbContext _db;
        public RegisterModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var userAccount = _db.UserAccounts.Where(x => x.Nickname == UserAccount.Nickname).FirstOrDefault();
                if (userAccount == null) // no player with same nickname
                {
                    // it's very important to create new users with this (nickname, password) constructor
                    // as it launches the proper chain of creating and populating all the folded data
                    // UserAccount -> Player -> List<Building>
                    var newUser = new UserAccount(UserAccount.Nickname, UserAccount.Password);
                    _db.UserAccounts.Add(newUser);
                    _db.SaveChanges();

                    var player = _db.Players.Find(newUser.Player.Id);
                    player.UserId = newUser.Id;
                    _db.Players.Update(player);
                    _db.SaveChanges();

                    return RedirectToPage("/Account/Login");
                }
            }
            return Page();
        }
    }
}
