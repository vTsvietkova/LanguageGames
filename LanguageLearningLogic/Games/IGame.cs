using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningLogic.Games
{
    interface IGame
    {
        public int CalculateScore(int gameid);
        public void LoadGame(int gameid);
        public void SaveGame(int gameid);
    }
}
