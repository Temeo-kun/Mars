using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.MUB_classes
{
    public class Upgrade
    {
        public string guid { get; set; }
        public string upgradeName { get; set; }
        public string descript { get; set; }

        public decimal upgradeCost { get; set; }

        public decimal conditionCost { get; set; }
        public decimal boostCondition { get; set; }
        public decimal[] koefficients { get; set; }
    }
}
