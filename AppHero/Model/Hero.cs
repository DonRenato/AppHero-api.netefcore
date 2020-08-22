using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppHero.Model
{
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }
        public SecretIdentity secretIdentity { get; set; }
        public List<BattleHero> battlesHeroes { get; set; }
        public List<Weapon> weapons { get; set; }


    }
}
