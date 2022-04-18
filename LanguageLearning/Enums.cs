using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning
{
    public enum PartOfSpeach
    {
        none,
        noun, 
        verb,
        adjective = 4
    }

    public enum Role
    {
        User,
        Editor,
        Admin
    }
}
