using Microsoft.EntityFrameworkCore;

namespace Frontline.GameDesign
{
    public class GameDesignContext : DbContext
    {
        bool IsDoConfig = false;
        public GameDesignContext()
        {
            IsDoConfig = true;
        }

        public GameDesignContext(DbContextOptions<GameDesignContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (IsDoConfig)
            {
                var connection = "Server=140.143.28.95;database=frontline_design;uid=chenrong;pwd=abcd1234;SslMode=None;charset=utf8;pooling=false";
                //var connection = "Filename=./sqlitedb.db";
                optionsBuilder.UseMySql(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DMonsterInDungeon>().HasKey(d => new { d.dungeon_id, d.mid });
            modelBuilder.Entity<DDungeon>().HasIndex(d => new { d.section, d.type });
            modelBuilder.Entity<DUnitGradeUp>().HasKey(d => new { d.star, d.grade });
            modelBuilder.Entity<DDungeonStar>().HasKey(d => new { d.type, d.section, d.index });
        }

        public DbSet<DItem> DItems { get; set; }
        public DbSet<DLevel> DLevels { get; set; }
        public DbSet<DMonster> DMonsters { get; set; }
        public DbSet<DMonsterAbility> DMonsterAbilities { get; set; }
        public DbSet<DMonsterInDungeon> DMonsterInDungeons { get; set; }
        public DbSet<DDungeon> DDungeons { get; set; }
        public DbSet<DDungeonStar> DDungeonStars { get; set; }

        public DbSet<DUnit> DUnits { get; set; }
        public DbSet<DUnitLevelUp> DUnitLevelUps { get; set; }
        public DbSet<DUnitGradeUp> DUnitGradeUps { get; set; }
        public DbSet<DUnitUnlock> DUnitUnlocks { get; set; }

        public DbSet<DEquip> DEquips { get; set; }
        public DbSet<DEquipLevelCost> DEquipLevelCosts { get; set; }
        public DbSet<DEquipGrade> DEquipGrades { get; set; }
        public DbSet<DRandom> DRandoms { get; set; }

        public DbSet<DLottery> DLotteries { get; set; }
        public DbSet<DLotteryGroup> DLotteryGroups { get; set; }
        public DbSet<DLotteryRand> DLotteryRands { get; set; }

        public DbSet<DOlReward> DOlRewards { get; set; }

        public DbSet<DArenaRankReward> DArenaRankRewards { get; set; }
        public DbSet<DArenaChallengeReward> DArenaChallengeRewards { get; set; }

        public DbSet<DLegion> DLegions { get; set; }

        public DbSet<DFacTask> DFacTasks { get; set; }
        public DbSet<DFacTaskGroup> DFacTaskGroup { get; set; }
        public DbSet<DFacWorker> DFacWorkers { get; set; }

        public DbSet<VIPPrivilege> VIPPrivileges { get; set; }
        public DbSet<DName> DNames { get; set; }
    }
}


