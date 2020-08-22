using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppHero.Model
{
    public class Battle
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public List<BattleHero> battlesHeroes { get; set; }

    }
}
