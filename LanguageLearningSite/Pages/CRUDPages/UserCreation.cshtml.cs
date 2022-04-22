using Data.UserData;
using LanguageLearningLogic;
using LanguageLearningLogic.UserClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageLearningSite.Pages.CRUDPages
{
    public class UserCreationModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public void OnGet(int? id)
        {
            if(id.HasValue && id.Value > 0)
            {
                UserManager manager = new(new UserDAL());
                user = manager.Get(id.Value);
            }
        }
        public IActionResult OnPost()
        {
            UserManager manager = new(new UserDAL());
            if(user.Id == 0)
            {
                manager.Create(user);
            }
            else
            {
                manager.Update(user);
            }
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            UserManager manager = new UserManager(new UserDAL());
            manager.Delete(user.Id);
            return RedirectToPage("/WordPages/AllWords");
        }
    }
}
