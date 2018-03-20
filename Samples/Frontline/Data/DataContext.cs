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
            modelBuilder.Entity<Wallet>().HasOne<Player>().WithOne(p=>p.Wallet).IsRequired();
            modelBuilder.Entity<Dungeon>().HasIndex(d => d.SectionId);
            modelBuilder.Entity<Dungeon>().HasIndex(d => new { d.Tid, d.PlayerId });
            modelBuilder.Entity<Section>().HasIndex(s => s.PlayerId);
            modelBuilder.Entity<Section>().HasMany(s=> s.Dungeons).WithOne();
            modelBuilder.Entity<PlayerItem>().HasIndex(p => p.PlayerId);
            modelBuilder.Entity<Unit>().HasIndex(p => p.PlayerId);

            modelBuilder.Entity<Team>().HasIndex(p => p.PlayerId);
            modelBuilder.Entity<PVPFormation>().HasIndex(p => p.PlayerId);

            modelBuilder.Entity<Equip>().HasIndex(p => p.UnitId);

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Wallet> Wallets { get; set; } 
        public DbSet<Section> Sections { get; set; } 
        public DbSet<PlayerItem> Items { get; set; } 
        public DbSet<Unit> Units { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PVPFormation> Formations { get; set; } 
        //public DbSet<PlayerCurrency> Currencies { get; set; }
        //public DbSet<PlayerDungeon> Dungeons { get; set; }
    }
}
