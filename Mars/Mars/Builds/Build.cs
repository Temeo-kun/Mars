using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Classes
{
    public class Build
    {
        public string name { get; set; }
        public string descript { get; set; }

        public decimal[] resNeedBuild { get; set; }
        public decimal[] nominalRes { get; set; }

        public TypeMUB type { get; set; }
        public decimal conditionCost { get; set; }
    }
}
