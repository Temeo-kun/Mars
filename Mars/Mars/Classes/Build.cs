using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Classes
{
    public enum TypeBuild { Fabric = 1, Commercial = 2, Resedential = 3, Recreation = 4, Special = 5, Other = 6, All = 7}
    public class Build
    {
        public string name { get; set; }
        public string descript { get; set; }

        public decimal[] resNeedBuild { get; set; }
        public decimal[] nominalRes { get; set; }

        public TypeBuild type { get; set; }

    }
}
