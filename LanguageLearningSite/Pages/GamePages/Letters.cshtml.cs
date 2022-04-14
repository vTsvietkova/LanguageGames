using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LanguageLearningLogic.Games;

namespace LanguageLearningSite.Pages.GamePages
{
    public class LettersModel : PageModel
    {
        [BindProperty]
        public LettersGame Game { get; set; }
        public void OnGet()
        {
            Game = new();
        }
    }
}
