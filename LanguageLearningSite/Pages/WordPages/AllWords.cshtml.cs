using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.WordData;
using LanguageLearning.WordClasses;
using LanguageLearningLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageLearningSite.Pages.WordPages
{
    public class AllWordsModel : PageModel
    {
        public List<Word> words;
        [BindProperty]
        public int WordsOnPage { get; set; }
        [BindProperty]
        public int Skip { get; set; }
        [BindProperty]
        public string Search { get; set; }
        private WordManager WordManager = new(new WordDAL());
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
            WordsOnPage = show;
            if(string.IsNullOrEmpty(search))
            {
                words = WordManager.GetAll();
            }
            else
            {
                words = WordManager.GetAllMatchingSearch(search);
            }
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/WordPages/AllWords", new { skip = 0, show = 4, search = Search });
        }

        public IActionResult OnPostDisplay()
        {
            return RedirectToPage(new { skip = Skip, show = WordsOnPage, search = Search });
        }
    }
}
