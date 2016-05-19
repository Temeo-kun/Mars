using Mars.MUB_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Classes
{
    public class Building
    {
        public Build build { get; set; }
        public BuildLevel levelActual { get; set; }
        public decimal condition { get; set; }

        public bool fix { get; set; }

        public decimal[] nominalResources { get; set; }
        public List<ActiveModifier> buildModifiers { get; set; }
        public List<Upgrade> upgrades { get; set; }
        public List<Bonus> bonuses { get; set; }

        public decimal[] TurnProduct()
        {
            decimal[] result = new decimal[MySett.gameResCount];

            for (int i = 0; i < MySett.gameResCount; i++)
            {
                decimal modifsumm = (1 + buildModifiers.Sum(x => x.koefficients[i]));
                modifsumm = (modifsumm < 0) ? 0 : modifsumm;
                decimal upgradessum = (1 + upgrades.Sum(y => y.koefficients[i]));
                upgradessum = (upgradessum < 0) ? 0 : modifsumm;
                decimal boostbonus = bonuses.Sum(x => x.boostresources[i]);

                result[i] = build.nominalRes[i] * levelActual.levelModifs[i] * modifsumm * upgradessum + boostbonus;
            }

            return result;
        }

        public void ConditionCalculate()
        {
            if (condition > 5)
            {
                decimal modifsumm = (1 + buildModifiers.Sum(x => x.boostCondition));
                modifsumm = (modifsumm < 0) ? 0 : modifsumm;
                decimal upgradessum = (1 + upgrades.Sum(y => y.boostCondition));
                upgradessum = (upgradessum < 0) ? 0 : modifsumm;
                decimal boostbonus = bonuses.Sum(x => x.boostCondition);
                condition = condition - (10 * modifsumm * upgradessum) + boostbonus;
            }
            else
            {
                condition = 5;
            }           
        }

        public void Repair()
        {           
            decimal boostbonus = bonuses.Sum(x => x.boostCondition);
            condition = 100*levelActual.levelcount + boostbonus;
        }
    }
}
