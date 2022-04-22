using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using LanguageLearningLogic.Games;
using LanguageLearningLogic;
using Data;
using Data.WordData;
using Data.UserData;

namespace LanguageLearningSite.Pages.GamePages
{
    [Authorize]
    public class PracticeModel : PageModel
    {
        public List<GameBase> Games { get; set; }
        public void OnGet()
        {
            Games = new GameManager(new GameDAL(), new WordDAL(), new UserDAL()).GetAllGames(int.Parse(User.FindFirst("id").Value));
        }
    }
}
