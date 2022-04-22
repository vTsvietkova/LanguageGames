using Data.WordData;
using LanguageLearningLogic;
using LanguageLearningLogic.WordClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageLearningSite.Pages.WordPages
{
    public class WordModel : PageModel
    {
        [BindProperty]
        public Word word { get; set; }
        private WordManager manager = new(new WordDAL());
        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                word = manager.Get(id.Value);
            }
            else
            {
                word = manager.GetRandom(1);
            }
        }

        public IActionResult OnPostDelete()
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToPage("/UserPages/AccessDenied");
            }
            WordManager manager = new(new WordDAL());
            manager.DeleteWord(word.Id);
            return RedirectToPage("/WordPages/AllWords");
        }

        public IActionResult OnPostUpdate()
        {
            if(!User.IsInRole("Admin"))
            {
                return RedirectToPage("/UserPages/AccessDenied");
            }
            return RedirectToPage("/CRUDPages/WordCreation", new {id = word.Id });
        }
    }
}
