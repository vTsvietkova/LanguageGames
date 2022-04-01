using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning
{
    public class WordFilteringInclude
    {
        public bool Noun { get; set; }
        public bool Verb { get; set; }
        public bool Adjective { get; set; }
    }

    public class WordFilteringExclude
    {
        public bool Noun { get; set; }
        public bool Verb { get; set; }
        public bool Adjective { get; set; }
    }
}
