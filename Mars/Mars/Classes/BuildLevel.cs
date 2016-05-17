using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Classes
{
    public class BuildLevel
    {
        public int levelcount { get; private set; }
        public string levelName { get; private set; }
        public decimal[] levelModifs { get; private set; }

        public BuildLevel (int _lc, string _ln, decimal[] _lms)
        {
            levelcount = _lc;
            levelName = _ln;
            levelModifs = _lms;
        }

        public string viewLevelName
        {
            get
            {
                return levelName + " (" + levelcount.ToString() + ")";
            }
        }
    }
}
