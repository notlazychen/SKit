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
            modelBuilder.Entity<Player>().HasIndex(p => p.NickName).IsUnique();
            //modelBuilder.Entity<Player>().HasBaseType<PlayerBaseInfo>();
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

            modelBuilder.Entity<FriendList>().HasIndex(f => f.PlayerId);
            modelBuilder.Entity<Friendship>().HasKey(p => new { p.FriendListId , p.PlayerId });
            modelBuilder.Entity<Friendship>().HasIndex(p => p.FriendListId);
            modelBuilder.Entity<FriendApplication>().HasKey(p => new { p.FriendListId, p.PlayerId });

            modelBuilder.Entity<ArenaCert>().HasIndex(p => new { p.CurrentRank });
            modelBuilder.Entity<ArenaCert>().HasOne<Player>().WithOne(p => p.ArenaCert).IsRequired();
            modelBuilder.Entity<ArenaBattleHistory>().HasIndex(h=>h.PlayerId);
            modelBuilder.Entity<ArenaBattleHistory>().HasOne<ArenaCert>().WithMany(a => a.ArenaBattleHistories).HasForeignKey(h => h.ArenaCertId);

            modelBuilder.Entity<Legion>().HasIndex(l => l.Level);
            modelBuilder.Entity<Legion>().HasIndex(l => l.Name).IsUnique();
            modelBuilder.Entity<Legion>().HasIndex(l => l.ShortName).IsUnique();
            //modelBuilder.Entity<LegionMember>().HasAlternateKey(l => l.PlayerId);
            modelBuilder.Entity<LegionMember>().HasOne<Legion>().WithMany(l=>l.Members).HasForeignKey(m=>m.LegionId);
            modelBuilder.Entity<LegionScience>().HasOne<LegionMember>().WithMany(lm => lm.LegionSciences).HasForeignKey(s => s.PlayerId);
            modelBuilder.Entity<LegionApplication>().HasIndex(l => l.LegionId);
            modelBuilder.Entity<LegionApplication>().HasOne<Legion>().WithMany(l => l.LegionApplications).HasForeignKey(l=>l.LegionId);
            modelBuilder.Entity<LegionBBS>().HasIndex(l => l.LegionId);
            modelBuilder.Entity<LegionBBS>().HasOne<Legion>().WithMany(l => l.LegionBBS).HasForeignKey(l => l.LegionId);

            modelBuilder.Entity<Factory>().HasIndex(l => l.PlayerId).IsUnique();
            modelBuilder.Entity<FacWorker>().HasIndex(l => l.PlayerId);
            modelBuilder.Entity<FacTask>().HasIndex(l => l.PlayerId);
            modelBuilder.Entity<FacTask>().HasOne<Factory>().WithMany(f => f.FacTasks).HasForeignKey(t => t.PlayerId);
            modelBuilder.Entity<FacWorker>().HasOne<Factory>().WithMany(f=>f.FacWorkers).HasForeignKey(w=>w.PlayerId);
            //modelBuilder.Entity<FacWorker>().HasOne<FacTask>().WithMany(f => f.FacWorkers).HasForeignKey(w => w.FacTaskId);

            modelBuilder.Entity<Quest>().HasOne<PlayerQuestData>().WithMany(f => f.Quests).HasForeignKey(w => w.PlayerId);
            modelBuilder.Entity<QuestDaily>().HasOne<PlayerQuestData>().WithMany(f => f.QuestDailys).HasForeignKey(w => w.PlayerId);

            modelBuilder.Entity<Mail>().HasIndex(m => m.PlayerId);
            modelBuilder.Entity<MailAttachment>().HasIndex(at => at.MailId);
            modelBuilder.Entity<MailAttachment>().HasOne<Mail>().WithMany(m=>m.MailAttachments).HasForeignKey(m=>m.MailId);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Lottery> Lotteries { get; set; }

        public DbSet<ArenaCert> ArenaCerts { get; set; }
        public DbSet<ArenaBattleHistory> ArenaBattleHistories { get; set; }

        public DbSet<Section> Sections { get; set; } 
        public DbSet<PlayerItem> Items { get; set; } 
        public DbSet<Unit> Units { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PVPFormation> Formations { get; set; }

        //public DbSet<PlayerDungeon> Dungeons { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendApplication> FriendApplications { get; set; }

        public DbSet<Legion> Legions { get; set; }
        public DbSet<LegionMember> LegionMembers { get; set; }
        public DbSet<LegionScience> LegionSciences { get; set; }
        public DbSet<LegionApplication> LegionApplications { get; set; }
        public DbSet<LegionBBS> LegionBBS { get; set; }
        

        public DbSet<Factory> Factories { get; set; }
        public DbSet<FacWorker> FacWorkers { get; set; }
        public DbSet<FacTask> FacTasks { get; set; }

        public DbSet<PlayerQuestData> PlayerQuestDatas { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestDaily> QuestDailys { get; set; }

        public DbSet<DiKang> DiKangs { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Rescue> Rescues { get; set; }

        public DbSet<Mail> Mails { get; set; }
    }
}
