using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageLearning.WordClasses;
using LanguageLearningLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageLearningSite.Pages.WordPages
{
    public class WordModel : PageModel
    {
        [BindProperty]
        public Word word { get; set; }
        private WordManager manager = new();
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
    }
}
