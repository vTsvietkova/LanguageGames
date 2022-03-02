using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageLearning;
using LanguageLearning.MockDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageLearningSite.Pages
{
    public class WordModel : PageModel
    {
        [BindProperty]
        public Word word { get; set; }
        private WordManager manager = new(new MockWordDAL());
        public void OnGet(int? id)
        {
            if(id.HasValue)
            {
                word = manager.Get(id.Value);
            }
            else
            {
                word = manager.GetRandom();
            }
        }
    }
}
