using Mars.Classes;
using Mars.MUB_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.City
{
    class Player
    {
        string cityName { get; set;}
        List<Building> buildings { get; set; }

        List<Bonus> bonuses { get; set; }
        List<Bonus> globalbonuses { get; set; }
        List<ActiveModifier> modifiers { get; set; }
        List<ActiveModifier> globalModifier { get; set; }

        List<Upgrade> AvailableUpgrades { get; set; }
        List<Build> AvailableBuilds { get; set; }

        decimal[] resources { get; set; }

        public Player()
        {
            buildings = new List<Building>();
            bonuses = new List<Bonus>();
            globalbonuses = new List<Bonus>();
            modifiers = new List<ActiveModifier>();
            globalModifier = new List<ActiveModifier>();
            AvailableBuilds = new List<Build>();
            AvailableUpgrades = new List<Upgrade>();
            resources = new decimal[MySett.gameResCount];
        }

        public void AddModifier(ActiveModifier mdf)
        {
            switch (mdf.modifName.type)
            {
                case TypeMUB.Global:
                    globalModifier.Add(mdf);
                    break;
                case TypeMUB.All:
                    modifiers.Add(mdf);
                    foreach (var item in buildings)
                    {
                        item.buildModifiers.Add(modifiers.Last());
                    }
                    break;
                default:
                    modifiers.Add(mdf);
                    foreach (var item in buildings.Where(x => x.build.type == mdf.modifName.type))
                    {
                        item.buildModifiers.Add(modifiers.Last());
                    }
                    break;
            }        
        }

        public void AddBonus(Bonus mdf)
        {
            switch (mdf.modifName.type)
            {
                case TypeMUB.Global:
                    globalbonuses.Add(mdf);
                    break;
                case TypeMUB.All:
                    bonuses.Add(mdf);
                    foreach (var item in buildings)
                    {
                        item.buildModifiers.Add(modifiers.Last());
                    }
                    break;
                default:
                    bonuses.Add(mdf);
                    foreach (var item in buildings.Where(x => x.build.type == mdf.modifName.type))
                    {
                        item.buildModifiers.Add(modifiers.Last());
                    }
                    break;
            }
        }

        public void CalculateRes()
        {
            decimal [] r = new decimal[MySett.gameResCount];
            List<decimal[]> tempBuidlCalc = new List<decimal[]>();
            foreach (var item in buildings)
            {
                tempBuidlCalc.Add(item.TurnProduct());
            }
            for (int i = 0; i < MySett.gameResCount; i++)
            {
                decimal modifsumm = (1 + globalModifier.Sum(x => x.koefficients[i]));
                modifsumm = (modifsumm < 0) ? 0 : modifsumm;               
                decimal boostbonus = globalbonuses.Sum(x => x.boostresources[i]);
                resources[i] = resources[i] + tempBuidlCalc.Sum(x=> x[i])*modifsumm + boostbonus;
            }
        }

        public void StoreUpgrade(Building b, Upgrade up)
        {
            up.guid = Guid.NewGuid().ToString();
            resources[0] = resources[0] - up.upgradeCost;
            b.upgrades.Add(up);
        }
        public void RestoreUpgrade(Building b, Upgrade up)
        {
            resources[0] = resources[0] - up.upgradeCost*3;
            b.upgrades.RemoveAll(x => x.guid == up.guid);
        }

        public bool CheckSale(decimal[] costs)
        {
            bool f = true;
            for (int i = 0; i < MySett.gameResCount; i++)
            {
                if (resources[i] - costs[i] < 0)
                {
                    f = false;
                }
            }
            return f;
        }
        public void BuildLvlUp(Building b, BuildLevel bl, decimal[] costs)
        {
            if (CheckSale(costs))
            {
                for (int i = 0; i < MySett.gameResCount; i++)
                {
                    resources[i] = resources[i] - costs[i];
                }
                b.levelActual = bl;
            }            
        }
    }
}
