using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageLearning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageLearningSite.Pages
{
    public class WordModel : PageModel
    {
        [BindProperty]
        public Word word { get; set; } = new("Random", 0, 55);
        public void OnGet()
        {
        }
    }
}
