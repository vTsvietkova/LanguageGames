using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageLearning;
using LanguageLearning.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageLearningSite.Pages
{
    public class AllWordsModel : PageModel
    {
        public List<Word> words;
        [BindProperty]
        public int WordsOnPage { get; set; }
        public int Skip { get; set; }
        private WordManager WordManager = new(new MockWordDAL());
        public void OnGet(int? skip, int show)
        {
            if(skip.HasValue)
            {
                Skip = skip.Value;
            }
            else
            {
                Skip = 0;
            }
            WordsOnPage = show;
            words = WordManager.GetAll();
        }

        public IActionResult OnPostDisplay()
        {
            return Page();
        }
    }
}
