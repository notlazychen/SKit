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
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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
            modelBuilder.Entity<DUnitGradeUp>().HasKey(d => new { d.star, d.grade, d.type });
            modelBuilder.Entity<DDungeonStar>().HasKey(d => new { d.type, d.section, d.index });
            modelBuilder.Entity<DLegionScience>().HasKey(d => new { d.id, d.lv });
            modelBuilder.Entity<DWeekBattle>().HasKey(d => new { d.mid, d.day });

            modelBuilder.Entity<DSecretShop>().HasKey(d => new { d.vip, d.group });
        }
        public DbSet<DGameConfig> DGameConfig { get; set; }

        public DbSet<DItem> DItem { get; set; }
        public DbSet<DLevel> DLevel { get; set; }
        public DbSet<DMonster> DMonster { get; set; }
        public DbSet<DMonsterAbility> DMonsterAbility { get; set; }
        public DbSet<DMonsterInDungeon> DMonsterInDungeon { get; set; }
        public DbSet<DDungeon> DDungeon { get; set; }
        public DbSet<DDungeonStar> DDungeonStar { get; set; }

        public DbSet<DUnit> DUnit { get; set; }
        public DbSet<DUnitLevelUp> DUnitLevelUp { get; set; }
        public DbSet<DUnitGradeUp> DUnitGradeUp { get; set; }
        public DbSet<DUnitUnlock> DUnitUnlock { get; set; }

        public DbSet<DEquip> DEquip { get; set; }
        public DbSet<DEquipLevelCost> DEquipLevelCost { get; set; }
        public DbSet<DEquipGrade> DEquipGrade { get; set; }
        public DbSet<DRandom> DRandom { get; set; }

        public DbSet<DLottery> DLottery { get; set; }
        public DbSet<DLotteryGroup> DLotteryGroup { get; set; }
        public DbSet<DLotteryRand> DLotteryRand { get; set; }

        public DbSet<DOlReward> DOlReward { get; set; }

        public DbSet<DArenaRankReward> DArenaRankReward { get; set; }
        public DbSet<DArenaChallengeReward> DArenaChallengeReward { get; set; }

        public DbSet<DLegion> DLegion { get; set; }
        public DbSet<DLegionDonate> DLegionDonate { get; set; }
        

        public DbSet<DFacTask> DFacTask { get; set; }
        public DbSet<DFacTaskGroup> DFacTaskGroup { get; set; }
        public DbSet<DFacWorker> DFacWorker { get; set; }

        public DbSet<VIPPrivilege> VIPPrivilege { get; set; }
        public DbSet<DName> DName { get; set; }

        public DbSet<DQuest> DQuest { get; set; }
        public DbSet<DQuestDaily> DQuestDaily { get; set; }
        public DbSet<DQuestDailyReward> DQuestDailyReward { get; set; }

        public DbSet<DResPrice> DResPrice { get; set; }
        public DbSet<DDiKangQianXian> DDiKangQianXian { get; set; }
        public DbSet<DDiKangQianXianBuilding> DDiKangQianXianBuilding { get; set; }
        public DbSet<DDiKangQianXianBox> DDiKangQianXianBox { get; set; }
        public DbSet<DTransport> DTransport { get; set; }
        public DbSet<DRescue> DRescue { get; set; }

        public DbSet<DLegionScience> DLegionScience { get; set; }
        public DbSet<DWeekBattle> DWeekBattle { get; set; }
        public DbSet<DWeekBox> DWeekBox { get; set; }

        public DbSet<DMallShopItem> DMallShopItem { get; set; }
        public DbSet<DMallShop> DMallShop { get; set; }

        public DbSet<DSecretShop> DSecretShop { get; set; }
        public DbSet<DSecretShopItem> DSecretShopItem { get; set; }
        public DbSet<DSecretShopProb> DSecretShopProb { get; set; }      
        
        public DbSet<DSkill> DSkill { get; set; }

        public DbSet<DRaffle> DRaffle { get; set; }
        public DbSet<DRaffleGroup> DRaffleGroup { get; set; }
    }
}


