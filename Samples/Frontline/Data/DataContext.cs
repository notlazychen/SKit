using Frontline.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().HasIndex(p => p.UserCenterId);
            modelBuilder.Entity<Player>().HasIndex(p => p.UserCode);
            modelBuilder.Entity<Player>().HasAlternateKey(p => p.NickName);
            //modelBuilder.Entity<Player>().HasMany(p => p.Items);
            //modelBuilder.Entity<Player>().HasMany(p => p.Sections);
            //modelBuilder.Entity<Player>().HasMany(p => p.Currencies);
            modelBuilder.Entity<PlayerCurrency>().HasKey(pc => new { pc.PlayerId, pc.Type });
            modelBuilder.Entity<PlayerCurrency>().HasOne<Player>().WithMany(p=>p.Currencies).IsRequired();
            modelBuilder.Entity<PlayerDungeon>().HasIndex(d => d.PlayerId);
            modelBuilder.Entity<PlayerDungeon>().HasIndex(d => new { d.Tid, d.PlayerId });
            modelBuilder.Entity<PlayerSection>().HasIndex(s => s.PlayerId);
            modelBuilder.Entity<PlayerSection>().HasMany(s=> s.Dungeons).WithOne();
            modelBuilder.Entity<PlayerItem>().HasIndex(p => p.PlayerId);
            modelBuilder.Entity<Unit>().HasIndex(p => p.PlayerId);

        }

        public DbSet<Player> Players { get; set; }
        //public DbSet<PlayerCurrency> Currencies { get; set; }
        //public DbSet<PlayerDungeon> Dungeons { get; set; }
    }
}
