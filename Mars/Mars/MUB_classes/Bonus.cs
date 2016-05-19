using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.MUB_classes
{
    public class Bonus
    {
        int id { get; set; }
        public int turnCount { get; set; }

        public MyModifier modifName { get; set; }

        public decimal boostCondition { get; set; }
        public decimal conditionCost { get; set; }
        public decimal[] boostresources { get; set; }
    }
}
