using Data.WordData;
using LanguageLearning.WordClasses;
using LanguageLearningLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LanguageLearningSite.Pages.GamePages
{
    public class UnjumbleModel : PageModel
    {
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public Word RandomDefinition { get; set; }
        public void OnGet()
        {
            WordManager wordManager = new WordManager(new WordDAL());
            Options = wordManager.GetAll().Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text =  a.WordString
                                          }).ToList();
            RandomDefinition = wordManager.GetRandom(1);
        }

        public IActionResult OnPost()
        {
            Word word = new WordManager(new WordDAL()).Get(Id);
            if(word != null)
            {
                if(RandomDefinition.WordString == word.WordString)
                {
                    return new RedirectToPageResult("/WordPages/Word", new {id = Id});
                }
                else
                {
                    return new RedirectToPageResult("/WordPages/Word", new { id = RandomDefinition.Id });
                }
            }
            else
            {
                return new RedirectToPageResult("Index");
            }
        }
    }
}
