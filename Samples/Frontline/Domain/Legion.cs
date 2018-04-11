using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Legion
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public String ShortName { get; set; }//短名字
        public String LeaderId { get; set; }
        public String Note { get; set; }//宣言

        public String Icon { get; set; }

        public int Level { get; set; }//等级
        public bool NeedCheck { get; set; }//是否需要审核 true:需要 false:不需要

        public string Creater { get; set; }//创始人
        public DateTime CreateTime { get; set; }


        public int Exp{get;set;}//经验

        public List<LegionMember> Members { get; set; } = new List<LegionMember>();

        public const int GVG_STATE_NONE = 0;//0未操作
        public const int GVG_STATE_ENROLL = 1;//1报名
        public const int GVG_STATE_ING = 2;//2已开始

        public int GvgState { get; set; }//公会战状态，0未操作，1报名，2已开始
        public DateTime EnrollTime { get; set; }//公会战报名时间

        public String GvgWAN { get; set; }//公会战服务器外网地址
        public String GvgLAN { get; set; }//公会战服务器内网地址

        public int GvgPort { get; set; }
        public int GvgClientPort { get; set; }//公会战服务器地址

        public int GvgMap { get; set; }//公会战地图级别

        public int Glory { get; set; }//上次公会战荣誉
        public int MaxGlory { get; set; }

        public int GvgRank { get; set; }//上次公会战排名
        public int GvgMaxRank { get; set; }

        public List<LegionApplication> LegionApplications { get; set; } = new List<LegionApplication>();
        public List<LegionBBS> LegionBBS { get; set; } = new List<LegionBBS>();
    }
}
