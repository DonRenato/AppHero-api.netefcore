using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppHero.Model
{
    public class Weapon
    {
        public int id { get; set; }
        public string name { get; set; }
        public Hero hero { get; set; }
        public int heroId { get; set; }
    }
}
