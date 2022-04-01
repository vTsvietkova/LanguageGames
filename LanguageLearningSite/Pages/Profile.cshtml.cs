using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LanguageLearning;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Diagnostics;

namespace LanguageLearningSite.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public LanguageLearning.User user { get; set; }
        private UserManager manager = new();
        public void OnGet()
        {
            try
            {
                if(int.TryParse(User.FindFirst("Id").Value, out int userid))
                {
                    user = manager.Get(userid);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        public async Task<IActionResult> OnPostOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
