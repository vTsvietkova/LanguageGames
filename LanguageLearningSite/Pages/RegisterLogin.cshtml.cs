using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LanguageLearning;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace LanguageLearningSite.Pages
{
    public class RegisterLoginModel : PageModel
    {
        private UserManager manager = new();
        [BindProperty]
        public User user { get; set; }
        [BindProperty]
        public Login login { get; set; }
        public IActionResult OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToPage("Profile");
            }
            return Page();
        }

        public IActionResult OnPostRegister()
        {
            ModelValidationState pairs = ModelState.ValidationState;
            ValueEnumerable entries = ModelState.Values;
            bool emailIsCorrect = entries.ElementAt(2).Errors.Count == 0;
            bool iscorrect = entries.ElementAt(3).Errors.Count == 0;
            bool isalsocorrect = entries.ElementAt(4).Errors.Count == 0;
            bool UserIsCorrect = (iscorrect && emailIsCorrect && isalsocorrect);
            if(UserIsCorrect)
            {
                try
                {
                    manager.Create(user);
                }
                catch
                {
                    return Page();
                }
            }
            return Page();
        }

        public IActionResult OnPostLogin()
        {
            ModelValidationState pairs = ModelState.ValidationState;
            ValueEnumerable entries = ModelState.Values;
            bool iscorrect = entries.ElementAt(4).Errors.Count == 0;
            bool isalsocorrect = entries.ElementAt(3).Errors.Count == 0;
            bool UserIsCorrect = (iscorrect && isalsocorrect);
            if (UserIsCorrect)
            {
                int userid = manager.Login(login);
                if(userid != 0)
                {
                    User user = manager.Get(userid);
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.Username));
                    claims.Add(new Claim("id", userid.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("Index");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }

    }
}