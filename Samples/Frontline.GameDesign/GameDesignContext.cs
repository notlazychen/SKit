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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (IsDoConfig)
            {
                var connection = "Server=101.132.118.172;database=frontline_design;uid=chenrong;pwd=abcd1234;SslMode=None;charset=utf8;pooling=false";
                optionsBuilder.UseMySql(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DMonsterInDungeon>().HasKey(d => new { d.dungeon_id, d.mid });
            modelBuilder.Entity<DDungeon>().HasIndex(d => new { d.section, d.type });

        }

        public DbSet<DItem> DItems { get; set; }
        public DbSet<DLevel> DLevels { get; set; }
        public DbSet<DMonster> DMonsters { get; set; }
        public DbSet<DMonsterAbility> DMonsterAbilities { get; set; }
        public DbSet<DMonsterInDungeon> DMonsterInDungeons { get; set; }
        public DbSet<DDungeon> DDungeons { get; set; }
    }
}


