using AppHero.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    public class HeroContext : DbContext
    {
        public DbSet<Hero> heroes { get; set; }
        public DbSet<Battle> battles { get; set; }
        public DbSet<Weapon> weapons { get; set; }
        public DbSet<BattleHero> battleHeroes { get; set; }
        public DbSet<SecretIdentity> secretIdentities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HeroApp;Data Source=DESKTOP-I2HP9C3");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BattleHero>(entity =>
            {
                entity.HasKey(e => new { e.battleId, e.heroId });
            });
        }
    }
}
