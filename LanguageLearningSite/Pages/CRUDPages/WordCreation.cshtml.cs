using Data.WordData;
using LanguageLearningLogic;
using LanguageLearningLogic.WordClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
            if(Word is null || Word.Id == 0)
            {
                return RedirectToPage("/CRUDPages/WordCreation", new { id = 0, noOfDefinitions = NoOfDefinitions });
            }
            else
            {
                return RedirectToPage("/CRUDPages/WordCreation", new { id = Word.Id, noOfDefinitions = NoOfDefinitions });
            }
           
        }
        public void OnGet(int? id, int? noOfDefinitions)
        {
            if(id is not null && id.HasValue && id.Value != 0)
            {
                Word = new WordManager(new WordDAL()).Get(id.Value);
                NoOfDefinitions = Word.Definitions.Count;
                if(NoOfDefinitions < noOfDefinitions)
                {
                    while( NoOfDefinitions < noOfDefinitions)
                    {
                        Word.Definitions.Add(new());
                        NoOfDefinitions++;
                    }
                }
            }
            else if(noOfDefinitions is not null)
            {
                NoOfDefinitions = noOfDefinitions.Value;
            }
        }

        public IActionResult OnPost()
        {
            WordManager manager = new WordManager(new WordDAL());
            try
            {
                    if (Word.Id == 0)
                    {
                        manager.Create(Word);
                    }
                    else
                    {
                        manager.Update(Word);
                    }
            }
            catch(RegexMatchTimeoutException ex)
            {
                Debug.WriteLine("Regexproblems");
            }
           
            return RedirectToPage("/WordPages/AllWords");
        }

        public IActionResult OnPostDeleteWord()
        {
            WordManager manager = new WordManager(new WordDAL());
            if(Word.Id != 0)
            {
                manager.DeleteWord(Word.Id);
            }
            return RedirectToPage("/WordPages/AllWords");
        }

        public IActionResult OnPostDeletedefinition()
        {
            return RedirectToPage("/CRUDPages/WordCreation", new {id = Word.Id});
        }
    }
}
