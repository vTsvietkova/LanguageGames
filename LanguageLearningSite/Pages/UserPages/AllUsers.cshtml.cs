using System.Collections.Generic;
using Data.UserData;
using LanguageLearningLogic;
using LanguageLearningLogic.UserClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageLearningSite.Pages.UserPages
{
    public class AllUsersModel : PageModel
    {
        public List<User> Users;
        [BindProperty]
        public int UsersOnPage { get; set; }
        [BindProperty]
        public int Skip { get; set; }
        [BindProperty]
        public string Search { get; set; }
        private UserManager Manager = new(new UserDAL());
        public void OnGet(int? skip, int show, string search)
        {
            if (skip.HasValue && skip.Value > 0)
            {
                Skip = skip.Value;
            }
            else
            {
                Skip = 0;
            }
            Search = search;
            UsersOnPage = show;
            if (string.IsNullOrEmpty(search))
            {
                Users = Manager.GetAll();
            }
            else
            {
                Users = Manager.GetAllMatchingSearch(search);
            }
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/UserPages/AllUsers", new { skip = 0, show = 4, search = Search });
        }

        public IActionResult OnPostDisplay()
        {
            return RedirectToPage(new { skip = Skip, show = UsersOnPage, search = Search });
        }
    }
}
