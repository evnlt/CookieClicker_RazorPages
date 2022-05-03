using CookieClickerLibrary.DataAccess;
using CookieClickerLibrary.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookieClicker.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UserAccount UserAccount { get; set; }

        private readonly ApplicationDbContext _db;
        public LoginModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            UserAccount user = new UserAccount("test1", "12345678");
            UserAccount = user;
            //_db.UserAccounts.Add(user);
            //_db.SaveChanges();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userAccount = _db.UserAccounts.Where(x => x.Nickname == UserAccount.Nickname).FirstOrDefault();
                if (userAccount != null)
                {
                    if (userAccount.Password == UserAccount.Password)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, userAccount.Nickname)
                        };
                        var identity = new ClaimsIdentity(claims, "UserCookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync("UserCookieAuth", claimsPrincipal);

                        return RedirectToPage("/Index");
                    }
                }
            }
            return Page();
        }
    }
}
