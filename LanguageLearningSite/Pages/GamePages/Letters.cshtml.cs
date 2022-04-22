using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LanguageLearningLogic.Games;
using LanguageLearningLogic;
using Data.UserData;
using Data;
using Data.WordData;
using Microsoft.AspNetCore.Authorization;

namespace LanguageLearningSite.Pages.GamePages
{
    [Authorize]
    public class LettersModel : PageModel
    {
        [BindProperty]
        public string Answer { get; set; }
        [BindProperty]
        public int? gameid { get; set; }
        public LettersGame Game { get; set; }
        public void OnGet(int? id)
        {
            GameManager gameManager = new GameManager(new GameDAL(), new WordDAL());
            if (id.HasValue)
            {
                Game = (LettersGame)gameManager.GetGame(id.Value);
                gameid = id.Value;
            }
            else
            {
                Game = (LettersGame)gameManager.CreateNewGame(true, int.Parse(User.FindFirst("id").Value));
                gameid = Game.Id;
            }
        }

        public IActionResult OnPostAddAnswer()
        {
            GameManager gameManager = new GameManager(new GameDAL(), new WordDAL());
            Game = (LettersGame)gameManager.GetGame(gameid.Value);
            new GameManager(new GameDAL(), new WordDAL()).AddAnswer(Answer, Game);
            return RedirectToPage("/GamePages/Letters", new { id = Game.Id });
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
