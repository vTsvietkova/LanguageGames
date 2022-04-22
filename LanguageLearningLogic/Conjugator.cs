namespace LanguageLearningLogic
{
    class Conjugator
    {
        public List<string> GetPossibleBaseForms(string word)
        {
            List<string> possibilities = new();
            word = word.ToLower();
            possibilities.Add(word);
            //nouns to singular
            possibilities.Add(CheckEnding(word, "s"));
            possibilities.Add(CheckEnding(word, "es"));
            possibilities.Add(CheckEnding(word, "zes"));
            possibilities.Add(CheckEnding(word, "ses"));
            possibilities.Add(ReplaceEnding(word, "i", "us"));
            possibilities.Add(ReplaceEnding(word, "es", "is"));
            possibilities.Add(ReplaceEnding(word, "ves", "fe"));
            possibilities.Add(ReplaceEnding(word, "ves", "f"));
            possibilities.Add(ReplaceEnding(word, "ies", "y"));
            possibilities.Add(ReplaceEnding(word, "a", "on"));
            //verbs
            possibilities.Add(CheckEnding(word, "ed"));
            possibilities.Add(CheckEnding(word, "ing"));
            possibilities.RemoveAll(null);
            return possibilities;
        }
        private string CheckEnding(string word, string ending)
        {
            if (word.EndsWith(ending))
            {
                return word.Substring(0, word.Length - ending.Length);
            }
            return null;
        }

        private string ReplaceEnding(string word, string ending, string newending)
        {
            string checkEnding = CheckEnding(word, ending);
            if (checkEnding is not null)
            {
                return checkEnding.Insert(word.Length, newending);
            }
            return null;
        }
    }
}
