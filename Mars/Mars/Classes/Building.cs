using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Classes
{
    class Building
    {
        Build build { get; set; }
        BuildLevel levelActual { get; set; }
        float condition { get; set; }
        bool fix { get; set; }

        decimal[] nominalResources { get; set; }
        List<ActiveModifier> buildModifiers { get; set; }
        List<Upgrade> upgrades { get; set; }

        public decimal[] TurnProduct()
        {
            decimal[] result = new decimal[MySett.gameResCount];

            for (int i = 0; i < MySett.gameResCount; i++)
            {
                decimal modifsumm = (1 + buildModifiers.Sum(x => x.koeffocients[i]));
                modifsumm = (modifsumm < 0) ? 0 : modifsumm;
                decimal upgradessum = (1 + upgrades.Sum(y => y.koefficients[i]));
                upgradessum = (upgradessum < 0) ? 0 : modifsumm;
                result[i] = build.nominalRes[i] * levelActual.levelModifs[i] * modifsumm * upgradessum;
            }

            return result;
        }
    }
}
