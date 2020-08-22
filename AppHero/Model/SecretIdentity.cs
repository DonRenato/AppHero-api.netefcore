using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppHero.Model
{
    public class SecretIdentity
    {
        public int id { get; set; }
        public string realName { get; set; }
        public Hero hero { get; set; }
        public int heroId { get; set; }

    }
}
