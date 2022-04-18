using Data.WordData;
using LanguageLearning.WordClasses;
using LanguageLearningLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LanguageLearningSite.Pages.CRUDPages
{
    [Authorize(Roles ="Admin")]
    public class WordCreationModel : PageModel
    {
        [BindProperty]
        [Range(1, 15)]
        public int NoOfDefinitions { get; set; } = 1;
        [BindProperty]
        public Word Word { get; set; }
        public IActionResult OnPostSetNoOfDefinitions()
        {
            return Page();
        }
        public void OnGet(int? id, int? noOfDefinitions)
        {
            if(id is not null && id.HasValue && id.Value != 0)
            {
                Word = new WordManager(new WordDAL()).Get(id.Value);
                NoOfDefinitions = Word.Definitions.Count;
            }
            if(noOfDefinitions is not null)
            {
                NoOfDefinitions = noOfDefinitions.Value;
            }
        }

        public IActionResult OnPost()
        {
            WordManager manager = new WordManager(new WordDAL());
            if (ModelState.IsValid)
            {
                if(Word.Id == 0)
                {
                    manager.Create(Word);
                }
                else
                {
                    manager.Update(Word);
                }
            }
            else
            {
                return Page();
            }
            return RedirectToPage("/WordPages/AllWords");
        }

        public IActionResult OnPostDeleteWord()
        {
            WordManager manager = new WordManager(new WordDAL());
            manager.DeleteWord(Word.Id);
            return RedirectToPage("/WordPages/AllWords");
        }

        public IActionResult OnPostDeletedefinition()
        {
            return RedirectToPage("/CRUDPages/WordCreation", new {id = Word.Id});
        }
    }
}
