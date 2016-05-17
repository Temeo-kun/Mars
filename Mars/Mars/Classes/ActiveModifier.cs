using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Classes
{
    class ActiveModifier
    {
        int id { get; set; }
        int turnCount { get; set; }

        MyModifier modifName { get; set; }

        public decimal boostCondition { get; set; }
        public decimal[] koeffocients { get; set; }
    }
}
