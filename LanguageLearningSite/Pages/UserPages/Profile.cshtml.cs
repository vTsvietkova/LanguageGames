using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Diagnostics;
using LanguageLearningLogic;
using LanguageLearning.UserClasses;
using Data.WordData;
using Data.UserData;
using Microsoft.AspNetCore.Authorization;

namespace LanguageLearningSite.Pages.UserPages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        private UserManager manager = new(new UserDAL());
        public void OnGet()
        {
            try
            {
                if (int.TryParse(User.FindFirst("Id").Value, out int userid))
                {
                    user = manager.Get(userid);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public async Task<IActionResult> OnPostOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }

        public void OnPostChange()
        {
            if(ModelState.IsValid)
            {
                manager.Update(user);
            }
        }

        public async Task<IActionResult> OnPostDelete()
        {
            manager.Delete(int.Parse(User.FindFirst("Id").Value));
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
