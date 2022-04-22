using Data.UserData;
using LanguageLearningLogic;
using LanguageLearningLogic.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data;
using Data.WordData;
using Microsoft.AspNetCore.Authorization;

namespace LanguageLearningSite.Pages.GamePages
{
    [Authorize]
    public class UnjumbleModel : PageModel
    {
        [BindProperty]
        public string Answer { get; set; }
        [BindProperty]
        public int? gameid { get; set; }
        public UnjumbleGame Game { get; set; }
        public void OnGet(int? id)
        {
            GameManager gameManager = new GameManager(new GameDAL(), new WordDAL());
            if (id.HasValue)
            {
                Game = (UnjumbleGame)gameManager.GetGame(id.Value);
                gameid = id.Value;
            }
            else
            {
                Game = (UnjumbleGame)gameManager.CreateNewGame(false, int.Parse(User.FindFirst("id").Value));
                gameid = Game.Id;
            }
        }

        public IActionResult OnPostAddAnswer()
        {
            GameManager gameManager = new GameManager(new GameDAL(), new WordDAL());
            Game = (UnjumbleGame)gameManager.GetGame(gameid.Value);
            new GameManager(new GameDAL(), new WordDAL()).AddAnswer(Answer, Game);
            return RedirectToPage("/GamePages/Unjumble", new { id = Game.Id });
        }

        public IActionResult OnPostScrap()
        {
            new GameManager(new GameDAL(), new WordDAL()).DeleteGame(gameid.Value);
            return RedirectToPage("/GamePages/Practice");
        }

        public IActionResult OnPostFinish()
        {
            GameManager gameManager = new GameManager(new GameDAL(), new WordDAL(), new UserDAL());
            gameManager.FinishGame(gameid.Value, int.Parse(User.FindFirst("id").Value));
            return RedirectToPage("/GamePages/Practice");
        }
    }
}
