using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Player
    {
        public const int STATE_NORMAL = 0;
        public const int STATE_SILENT = 1;//禁言
        public const int STATE_BAN = 2;//封号


        public String Id { get; set; }

        /// <summary>
        /// 用户中心ID(索引)
        /// </summary>
        public long UserCenterId { get; set; }
        /// <summary>
        /// 用户名(索引)
        /// </summary>
        [MaxLength(20)]
        public String UserCode { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(20)]
        public String Icon { get; set; }
        /// <summary>
        /// 昵称(唯一)
        /// </summary>
        [MaxLength(20)]
        public String NickName { get; set; }
        /// <summary>
        /// VIP等级
        /// </summary>
        public int VIP { get; set; }
        /// <summary>
        /// VIP经验
        /// </summary>
        public int VIPExp { get; set; }
        /// <summary>
        /// 是否已经废弃
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 经验值
        /// </summary>
        public int Exp { get; set; }
        /// <summary>
        /// 升级的时间
        /// </summary>
        public DateTime LastLvUpTime { get; set; }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 角色创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// vip等级升级时间
        /// </summary>
        public DateTime LastVipUpTime { get; set; }
        /// <summary>
        /// 是否已经绑定
        /// </summary>
        public bool IsBind { get; set; }
        /// <summary>
        /// 历史最高战力
        /// </summary>
        public long MaxPower { get; set; }
        /// <summary>
        /// 阵营
        /// </summary>
        public int Camp { get; set; }
        /// <summary>
        /// 改名次数
        /// </summary>
        public int RenameNumb { get; set; }   
        /// <summary>
        /// 购买技能次数
        /// </summary>
        public int BuySkillNumb { get; set; }   
        /// <summary>
        /// 已购买科研序列
        /// </summary>
        public int ScienceNumb { get; set; }
        /// <summary>
        /// 1禁言，2封号
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 恢复禁言封号状态的时间
        /// </summary>
        public long StateTime { get; set; }
        
        public bool OldPlayer { get; set; }

        [MaxLength(32)]
        public String Language { get; set; }

        [MaxLength(32)]
        public String IP { get; set; }

        [MaxLength(32)]
        public String Version { get; set; }

        /// <summary>
        /// 引导编号
        /// </summary>
        public float Guide { get; set; }

        public List<Currency> Currencies { get; set; } = new List<Currency>();
        public List<Section> Sections { get; set; } = new List<Section>();
        public List<PlayerItem> Items { get; set; } = new List<PlayerItem>();
        public List<Unit> Units { get; set; } = new List<Unit>();

        public List<Team> Teams { get; set; } = new List<Team>();
        public List<PVPFormation> Formations { get; set; } = new List<PVPFormation>();
    }
}
