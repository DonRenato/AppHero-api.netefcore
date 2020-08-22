using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppHero.Model
{
    public class BattleHero
    {
        public int heroId { get; set; }
        public Hero hero { get; set; }
        public int battleId { get; set; }
        public Battle battle { get; set; }
    }
}
