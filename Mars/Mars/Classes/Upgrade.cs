using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Classes
{
    public class Upgrade
    {
        public string UpgradeName { get; set; }
        public decimal boostCondition { get; set; }
        public decimal[] koefficients { get; set; }
    }
}
