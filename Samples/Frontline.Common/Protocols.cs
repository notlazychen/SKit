using ProtoBuf;
using System.Collections.Generic;
using System;
namespace protocol
{
    [ProtoContract]
    public class ActivityInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public RewardInfo reward;
        [ProtoMember(3)]
        public Int64 startTime;
        [ProtoMember(4)]
        public Int64 endTime;
        [ProtoMember(5)]
        public Int32 level;
        [ProtoMember(6)]
        public Int32 day;
        [ProtoMember(7)]
        public Int32 vip;
        [ProtoMember(8)]
        public String title;
        [ProtoMember(9)]
        public String content;
        [ProtoMember(10)]
        public Boolean received;
        [ProtoMember(11)]
        public Boolean recharged;
        [ProtoMember(12)]
        public Single fanliK;
        [ProtoMember(13)]
        public Int32 unitId;
        [ProtoMember(14)]
        public Int64 cardEndTime;
        [ProtoMember(15)]
        public Int64 cardLastRecvTime;
        [ProtoMember(16)]
        public Single rechargeDiamond;
        [ProtoMember(17)]
        public Int32 consumeDiamond;
        [ProtoMember(18)]
        public Int32 now_consumeDiamond;
        [ProtoMember(19)]
        public Int32 power;
        [ProtoMember(20)]
        public Int32 collect_id;
        [ProtoMember(21)]
        public Int32 collect_cnt;
        [ProtoMember(22)]
        public Int32 now_collect;
        [ProtoMember(23)]
        public Int32 card_type;
        [ProtoMember(24)]
        public Int32 product_id;
        [ProtoMember(25)]
        public Int64 twentyFourRecvTime;
        [ProtoMember(26)]
        public Single price;
        [ProtoMember(27)]
        public Int32 times;
    }
    [ProtoContract]
    public class ActivityTagDetail
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 tag;
        [ProtoMember(3)]
        public Int64 lastRecvDay;
        [ProtoMember(4)]
        public List<ActivityInfo> activities;
        [ProtoMember(5)]
        public Boolean boughtCZ;
        [ProtoMember(6)]
        public Int32 popup;
        [ProtoMember(7)]
        public Int32 actually_day;
        [ProtoMember(8)]
        public Int32 seven_day;
        [ProtoMember(9)]
        public Int32 replenishedTime;
        [ProtoMember(10)]
        public Int32 now_signTime;
    }
    [ProtoContract]
    public class ActivityTagInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 label;
        [ProtoMember(3)]
        public Int32 tag;
        [ProtoMember(4)]
        public Int32 vip;
        [ProtoMember(5)]
        public Int32 diamond;
        [ProtoMember(6)]
        public Int32 popup;
        [ProtoMember(7)]
        public String desc;
        [ProtoMember(8)]
        public String start_time;
        [ProtoMember(9)]
        public String end_time;
    }
    [ProtoContract]
    public class LimitGiftInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 index;
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int64 time;
        [ProtoMember(5)]
        public Int32 func;
        [ProtoMember(6)]
        public Int32 cnt;
        [ProtoMember(7)]
        public List<Int32> item_id;
        [ProtoMember(8)]
        public List<Int32> item_cnt;
        [ProtoMember(9)]
        public List<Int32> res_type;
        [ProtoMember(10)]
        public List<Int32> res_cnt;
        [ProtoMember(11)]
        public Int32 position;
        [ProtoMember(12)]
        public Int32 pic_type;
    }
    [ProtoContract]
    public class QiRiWalfareInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 tag;
        [ProtoMember(3)]
        public RewardInfo reward;
        [ProtoMember(4)]
        public Int32 day;
        [ProtoMember(5)]
        public Boolean received;
        [ProtoMember(6)]
        public Int32 product_id;
        [ProtoMember(7)]
        public Int32 mission_type;
        [ProtoMember(8)]
        public Int32 jump;
        [ProtoMember(9)]
        public Int32 process;
        [ProtoMember(10)]
        public Int32 diamond;
        [ProtoMember(11)]
        public Int32 discount;
        [ProtoMember(12)]
        public String desc;
        [ProtoMember(13)]
        public Int32 type;
        [ProtoMember(14)]
        public Int32 value;
        [ProtoMember(15)]
        public Int32 now_process;
        [ProtoMember(16)]
        public Int32 times;
    }
    [ProtoContract]
    public class RebateInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public List<Int32> item_id;
        [ProtoMember(3)]
        public List<Int32> item_cnt;
        [ProtoMember(4)]
        public List<Int32> res_type;
        [ProtoMember(5)]
        public List<Int32> res_cnt;
        [ProtoMember(6)]
        public String start_time;
        [ProtoMember(7)]
        public String end_time;
        [ProtoMember(8)]
        public Int32 re;
        [ProtoMember(9)]
        public Single p;
        [ProtoMember(10)]
        public Int32 times;
    }
    [ProtoContract]
    public class RechargeInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 recharge_times;
    }
    [ProtoContract]
    public class RechargeTagDetail
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 tag;
        [ProtoMember(3)]
        public List<ActivityInfo> activities;
        [ProtoMember(4)]
        public List<LimitGiftInfo> gifts;
    }
    [ProtoContract]
    public class ResInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 count;
    }
    [ProtoContract]
    public class RewardInfo
    {
        [ProtoMember(1)]
        public Int32 exp;
        [ProtoMember(2)]
        public List<ResInfo> res;
        [ProtoMember(3)]
        public List<RewardItem> items;
        [ProtoMember(4)]
        public List<UnitInfo> units;
    }
    [ProtoContract]
    public class RewardItem
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public String name;
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 quality;
        [ProtoMember(5)]
        public Int32 icon;
        [ProtoMember(6)]
        public Int32 count;
    }
    [ProtoContract]
    public class BulletinInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 type;
        [ProtoMember(3)]
        public String tag;
        [ProtoMember(4)]
        public String title;
        [ProtoMember(5)]
        public String context;
        [ProtoMember(6)]
        public String start_time;
        [ProtoMember(7)]
        public String end_time;
    }
    [ProtoContract]
    public class EquipInfo
    {
        [ProtoMember(1)]
        public Int32 equipId;
        [ProtoMember(2)]
        public Int32 level;
        [ProtoMember(3)]
        public Int32 grade;
    }
    [ProtoContract]
    public class TeamInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public List<String> bps;
        [ProtoMember(3)]
        public Boolean selected;
    }
    [ProtoContract]
    public class TeamPlaceInfo
    {
        [ProtoMember(1)]
        public UnitInfo unitInfo;
        [ProtoMember(2)]
        public Int32 place;
    }
    [ProtoContract]
    public class UnitInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 number;
        [ProtoMember(3)]
        public Int32 tid;
        [ProtoMember(4)]
        public Int32 exp;
        [ProtoMember(5)]
        public Int32 level;
        [ProtoMember(6)]
        public Int32 claz;
        [ProtoMember(7)]
        public String name;
        [ProtoMember(8)]
        public Int32 type;
        [ProtoMember(9)]
        public Int32 nation;
        [ProtoMember(10)]
        public String desc;
        [ProtoMember(11)]
        public Int32 star;
        [ProtoMember(12)]
        public Int32 hp;
        [ProtoMember(13)]
        public Int32 att;
        [ProtoMember(14)]
        public Int32 defence;
        [ProtoMember(15)]
        public Single crit;
        [ProtoMember(16)]
        public Single crit_hurt;
        [ProtoMember(17)]
        public Single hurt_add;
        [ProtoMember(18)]
        public Single hurt_sub;
        [ProtoMember(19)]
        public Int32 crit_v;
        [ProtoMember(20)]
        public Int32 hurt_add_v;
        [ProtoMember(21)]
        public Int32 hurt_sub_v;
        [ProtoMember(22)]
        public Int32 armor;
        [ProtoMember(23)]
        public Single hurt_multiple;
        [ProtoMember(24)]
        public Single cd;
        [ProtoMember(25)]
        public Single distance;
        [ProtoMember(26)]
        public Single r;
        [ProtoMember(27)]
        public Single off;
        [ProtoMember(28)]
        public Single rev;
        [ProtoMember(29)]
        public Single rev_body;
        [ProtoMember(30)]
        public Single speed;
        [ProtoMember(31)]
        public Int32 mob;
        [ProtoMember(32)]
        public Single hp_add;
        [ProtoMember(33)]
        public Single att_add;
        [ProtoMember(34)]
        public Single def_add;
        [ProtoMember(35)]
        public Single hp_growth;
        [ProtoMember(36)]
        public Single att_growth;
        [ProtoMember(37)]
        public Single defence_growth;
        [ProtoMember(38)]
        public Int32 type_detail;
        [ProtoMember(39)]
        public Int32 levelLimit;
        [ProtoMember(40)]
        public String gain;
        [ProtoMember(41)]
        public Int32 count;
        [ProtoMember(42)]
        public Single last_time;
        [ProtoMember(43)]
        public Int32 bullet_count;
        [ProtoMember(44)]
        public String pid;
        [ProtoMember(45)]
        public Int32 rank;
        [ProtoMember(46)]
        public Int32 exist;
        [ProtoMember(47)]
        public Int32 energy;
        [ProtoMember(48)]
        public Int32 gold;
        [ProtoMember(49)]
        public Int32 supply;
        [ProtoMember(50)]
        public Int32 iron;
        [ProtoMember(51)]
        public Int32 pvp_point;
        [ProtoMember(52)]
        public Int32 pvp_dec_score;
        [ProtoMember(53)]
        public Int32 max_energy;
        [ProtoMember(54)]
        public Int32 power;
        [ProtoMember(55)]
        public List<EquipInfo> equips;
        [ProtoMember(56)]
        public Boolean preparing;
        [ProtoMember(57)]
        public Int64 prepareEndTime;
        [ProtoMember(58)]
        public List<Int32> unitSkills;
        [ProtoMember(59)]
        public Int32 hp_ex;
        [ProtoMember(60)]
        public Int32 att_ex;
        [ProtoMember(61)]
        public Int32 def_ex;
    }
    [ProtoContract]
    public class ChatHistory
    {
        [ProtoMember(1)]
        public List<ChatInfo> chats;
        [ProtoMember(2)]
        public Int32 type;
    }
    [ProtoContract]
    public class ChatInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public String text;
        [ProtoMember(3)]
        public String from;
        [ProtoMember(4)]
        public String icon;
        [ProtoMember(5)]
        public String nickyName;
        [ProtoMember(6)]
        public Int32 level;
        [ProtoMember(7)]
        public String partyName;
        [ProtoMember(8)]
        public Int32 camp;
        [ProtoMember(9)]
        public Int32 vip;
        [ProtoMember(10)]
        public Int64 time;
        [ProtoMember(11)]
        public Boolean isSystem;
    }
    [ProtoContract]
    public class FBInfo
    {
        [ProtoMember(1)]
        public String fid;
        [ProtoMember(2)]
        public Int32 id;
        [ProtoMember(3)]
        public Boolean open;
        [ProtoMember(4)]
        public Int32 star;
        [ProtoMember(5)]
        public Int32 remainTimes;
        [ProtoMember(6)]
        public Int32 remainBuyTimes;
        [ProtoMember(7)]
        public Int32 type;
        [ProtoMember(8)]
        public String name;
        [ProtoMember(9)]
        public String desc;
        [ProtoMember(10)]
        public String icon;
        [ProtoMember(11)]
        public String screen_id;
        [ProtoMember(12)]
        public Int32 level_limit;
        [ProtoMember(13)]
        public Int32 oil_cost;
        [ProtoMember(14)]
        public Int32 fight_times;
        [ProtoMember(15)]
        public Int32 power;
        [ProtoMember(16)]
        public Int32 exp;
        [ProtoMember(17)]
        public Int32 gold;
        [ProtoMember(18)]
        public Int32 random_id;
        [ProtoMember(19)]
        public Int32 time_limit_1;
        [ProtoMember(20)]
        public Int32 time_limit_2;
        [ProtoMember(21)]
        public Int32 time_limit_3;
        [ProtoMember(22)]
        public Int32 wipe_cost;
        [ProtoMember(23)]
        public String map_res_name;
        [ProtoMember(24)]
        public String map_fighting;
        [ProtoMember(25)]
        public String map_file_name;
        [ProtoMember(26)]
        public List<Int32> dropItems;
        [ProtoMember(27)]
        public Int32 resetRemainNumb;
    }
    [ProtoContract]
    public class MonsterInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public String name;
        [ProtoMember(3)]
        public Int32 lv;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(5)]
        public Int32 type_detail;
        [ProtoMember(6)]
        public Int32 nation;
        [ProtoMember(7)]
        public String desc;
        [ProtoMember(8)]
        public Int32 hp;
        [ProtoMember(9)]
        public Int32 att;
        [ProtoMember(10)]
        public Int32 defence;
        [ProtoMember(11)]
        public Single crit;
        [ProtoMember(12)]
        public Single crit_hurt;
        [ProtoMember(13)]
        public Single hurt_add;
        [ProtoMember(14)]
        public Single hurt_sub;
        [ProtoMember(15)]
        public Int32 armor;
        [ProtoMember(16)]
        public Single hurt_multiple;
        [ProtoMember(17)]
        public Single cd;
        [ProtoMember(18)]
        public Single distance;
        [ProtoMember(19)]
        public Single r;
        [ProtoMember(20)]
        public Single off;
        [ProtoMember(21)]
        public Single rev;
        [ProtoMember(22)]
        public Single rev_body;
        [ProtoMember(23)]
        public Single speed;
        [ProtoMember(24)]
        public Int32 count;
        [ProtoMember(25)]
        public Single last_time;
        [ProtoMember(26)]
        public Int32 bullet_count;
        [ProtoMember(27)]
        public String model;
        [ProtoMember(28)]
        public Single scale;
        [ProtoMember(29)]
        public String att_effect;
        [ProtoMember(30)]
        public String move_effect;
        [ProtoMember(31)]
        public String die_model;
        [ProtoMember(32)]
        public Int32 energy;
        [ProtoMember(33)]
        public Int32 power;
    }
    [ProtoContract]
    public class SectionInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 type;
        [ProtoMember(3)]
        public String name;
        [ProtoMember(4)]
        public Boolean open;
    }
    [ProtoContract]
    public class FactoryInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 lv;
        [ProtoMember(3)]
        public Int32 res_type;
        [ProtoMember(4)]
        public Int32 res_cnt;
        [ProtoMember(5)]
        public Int32 workerCnt;
        [ProtoMember(6)]
        public Boolean building;
        [ProtoMember(7)]
        public Int64 buildEndTime;
    }
    [ProtoContract]
    public class FriendInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public String nickyName;
        [ProtoMember(3)]
        public String icon;
        [ProtoMember(4)]
        public Int32 level;
        [ProtoMember(5)]
        public Int32 vip;
        [ProtoMember(6)]
        public Int32 power;
        [ProtoMember(7)]
        public Boolean canGetOil;
        [ProtoMember(8)]
        public Boolean canGiveOil;
    }
    [ProtoContract]
    public class ApplyInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public String pid;
        [ProtoMember(3)]
        public Int32 power;
        [ProtoMember(4)]
        public Int32 level;
        [ProtoMember(5)]
        public Int32 vip;
        [ProtoMember(6)]
        public String nickname;
        [ProtoMember(7)]
        public Boolean online;
        [ProtoMember(8)]
        public Int32 camp;
        [ProtoMember(9)]
        public Int64 time;
    }
    [ProtoContract]
    public class ContriInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 type;
        [ProtoMember(3)]
        public Int32 cost;
        [ProtoMember(4)]
        public String name;
        [ProtoMember(5)]
        public Int32 exp_party;
        [ProtoMember(6)]
        public Int32 contri;
    }
    [ProtoContract]
    public class ContriLogInfo
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public String nickname;
        [ProtoMember(3)]
        public Int32 contri;
        [ProtoMember(4)]
        public Int64 time;
    }
    [ProtoContract]
    public class MemberInfo
    {
        [ProtoMember(1)]
        public String name;
        [ProtoMember(2)]
        public String icon;
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public Int32 vip;
        [ProtoMember(5)]
        public Int32 level;
        [ProtoMember(6)]
        public Int32 power;
        [ProtoMember(7)]
        public Boolean owner;
        [ProtoMember(8)]
        public Boolean invited;
    }
    [ProtoContract]
    public class PartyInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public String name;
        [ProtoMember(3)]
        public String icon;
        [ProtoMember(4)]
        public String leaderName;
        [ProtoMember(5)]
        public String note;
        [ProtoMember(6)]
        public Int32 level;
        [ProtoMember(7)]
        public Int32 exp;
        [ProtoMember(8)]
        public Int32 next_exp;
        [ProtoMember(9)]
        public Int32 count;
        [ProtoMember(10)]
        public Int32 max;
        [ProtoMember(11)]
        public Boolean applied;
        [ProtoMember(12)]
        public String shortName;
        [ProtoMember(13)]
        public Boolean check;
    }
    [ProtoContract]
    public class PartyMemberInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 level;
        [ProtoMember(3)]
        public Int32 vip;
        [ProtoMember(4)]
        public String icon;
        [ProtoMember(5)]
        public Int32 career;
        [ProtoMember(6)]
        public String nickname;
        [ProtoMember(7)]
        public Int64 lastLoginTime;
        [ProtoMember(8)]
        public Int64 contri;
        [ProtoMember(9)]
        public Int32 camp;
        [ProtoMember(10)]
        public Int32 power;
    }
    [ProtoContract]
    public class PartyScienceInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Boolean open;
        [ProtoMember(3)]
        public String name;
        [ProtoMember(4)]
        public Int32 icon;
        [ProtoMember(5)]
        public String desc;
        [ProtoMember(6)]
        public List<Int32> scope;
        [ProtoMember(7)]
        public Single hp_add;
        [ProtoMember(8)]
        public Single att_add;
        [ProtoMember(9)]
        public Single def_add;
        [ProtoMember(10)]
        public Single crit;
        [ProtoMember(11)]
        public Single crit_hurt;
        [ProtoMember(12)]
        public Single hurt_add;
        [ProtoMember(13)]
        public Single hurt_sub;
        [ProtoMember(14)]
        public Single speed;
        [ProtoMember(15)]
        public Single gold_main;
        [ProtoMember(16)]
        public Single building_time;
        [ProtoMember(17)]
        public Single unit_time;
        [ProtoMember(18)]
        public Single gold_resist;
        [ProtoMember(19)]
        public Single supply_max;
        [ProtoMember(20)]
        public Single iron_max;
        [ProtoMember(21)]
        public Int32 party_level;
    }
    [ProtoContract]
    public class PartyWordsInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public String pid;
        [ProtoMember(3)]
        public Int32 level;
        [ProtoMember(4)]
        public Int32 vip;
        [ProtoMember(5)]
        public String nickname;
        [ProtoMember(6)]
        public String icon;
        [ProtoMember(7)]
        public Int64 time;
        [ProtoMember(8)]
        public String message;
    }
    [ProtoContract]
    public class MailInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public String from;
        [ProtoMember(3)]
        public String title;
        [ProtoMember(4)]
        public String icon;
        [ProtoMember(5)]
        public String content;
        [ProtoMember(6)]
        public Int64 time;
        [ProtoMember(7)]
        public String partyName;
        [ProtoMember(8)]
        public RewardInfo attachment;
        [ProtoMember(9)]
        public Boolean readed;
        [ProtoMember(10)]
        public Boolean collected;
        [ProtoMember(11)]
        public Boolean isPartyMail;
        [ProtoMember(12)]
        public Int32 mailType;
        [ProtoMember(13)]
        public List<String> mailArgs;
    }
    [ProtoContract]
    public class MainlineInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 progress;
        [ProtoMember(3)]
        public Boolean finish;
    }
    [ProtoContract]
    public class MallShopInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 id;
        [ProtoMember(3)]
        public Int32 item_id;
        [ProtoMember(4)]
        public Int32 count;
        [ProtoMember(5)]
        public Int32 res_cnt;
        [ProtoMember(6)]
        public Int32 res_type;
        [ProtoMember(7)]
        public Int32 limit_cnt;
    }
    [ProtoContract]
    public class NoticeArgInfo
    {
        [ProtoMember(1)]
        public String value;
        [ProtoMember(2)]
        public Int32 type;
    }
    [ProtoContract]
    public class ResourceInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 id;
        [ProtoMember(3)]
        public Int32 count;
    }
    [ProtoContract]
    public class ItemInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 tid;
        [ProtoMember(3)]
        public String name;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(5)]
        public Int32 quality;
        [ProtoMember(6)]
        public Int32 icon;
        [ProtoMember(7)]
        public Boolean useable;
        [ProtoMember(8)]
        public Int32 breakCount;
        [ProtoMember(9)]
        public Int32 breakRandomId;
        [ProtoMember(10)]
        public Int32 breakUnitId;
        [ProtoMember(11)]
        public String desc;
        [ProtoMember(12)]
        public Int32 price;
        [ProtoMember(13)]
        public Int32 overlap;
        [ProtoMember(14)]
        public Int32 lap;
        [ProtoMember(15)]
        public Int32 synthCount;
        [ProtoMember(16)]
        public Int32 synthId;
        [ProtoMember(17)]
        public Int32 synthCost;
    }
    [ProtoContract]
    public class BuyResInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 times;
        [ProtoMember(3)]
        public Int32 timesRemain;
        [ProtoMember(4)]
        public Int32 cost;
        [ProtoMember(5)]
        public Int32 count;
    }
    [ProtoContract]
    public class FightUnitInfo
    {
        [ProtoMember(1)]
        public Boolean dead;
        [ProtoMember(2)]
        public String unitId;
        [ProtoMember(3)]
        public Int32 remainNumber;
        [ProtoMember(4)]
        public Int32 exp;
        [ProtoMember(5)]
        public Int32 lv;
    }
    [ProtoContract]
    public class FlagBreakRankReward
    {
        [ProtoMember(1)]
        public Int32 rank;
        [ProtoMember(2)]
        public RewardInfo reward;
    }
    [ProtoContract]
    public class GrabFlagAdversaryInfo
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public Int32 rank;
        [ProtoMember(3)]
        public Int32 power;
        [ProtoMember(4)]
        public Int32 level;
        [ProtoMember(5)]
        public String icon;
        [ProtoMember(6)]
        public String name;
    }
    [ProtoContract]
    public class GrabFlagBattleHistoryInfo
    {
        [ProtoMember(1)]
        public String adversaryPid;
        [ProtoMember(2)]
        public String icon;
        [ProtoMember(3)]
        public Int32 power;
        [ProtoMember(4)]
        public Int32 battleResult;
        [ProtoMember(5)]
        public String adversaryName;
        [ProtoMember(6)]
        public Int64 battleTime;
        [ProtoMember(7)]
        public Int32 rankChange;
    }
    [ProtoContract]
    public class GrabFlagRankRewardInfo
    {
        [ProtoMember(1)]
        public List<Int32> rank_area;
        [ProtoMember(2)]
        public List<Int32> items_id;
        [ProtoMember(3)]
        public List<Int32> items_cnt;
    }
    [ProtoContract]
    public class GrabFlagScoreInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 score;
        [ProtoMember(3)]
        public Boolean received;
    }
    [ProtoContract]
    public class PVEPatternInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 remainTimes;
        [ProtoMember(3)]
        public Int32 totalTimes;
    }
    [ProtoContract]
    public class MonsterWaveInfo
    {
        [ProtoMember(1)]
        public Int32 wave;
        [ProtoMember(2)]
        public List<MonsterInfo> monster;
    }
    [ProtoContract]
    public class ResistWaveInfo
    {
        [ProtoMember(1)]
        public Int32 wid;
        [ProtoMember(2)]
        public List<MonsterInfo> monsters;
        [ProtoMember(3)]
        public Int32 token;
        [ProtoMember(4)]
        public Int32 command;
        [ProtoMember(5)]
        public Int32 hp;
        [ProtoMember(6)]
        public Int32 defence;
    }
    [ProtoContract]
    public class Quaternion
    {
        [ProtoMember(1)]
        public Single x;
        [ProtoMember(2)]
        public Single y;
        [ProtoMember(3)]
        public Single z;
        [ProtoMember(4)]
        public Single w;
    }
    [ProtoContract]
    public class V3
    {
        [ProtoMember(1)]
        public Single x;
        [ProtoMember(2)]
        public Single y;
        [ProtoMember(3)]
        public Single z;
    }
    [ProtoContract]
    public class BattleMonsterInfo
    {
        [ProtoMember(1)]
        public Int32 tid;
        [ProtoMember(2)]
        public MonsterInfo monsterInfo;
        [ProtoMember(3)]
        public List<PVPBattleUnitGameObject> gos;
    }
    [ProtoContract]
    public class RoomInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 diff;
        [ProtoMember(3)]
        public String roomId;
        [ProtoMember(4)]
        public List<MemberInfo> members;
        [ProtoMember(5)]
        public String password;
        [ProtoMember(6)]
        public Int64 createTime;
    }
    [ProtoContract]
    public class LadderBattleInfo
    {
        [ProtoMember(1)]
        public Boolean win;
        [ProtoMember(2)]
        public String enemyPid;
        [ProtoMember(3)]
        public String enemyIcon;
        [ProtoMember(4)]
        public String enemyName;
        [ProtoMember(5)]
        public Int32 enemyVIP;
        [ProtoMember(6)]
        public Int32 enemyLevel;
        [ProtoMember(7)]
        public String enemySerName;
        [ProtoMember(8)]
        public Int32 enemyLadderScoreBefore;
        [ProtoMember(9)]
        public Int32 enemyMilitaryRankBefore;
        [ProtoMember(10)]
        public Int32 enemyLadderScoreAfter;
        [ProtoMember(11)]
        public Int32 enemyMilitaryRankAfter;
        [ProtoMember(12)]
        public Int32 myVIP;
        [ProtoMember(13)]
        public Int32 myLevel;
        [ProtoMember(14)]
        public String mySerName;
        [ProtoMember(15)]
        public Int32 myLadderScoreAfter;
        [ProtoMember(16)]
        public Int32 myMilitaryRankAfter;
        [ProtoMember(17)]
        public Int32 myLadderScoreBefore;
        [ProtoMember(18)]
        public Int32 myMilitaryRankBefore;
        [ProtoMember(19)]
        public Int64 battleOverTime;
        [ProtoMember(20)]
        public Int64 battleUsedTime;
    }
    [ProtoContract]
    public class LadderPlayerBattleInfo
    {
        [ProtoMember(1)]
        public Boolean win;
        [ProtoMember(2)]
        public String pid;
        [ProtoMember(3)]
        public String icon;
        [ProtoMember(4)]
        public String name;
        [ProtoMember(5)]
        public Int32 ladderScore;
        [ProtoMember(6)]
        public Int32 vip;
        [ProtoMember(7)]
        public Int32 level;
        [ProtoMember(8)]
        public String serName;
        [ProtoMember(9)]
        public Int32 deltaScore;
        [ProtoMember(10)]
        public Int32 militaryRank;
        [ProtoMember(11)]
        public List<Int32> units;
    }
    [ProtoContract]
    public class MatchBattlePlayerInfo
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public String name;
        [ProtoMember(3)]
        public String icon;
        [ProtoMember(4)]
        public List<UnitInfo> units;
        [ProtoMember(5)]
        public List<SkillInfo> skills;
        [ProtoMember(6)]
        public Int32 position;
        [ProtoMember(7)]
        public Int32 group;
        [ProtoMember(8)]
        public Int32 vip;
        [ProtoMember(9)]
        public Int32 level;
        [ProtoMember(10)]
        public S2SLadderInfo ladderInfo;
        [ProtoMember(11)]
        public String serName;
        [ProtoMember(12)]
        public Int32 diamond;
        [ProtoMember(13)]
        public Int32 comboWin;
    }
    [ProtoContract]
    public class MatchBattleResultInfo
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public Boolean win;
        [ProtoMember(3)]
        public Int32 reason;
        [ProtoMember(4)]
        public Int32 vip;
        [ProtoMember(5)]
        public Int32 level;
        [ProtoMember(6)]
        public String name;
        [ProtoMember(7)]
        public String icon;
        [ProtoMember(8)]
        public String serName;
        [ProtoMember(9)]
        public Int32 score;
        [ProtoMember(10)]
        public Int32 costDiamond;
        [ProtoMember(11)]
        public RewardInfo rewardInfo;
        [ProtoMember(12)]
        public S2SLadderInfo ladderInfo;
        [ProtoMember(13)]
        public List<Int32> usedSkills;
        [ProtoMember(14)]
        public List<PVPUnitInfo> units;
        [ProtoMember(15)]
        public List<String> deadUnits;
        [ProtoMember(16)]
        public Int32 capture;
    }
    [ProtoContract]
    public class PVPBattleUnitGameObject
    {
        [ProtoMember(1)]
        public String name;
        [ProtoMember(2)]
        public V3 pos;
        [ProtoMember(3)]
        public Quaternion quat;
        [ProtoMember(4)]
        public Quaternion turrelQuat;
        [ProtoMember(5)]
        public Int32 hp;
        [ProtoMember(6)]
        public Boolean inFiring;
        [ProtoMember(7)]
        public V3 nextMovePos;
        [ProtoMember(8)]
        public List<V3> movePath;
        [ProtoMember(9)]
        public Boolean needMove;
        [ProtoMember(10)]
        public String targetID;
        [ProtoMember(11)]
        public Int32 currFireTimes;
        [ProtoMember(12)]
        public String currAnimName;
        [ProtoMember(13)]
        public Single cdTime;
        [ProtoMember(14)]
        public List<PVPBuff> buffs;
        [ProtoMember(15)]
        public Boolean isSkillFiring;
        [ProtoMember(16)]
        public Single armySkillCDTime;
        [ProtoMember(17)]
        public Int32 bulletBuffID;
        [ProtoMember(18)]
        public Single bulletAffectRadius;
        [ProtoMember(19)]
        public String skillActionName;
        [ProtoMember(20)]
        public String bulletEffectType;
        [ProtoMember(21)]
        public Int32 armySkillID;
        [ProtoMember(22)]
        public Single armySkillCD;
        [ProtoMember(23)]
        public String bulletHitEffectName;
    }
    [ProtoContract]
    public class PVPBattleUnitInfo
    {
        [ProtoMember(1)]
        public Int32 tid;
        [ProtoMember(2)]
        public String sid;
        [ProtoMember(3)]
        public List<PVPBattleUnitGameObject> gos;
        [ProtoMember(4)]
        public UnitInfo unitInfo;
    }
    [ProtoContract]
    public class PVPBuff
    {
        [ProtoMember(1)]
        public Int32 bufferID;
        [ProtoMember(2)]
        public String bufferPid;
        [ProtoMember(3)]
        public Int32 bufferSkillID;
        [ProtoMember(4)]
        public Single bufferRestTime;
        [ProtoMember(5)]
        public Boolean needBind;
    }
    [ProtoContract]
    public class PVPFlag
    {
        [ProtoMember(1)]
        public Int32 flagId;
        [ProtoMember(2)]
        public Int32 group;
        [ProtoMember(3)]
        public Int32 progress;
    }
    [ProtoContract]
    public class PVPPlayerInfo
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public Int32 playerScore;
        [ProtoMember(3)]
        public Int32 playerCreateArmyPoint;
        [ProtoMember(4)]
        public List<PVPBattleUnitInfo> unitsInfo;
    }
    [ProtoContract]
    public class PVPScoreInfo
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public Int32 group;
        [ProtoMember(3)]
        public Int32 score;
        [ProtoMember(4)]
        public Int32 flagCount;
        [ProtoMember(5)]
        public Int32 createUnitPoint;
    }
    [ProtoContract]
    public class PVPUnitInfo
    {
        [ProtoMember(1)]
        public Int32 unitId;
        [ProtoMember(2)]
        public Int32 unitLv;
        [ProtoMember(3)]
        public Int32 useTimes;
    }
    [ProtoContract]
    public class MultiDefencePlayerInfo
    {
        [ProtoMember(1)]
        public Int32 recvScore;
        [ProtoMember(2)]
        public String icon;
        [ProtoMember(3)]
        public String name;
        [ProtoMember(4)]
        public String pid;
        [ProtoMember(5)]
        public Int32 lv;
        [ProtoMember(6)]
        public Int32 vip;
        [ProtoMember(7)]
        public String serName;
        [ProtoMember(8)]
        public RewardInfo reward;
        [ProtoMember(9)]
        public List<String> deadUnits;
    }
    [ProtoContract]
    public class S2SBattlePlayerInfo
    {
        [ProtoMember(1)]
        public MatchBattlePlayerInfo info;
        [ProtoMember(2)]
        public String token;
    }
    [ProtoContract]
    public class S2SBattleServerInfo
    {
        [ProtoMember(1)]
        public String address;
        [ProtoMember(2)]
        public String ip;
        [ProtoMember(3)]
        public Int32 port;
    }
    [ProtoContract]
    public class S2SLadderInfo
    {
        [ProtoMember(1)]
        public Int32 ladderMrk;
        [ProtoMember(2)]
        public Int32 ladderScore;
        [ProtoMember(3)]
        public Int32 ladderScoreOld;
        [ProtoMember(4)]
        public Int32 ladderMrkOld;
    }
    [ProtoContract]
    public class QuestInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 progress;
        [ProtoMember(3)]
        public Int32 qid;
        [ProtoMember(4)]
        public Int32 questType;
    }
    [ProtoContract]
    public class QuestPointRewardInfo
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 point;
        [ProtoMember(3)]
        public Int32 itemId;
        [ProtoMember(4)]
        public Boolean recved;
    }
    [ProtoContract]
    public class RankInfo
    {
        [ProtoMember(1)]
        public Int32 score;
        [ProtoMember(2)]
        public Int32 rank;
        [ProtoMember(3)]
        public String name;
        [ProtoMember(4)]
        public String icon;
        [ProtoMember(5)]
        public String pid;
        [ProtoMember(6)]
        public String legionName;
        [ProtoMember(7)]
        public Int32 level;
        [ProtoMember(8)]
        public Int32 power;
    }
    [ProtoContract]
    public class ScienceInfo
    {
        [ProtoMember(1)]
        public Boolean open;
        [ProtoMember(2)]
        public Int32 tid;
        [ProtoMember(3)]
        public Int32 level;
        [ProtoMember(4)]
        public Boolean dev;
        [ProtoMember(5)]
        public Int64 devEndTime;
    }
    [ProtoContract]
    public class SkillInfo
    {
        [ProtoMember(1)]
        public Int32 sid;
        [ProtoMember(2)]
        public Int32 lv;
        [ProtoMember(3)]
        public Boolean carry;
    }
    [ProtoContract]
    public class ArmyInfo
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public String gid;
        [ProtoMember(3)]
        public String name;
        [ProtoMember(4)]
        public Single position;
        [ProtoMember(5)]
        public Int64 startTime;
        [ProtoMember(6)]
        public Int64 arriveTime;
        [ProtoMember(7)]
        public String origin;
        [ProtoMember(8)]
        public String target;
        [ProtoMember(9)]
        public Int32 state;
        [ProtoMember(10)]
        public Boolean speedUp;
        [ProtoMember(11)]
        public Int32 fightPoint;
    }
    [ProtoContract]
    public class ArmyOperate
    {
        [ProtoMember(1)]
        public Int32 operateType;
        [ProtoMember(2)]
        public Int32 hurtType;
        [ProtoMember(3)]
        public String armyID;
        [ProtoMember(4)]
        public String armyServerID;
        [ProtoMember(5)]
        public V3 armyPos;
        [ProtoMember(6)]
        public V3 moveTargetPos;
        [ProtoMember(7)]
        public List<V3> moveTargetPosList;
        [ProtoMember(8)]
        public Quaternion armyQuat;
        [ProtoMember(9)]
        public Quaternion tankGunBarrelQuat;
        [ProtoMember(10)]
        public String targetID;
        [ProtoMember(11)]
        public List<String> groupIdList;
        [ProtoMember(12)]
        public String targetServerID;
        [ProtoMember(13)]
        public String animName;
        [ProtoMember(14)]
        public Int32 hurtNumber;
        [ProtoMember(15)]
        public Boolean isBaoji;
        [ProtoMember(16)]
        public Int32 skillTID;
        [ProtoMember(17)]
        public V3 skillPos;
        [ProtoMember(18)]
        public Int32 buffId;
        [ProtoMember(19)]
        public Boolean isSkillAttack;
    }
    [ProtoContract]
    public class CityPointInfo
    {
        [ProtoMember(1)]
        public String positionId;
        [ProtoMember(2)]
        public String gid;
        [ProtoMember(3)]
        public String name;
        [ProtoMember(4)]
        public Int32 lv;
        [ProtoMember(5)]
        public String shortName;
        [ProtoMember(6)]
        public Int32 state;
        [ProtoMember(7)]
        public Int64 endTime;
        [ProtoMember(8)]
        public Int32 glory;
    }
    [ProtoContract]
    public class DropItem
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 cnt;
    }
    [ProtoContract]
    public class GuildMemberInfo
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public String name;
        [ProtoMember(3)]
        public String icon;
        [ProtoMember(4)]
        public Int32 lv;
        [ProtoMember(5)]
        public Int32 office;
        [ProtoMember(6)]
        public Int32 feat;
        [ProtoMember(7)]
        public Int32 state;
        [ProtoMember(8)]
        public Int32 metal;
        [ProtoMember(9)]
        public Int32 power;
    }
    [ProtoContract]
    public class GuildMessageInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public String sendGid;
        [ProtoMember(3)]
        public String senderName;
        [ProtoMember(4)]
        public String senderIcon;
        [ProtoMember(5)]
        public Int64 sendTime;
        [ProtoMember(6)]
        public String msg;
    }
    [ProtoContract]
    public class GuildRankInfo
    {
        [ProtoMember(1)]
        public String gid;
        [ProtoMember(2)]
        public String name;
        [ProtoMember(3)]
        public String shortName;
        [ProtoMember(4)]
        public Int32 rank;
        [ProtoMember(5)]
        public String serverName;
        [ProtoMember(6)]
        public Int32 glory;
    }
    [ProtoContract]
    public class GVGBattleInfo
    {
        [ProtoMember(1)]
        public String battleId;
        [ProtoMember(2)]
        public String attackerName;
        [ProtoMember(3)]
        public String attackerGid;
        [ProtoMember(4)]
        public String defenderId;
        [ProtoMember(5)]
        public Int64 time;
        [ProtoMember(6)]
        public Boolean win;
    }
    [ProtoContract]
    public class GVGBuildingInfo
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 lv;
        [ProtoMember(3)]
        public Int32 exp;
        [ProtoMember(4)]
        public Int32 maxExp;
        [ProtoMember(5)]
        public Single prop;
        [ProtoMember(6)]
        public Single propNext;
        [ProtoMember(7)]
        public Int32 donateSubMetal;
        [ProtoMember(8)]
        public Int32 donateSubDiamond;
        [ProtoMember(9)]
        public Int32 fixSubMetal;
        [ProtoMember(10)]
        public Int32 fixSubDiamond;
        [ProtoMember(11)]
        public Int32 metalModeAddFeat;
        [ProtoMember(12)]
        public Int32 diamondModeAddFeat;
    }
    [ProtoContract]
    public class GVGUnitInfo
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 unitId;
        [ProtoMember(3)]
        public Boolean dead;
        [ProtoMember(4)]
        public Boolean selected;
        [ProtoMember(5)]
        public Boolean resting;
        [ProtoMember(6)]
        public Int32 power;
        [ProtoMember(7)]
        public Int64 restStartTime;
        [ProtoMember(8)]
        public Int64 restEndTime;
    }
    [ProtoContract]
    public class ResPointInfo
    {
        [ProtoMember(1)]
        public String pointId;
        [ProtoMember(2)]
        public Int32 monsterId;
        [ProtoMember(3)]
        public Int32 hp;
        [ProtoMember(4)]
        public Int32 resCnt;
        [ProtoMember(5)]
        public Int32 resType;
        [ProtoMember(6)]
        public List<Int32> itemIds;
        [ProtoMember(7)]
        public Boolean battling;
    }
    [Proto(value = -1315, description = "检查我的开房信息")]
    [ProtoContract]
    public class CheckMyRoomInfoResponse
    {
        [ProtoMember(3)]
        public RoomInfo room;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1314, description = "快速进入房间")]
    [ProtoContract]
    public class QuickEnterRoomResponse
    {
        [ProtoMember(3)]
        public RoomInfo room;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1313, description = "开始战斗（房间内所有人都会推送到）")]
    [ProtoContract]
    public class MultiPlayerBattleResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 diff;
        [ProtoMember(5)]
        public String ip;
        [ProtoMember(6)]
        public Int32 port;
        [ProtoMember(7)]
        public String token;
        [ProtoMember(8)]
        public List<MatchBattlePlayerInfo> playerInfos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1312, description = "成员信息变更推送")]
    [ProtoContract]
    public class RoomMemberChangeNotify
    {
        [ProtoMember(3)]
        public Int32 op;
        [ProtoMember(4)]
        public MemberInfo member;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1311, description = "请求推荐列表")]
    [ProtoContract]
    public class RecommendationListResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public List<MemberInfo> members;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1310, description = "答复邀请")]
    [ProtoContract]
    public class ReplyInvitationResponse
    {
        [ProtoMember(3)]
        public RoomInfo room;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1309, description = "收到邀请")]
    [ProtoContract]
    public class InviteMemberNotify
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 diff;
        [ProtoMember(3)]
        public String roomId;
        [ProtoMember(4)]
        public MemberInfo member;
    }
    [Proto(value = -1308, description = "邀请成员")]
    [ProtoContract]
    public class InviteMemberResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1307, description = "更换房主")]
    [ProtoContract]
    public class ChangeRoomOwnerResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1306, description = "踢出成员")]
    [ProtoContract]
    public class KickOutRoomResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1305, description = "离开房间")]
    [ProtoContract]
    public class ExitRoomResponse
    {
        [ProtoMember(3)]
        public String roomId;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1304, description = "请求进入房间")]
    [ProtoContract]
    public class EnterRoomResponse
    {
        [ProtoMember(3)]
        public RoomInfo room;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1303, description = "设置密码")]
    [ProtoContract]
    public class SetRoomPasswordResponse
    {
        [ProtoMember(3)]
        public String password;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1302, description = "开房间")]
    [ProtoContract]
    public class CreateRoomResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 diff;
        [ProtoMember(5)]
        public String roomId;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1301, description = "请求大厅信息")]
    [ProtoContract]
    public class HallInfoResponse
    {
        [ProtoMember(3)]
        public List<RoomInfo> rooms;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1203, description = "充值信息返回")]
    [ProtoContract]
    public class ReceiveRewardResponse
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(5)]
        public Int32 tag;
        [ProtoMember(6)]
        public RewardInfo reward;
        [ProtoMember(7)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1202, description = "所有充值信息返回")]
    [ProtoContract]
    public class RechargeAllResponse
    {
        [ProtoMember(3)]
        public List<RechargeTagDetail> details;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1101, description = "公告信息返回")]
    [ProtoContract]
    public class BulletinResponse
    {
        [ProtoMember(3)]
        public List<BulletinInfo> bulletins;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1002, description = "绑定账号完成")]
    [ProtoContract]
    public class BindPlayerResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -1001, description = "清档")]
    [ProtoContract]
    public class ClearPlayerResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -913, description = "领取周常宝箱")]
    [ProtoContract]
    public class RecvWeekBoxResponse
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -912, description = "挑战周常关卡")]
    [ProtoContract]
    public class WeekBattleEndResponse
    {
        [ProtoMember(3)]
        public Int32 score;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(5)]
        public Boolean win;
        [ProtoMember(6)]
        public List<FightUnitInfo> units;
        [ProtoMember(7)]
        public Int32 battleDays;
        [ProtoMember(8)]
        public Int32 diff;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -911, description = "挑战周常关卡")]
    [ProtoContract]
    public class WeekBattleStartResponse
    {
        [ProtoMember(3)]
        public Int64 startTime;
        [ProtoMember(4)]
        public Int32 day;
        [ProtoMember(5)]
        public String token;
        [ProtoMember(6)]
        public List<MonsterInfo> monsters;
        [ProtoMember(7)]
        public Int32 diff;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -910, description = "请求周常信息")]
    [ProtoContract]
    public class GetWeekInfoResponse
    {
        [ProtoMember(3)]
        public Int32 day;
        [ProtoMember(4)]
        public Int32 numb;
        [ProtoMember(5)]
        public Int32 score;
        [ProtoMember(6)]
        public Int32 rank;
        [ProtoMember(7)]
        public List<Int32> recevedBoxes;
        [ProtoMember(8)]
        public Int32 battleDays;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -909, description = "购买返利推送")]
    [ProtoContract]
    public class RebateNotify
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 cnt;
    }
    [Proto(value = -906, description = "抽奖")]
    [ProtoContract]
    public class LotteryResponse
    {
        [ProtoMember(3)]
        public Int32 mode;
        [ProtoMember(4)]
        public Int32 method;
        [ProtoMember(5)]
        public RewardInfo rewardInfo;
        [ProtoMember(6)]
        public Int32 gold;
        [ProtoMember(7)]
        public Int32 diamond;
        [ProtoMember(8)]
        public Int32 goldUsedNumb;
        [ProtoMember(9)]
        public Int64 goldFreeNextTime;
        [ProtoMember(10)]
        public Int32 goldBaseNumb;
        [ProtoMember(11)]
        public Int32 goldFreeNumb;
        [ProtoMember(12)]
        public Int32 diamondUsedNumb;
        [ProtoMember(13)]
        public Int64 diamondFreeNextTime;
        [ProtoMember(14)]
        public Int32 diamondBaseNumb;
        [ProtoMember(15)]
        public Int32 diamondFreeNumb;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -905, description = "获取抽奖相关信息")]
    [ProtoContract]
    public class GetLotteryInfoResponse
    {
        [ProtoMember(3)]
        public Int32 goldUsedNumb;
        [ProtoMember(4)]
        public Int64 goldFreeNextTime;
        [ProtoMember(5)]
        public Int32 goldBaseNumb;
        [ProtoMember(6)]
        public Int32 goldFreeNumb;
        [ProtoMember(7)]
        public Int32 diamondUsedNumb;
        [ProtoMember(8)]
        public Int64 diamondFreeNextTime;
        [ProtoMember(9)]
        public Int32 diamondBaseNumb;
        [ProtoMember(10)]
        public Int32 diamondFreeNumb;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -901, description = "充值返利信息返回")]
    [ProtoContract]
    public class RebateInfoResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<RebateInfo> list;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -832, description = "军团战赛季结束")]
    [ProtoContract]
    public class GVGOverNotify
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -831, description = "兵种休整立即完成")]
    [ProtoContract]
    public class GVGRestFinishResponse
    {
        [ProtoMember(3)]
        public GVGUnitInfo unit;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -830, description = "维修主城")]
    [ProtoContract]
    public class GuildCityFixResponse
    {
        [ProtoMember(3)]
        public Int32 diamond;
        [ProtoMember(4)]
        public Int32 metal;
        [ProtoMember(5)]
        public Int32 hp;
        [ProtoMember(6)]
        public Boolean useDiamond;
        [ProtoMember(7)]
        public Int32 feat;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -829, description = "查看军团排行榜")]
    [ProtoContract]
    public class GuildRankResponse
    {
        [ProtoMember(3)]
        public List<GuildRankInfo> rankinglist;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -828, description = "军队召回")]
    [ProtoContract]
    public class ArmyBackResponse
    {
        [ProtoMember(3)]
        public ArmyInfo army;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -827, description = "战斗结束推送")]
    [ProtoContract]
    public class GVGBattleOverNotify
    {
        [ProtoMember(3)]
        public GVGBattleInfo battleInfo;
        [ProtoMember(4)]
        public Int32 guildGlory;
        [ProtoMember(5)]
        public Int32 feat;
        [ProtoMember(6)]
        public Int32 metal;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -826, description = "查看军团建筑")]
    [ProtoContract]
    public class GuildBuildingInfoResponse
    {
        [ProtoMember(3)]
        public List<GVGBuildingInfo> buildings;
        [ProtoMember(4)]
        public Int32 totalGarrison;
        [ProtoMember(5)]
        public Int32 curGarrison;
        [ProtoMember(6)]
        public Int32 HP;
        [ProtoMember(7)]
        public Int32 maxHP;
        [ProtoMember(8)]
        public Int32 atk;
        [ProtoMember(9)]
        public Int32 def;
        [ProtoMember(10)]
        public Single crit;
        [ProtoMember(11)]
        public Int32 atkAdd;
        [ProtoMember(12)]
        public Int32 defAdd;
        [ProtoMember(13)]
        public Single critAdd;
        [ProtoMember(14)]
        public Int32 maxHPAdd;
        [ProtoMember(15)]
        public Single robLimit;
        [ProtoMember(16)]
        public Int64 cdTime;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -825, description = "兵种休整")]
    [ProtoContract]
    public class GVGRestResponse
    {
        [ProtoMember(3)]
        public GVGUnitInfo unit;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -824, description = "查看军团成员列表")]
    [ProtoContract]
    public class GVGGuildMembersResponse
    {
        [ProtoMember(3)]
        public List<GuildMemberInfo> members;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -823, description = "查看公会战斗记录详情")]
    [ProtoContract]
    public class GVGBattleHistoyFullInfoResponse
    {
        [ProtoMember(3)]
        public String battleId;
        [ProtoMember(4)]
        public Boolean win;
        [ProtoMember(5)]
        public String attackerName;
        [ProtoMember(6)]
        public String attackerGid;
        [ProtoMember(7)]
        public String defenderId;
        [ProtoMember(8)]
        public Int64 time;
        [ProtoMember(9)]
        public Boolean gain;
        [ProtoMember(10)]
        public Int32 gold;
        [ProtoMember(11)]
        public Int32 supply;
        [ProtoMember(12)]
        public Int32 iron;
        [ProtoMember(13)]
        public Int32 feat;
        [ProtoMember(14)]
        public Int32 metal;
        [ProtoMember(15)]
        public Int32 glory;
        [ProtoMember(16)]
        public List<DropItem> itemsGuild;
        [ProtoMember(17)]
        public List<DropItem> itemsPersonal;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -822, description = "查看战斗记录")]
    [ProtoContract]
    public class GVGBattleHistoriesResponse
    {
        [ProtoMember(3)]
        public List<GVGBattleInfo> histories;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -821, description = "查看公会的详细记录")]
    [ProtoContract]
    public class GetGuildDetailInfoResponse
    {
        [ProtoMember(1)]
        public String gid;
        [ProtoMember(2)]
        public Int32 guildLv;
        [ProtoMember(3)]
        public Int32 cityLv;
        [ProtoMember(4)]
        public Int32 playerCnt;
        [ProtoMember(5)]
        public Int32 glory;
        [ProtoMember(6)]
        public Int32 attackGuildCnt;
        [ProtoMember(7)]
        public Int32 attackResPointCnt;
        [ProtoMember(8)]
        public Int32 destoryGuildCnt;
        [ProtoMember(9)]
        public Int32 curRank;
        [ProtoMember(10)]
        public Int32 maxRank;
        [ProtoMember(11)]
        public Int32 defendWin;
        [ProtoMember(12)]
        public Int32 defendLose;
    }
    [Proto(value = -820, description = "查看资源点详情")]
    [ProtoContract]
    public class ResPointResponse
    {
        [ProtoMember(3)]
        public ResPointInfo resPointInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -819, description = "查收所有公会私信")]
    [ProtoContract]
    public class GuildMessageResponse
    {
        [ProtoMember(3)]
        public List<GuildMessageInfo> msgs;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -818, description = "收到公会私信")]
    [ProtoContract]
    public class GuildMessageNotify
    {
        [ProtoMember(3)]
        public GuildMessageInfo msg;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -817, description = "（公会战内）发送公会私信")]
    [ProtoContract]
    public class SendGuildMessageResponse
    {
        [ProtoMember(3)]
        public String gid;
        [ProtoMember(4)]
        public String msg;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -816, description = "查看自己的详细信息")]
    [ProtoContract]
    public class PlayerDetailResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public String name;
        [ProtoMember(5)]
        public String icon;
        [ProtoMember(6)]
        public String guildShortName;
        [ProtoMember(7)]
        public List<GVGUnitInfo> units;
        [ProtoMember(8)]
        public Boolean marching;
        [ProtoMember(9)]
        public Boolean garrisoning;
        [ProtoMember(10)]
        public Int32 metal;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -815, description = "查看地图上部队的详细信息")]
    [ProtoContract]
    public class ArmyDetailResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public String pid;
        [ProtoMember(5)]
        public String name;
        [ProtoMember(6)]
        public String icon;
        [ProtoMember(7)]
        public String guildShortName;
        [ProtoMember(8)]
        public Int32 totalPowerPoint;
        [ProtoMember(9)]
        public List<GVGUnitInfo> unitIds;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -814, description = "（公会战内）请求公会详情")]
    [ProtoContract]
    public class GuildDetailResponse
    {
        [ProtoMember(3)]
        public String gid;
        [ProtoMember(4)]
        public String posId;
        [ProtoMember(5)]
        public Int32 cityLv;
        [ProtoMember(6)]
        public String leaderPid;
        [ProtoMember(7)]
        public String leaderName;
        [ProtoMember(8)]
        public String leaderIcon;
        [ProtoMember(9)]
        public String name;
        [ProtoMember(10)]
        public Int32 state;
        [ProtoMember(11)]
        public Int32 glory;
        [ProtoMember(12)]
        public Int32 totalGarrison;
        [ProtoMember(13)]
        public Int32 curGarrison;
        [ProtoMember(14)]
        public List<Int32> items;
        [ProtoMember(15)]
        public Int32 HP;
        [ProtoMember(16)]
        public Int32 maxHP;
        [ProtoMember(17)]
        public Int32 atk;
        [ProtoMember(18)]
        public Int32 def;
        [ProtoMember(19)]
        public Single crit;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -813, description = "请求该点关联的部队")]
    [ProtoContract]
    public class QueryArmiesByPointResponse
    {
        [ProtoMember(3)]
        public List<ArmyInfo> armies;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -812, description = "公会战登录")]
    [ProtoContract]
    public class GVGLoginResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public Boolean marching;
        [ProtoMember(5)]
        public Boolean garrisoning;
        [ProtoMember(6)]
        public Int32 metal;
        [ProtoMember(7)]
        public Int32 feat;
        [ProtoMember(8)]
        public Int32 guildGlory;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -811, description = "（公会战）设置出征阵容")]
    [ProtoContract]
    public class GVGSetTeamResponse
    {
        [ProtoMember(3)]
        public String uid;
        [ProtoMember(4)]
        public Boolean selected;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -810, description = "（公会战）地图中野怪信息改变的通知")]
    [ProtoContract]
    public class GVGResPointNotify
    {
        [ProtoMember(3)]
        public Int32 state;
        [ProtoMember(4)]
        public ResPointInfo mpInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -809, description = "（公会战）地图中部队信息改变的通知")]
    [ProtoContract]
    public class GVGGuildChangeNotify
    {
        [ProtoMember(3)]
        public CityPointInfo guildInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -808, description = "（公会战）地图中部队信息改变的通知")]
    [ProtoContract]
    public class GVGArmyChangeNotify
    {
        [ProtoMember(3)]
        public Int32 operation;
        [ProtoMember(4)]
        public ArmyInfo armyInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -807, description = "（公会战）加速行军")]
    [ProtoContract]
    public class GVGSpeedUpResponse
    {
        [ProtoMember(3)]
        public ArmyInfo armyInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -806, description = "（公会战）捐献结果返回")]
    [ProtoContract]
    public class GVGDonateResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 lv;
        [ProtoMember(5)]
        public Int32 curExp;
        [ProtoMember(6)]
        public Int32 totalExp;
        [ProtoMember(7)]
        public Int32 addExp;
        [ProtoMember(8)]
        public Single prop;
        [ProtoMember(9)]
        public Single propNext;
        [ProtoMember(10)]
        public Single propTotal;
        [ProtoMember(11)]
        public Single propAdd;
        [ProtoMember(12)]
        public Int32 cityCurExp;
        [ProtoMember(13)]
        public Int32 cityTotalExp;
        [ProtoMember(14)]
        public Int32 cityLv;
        [ProtoMember(15)]
        public Int32 diamond;
        [ProtoMember(16)]
        public Int32 metal;
        [ProtoMember(17)]
        public Int32 feat;
        [ProtoMember(18)]
        public Boolean isUseDiamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -805, description = "（公会战）驻军")]
    [ProtoContract]
    public class GVGGarrisonResponse
    {
        [ProtoMember(3)]
        public Boolean garrison;
        [ProtoMember(4)]
        public Int32 totalGarrison;
        [ProtoMember(5)]
        public Int32 curGarrison;
        [ProtoMember(6)]
        public Int32 atkAdd;
        [ProtoMember(7)]
        public Int32 defAdd;
        [ProtoMember(8)]
        public Single critAdd;
        [ProtoMember(9)]
        public Int32 atk;
        [ProtoMember(10)]
        public Int32 def;
        [ProtoMember(11)]
        public Single crit;
        [ProtoMember(12)]
        public Single robLimit;
        [ProtoMember(13)]
        public Int64 cdTime;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -804, description = "（公会战）出战")]
    [ProtoContract]
    public class GVGFightResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -803, description = "公会战报名结果返回")]
    [ProtoContract]
    public class GVGEnrollResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -802, description = "公会战的举办情况")]
    [ProtoContract]
    public class GVGInfoResponse
    {
        [ProtoMember(3)]
        public Int64 startTime;
        [ProtoMember(4)]
        public Int64 endTime;
        [ProtoMember(5)]
        public Int64 enrollStartTime;
        [ProtoMember(6)]
        public Int64 enrollEndTime;
        [ProtoMember(7)]
        public String ip;
        [ProtoMember(8)]
        public Int32 port;
        [ProtoMember(9)]
        public String token;
        [ProtoMember(10)]
        public Int32 state;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -800, description = "（公会战内）公会战战场信息")]
    [ProtoContract]
    public class GVGMapResponse
    {
        [ProtoMember(3)]
        public List<CityPointInfo> cities;
        [ProtoMember(4)]
        public List<ResPointInfo> resPoint;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -718, description = "收集物品数量推送")]
    [ProtoContract]
    public class CollectChangeNotify
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public Int32 count;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -717, description = "最高战力变更推送")]
    [ProtoContract]
    public class MaxPowerChangeNotify
    {
        [ProtoMember(3)]
        public Int32 Power;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -716, description = "剩余购买次数推送")]
    [ProtoContract]
    public class RemainTimeNotify
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public Int32 times;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -715, description = "领取目标奖励返回")]
    [ProtoContract]
    public class ReceiveAimRewardResponse
    {
        [ProtoMember(3)]
        public RewardInfo reward;
        [ProtoMember(4)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -714, description = "活动数据返回")]
    [ProtoContract]
    public class ReceiveWalfareResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 id;
        [ProtoMember(5)]
        public RewardInfo reward;
        [ProtoMember(6)]
        public Int32 diamond;
        [ProtoMember(7)]
        public Int32 times;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -713, description = "活动数据返回")]
    [ProtoContract]
    public class QiRiInfoResponse
    {
        [ProtoMember(3)]
        public List<QiRiWalfareInfo> lists;
        [ProtoMember(4)]
        public Int32 actually_day;
        [ProtoMember(5)]
        public Boolean joined;
        [ProtoMember(6)]
        public List<QiRiWalfareInfo> AimReward;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -712, description = "领取在线奖励")]
    [ProtoContract]
    public class RecvOnlineRewardResponse
    {
        [ProtoMember(3)]
        public Int64 nextRecvTime;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(5)]
        public RewardInfo nextReward;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -711, description = "在线奖励信息")]
    [ProtoContract]
    public class GetOnlineRewardInfoResponse
    {
        [ProtoMember(3)]
        public Int64 recvTime;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -710, description = "充值信息返回")]
    [ProtoContract]
    public class RechargeInfoResponse
    {
        [ProtoMember(3)]
        public List<RechargeInfo> rechargeInfos;
        [ProtoMember(4)]
        public Single rechargeDiamond;
        [ProtoMember(5)]
        public Int32 diamondConsume;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -709, description = "进度更新推送")]
    [ProtoContract]
    public class NewProcessNotify
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public Int32 newProcess;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -707, description = "累计消费钻石数量推送")]
    [ProtoContract]
    public class DiamondConsumeNotify
    {
        [ProtoMember(1)]
        public Int32 diamond;
    }
    [Proto(value = -706, description = "购买限时礼包返回")]
    [ProtoContract]
    public class BuyGiftResponse
    {
        [ProtoMember(3)]
        public String product_id;
        [ProtoMember(4)]
        public LimitGiftInfo gift;
        [ProtoMember(5)]
        public RewardInfo reward;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -705, description = "限时充值活动礼包列表")]
    [ProtoContract]
    public class LimitGiftResponse
    {
        [ProtoMember(3)]
        public List<LimitGiftInfo> giftInfos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -704, description = "请求全部活动数据")]
    [ProtoContract]
    public class ActivityAllInfoResponse
    {
        [ProtoMember(3)]
        public List<ActivityTagDetail> allInfos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -703, description = "购买成长套餐返回")]
    [ProtoContract]
    public class ActivityBuyCZResponse
    {
        [ProtoMember(3)]
        public Int32 tag;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -702, description = "领取活动奖励返回")]
    [ProtoContract]
    public class ReceiveActivityRewardResponse
    {
        [ProtoMember(3)]
        public RewardInfo reward;
        [ProtoMember(4)]
        public Int32 id;
        [ProtoMember(5)]
        public Int32 type;
        [ProtoMember(6)]
        public Int32 tag;
        [ProtoMember(7)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -701, description = "活动数据返回")]
    [ProtoContract]
    public class ActivityInfoResponse
    {
        [ProtoMember(3)]
        public ActivityTagDetail detail;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -700, description = "活动类型列表")]
    [ProtoContract]
    public class ActivityListResponse
    {
        [ProtoMember(3)]
        public List<ActivityTagInfo> tagInfos;
        [ProtoMember(4)]
        public Int32 now_maxPower;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -657, description = "（战斗服）抢滩保卫战，出兵")]
    [ProtoContract]
    public class MultiDefenceEnemyCreatedNotify
    {
        [ProtoMember(1)]
        public MonsterInfo monsters;
        [ProtoMember(2)]
        public Int32 wave;
        [ProtoMember(3)]
        public Int32 number;
    }
    [Proto(value = -655, description = "（战斗服）抢滩保卫战，积分改变")]
    [ProtoContract]
    public class MultiDefenceScoreChangeNotify
    {
        [ProtoMember(1)]
        public Int32 score;
        [ProtoMember(2)]
        public String pid;
    }
    [Proto(value = -654, description = "激活兵种返回")]
    [ProtoContract]
    public class MultiDefenceActivateUnitResponse
    {
        [ProtoMember(3)]
        public Int32 score;
        [ProtoMember(4)]
        public Int32 unitId;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -653, description = "查询抢滩战信息返回")]
    [ProtoContract]
    public class GetMultiDefenceInfoResponse
    {
        [ProtoMember(3)]
        public Int32 score;
        [ProtoMember(4)]
        public List<Int32> ownedUnits;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -652, description = "（游戏服）抢滩保卫战，战斗结束")]
    [ProtoContract]
    public class MultiDefenceBattleOverNotify
    {
        [ProtoMember(1)]
        public Boolean win;
        [ProtoMember(2)]
        public List<MultiDefencePlayerInfo> players;
    }
    [Proto(value = -651, description = "（战斗服）抢滩保卫战，购买造兵点返回")]
    [ProtoContract]
    public class MultiDefenceBuyCreatePointResponse
    {
        [ProtoMember(3)]
        public Int32 createPoint;
        [ProtoMember(4)]
        public Int32 costDiamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -650, description = "（战斗服）抢滩保卫战，下一波开始")]
    [ProtoContract]
    public class MultiDefenceEnemyWaveNotify
    {
        [ProtoMember(1)]
        public Int32 wave;
    }
    [Proto(value = -625, description = "扫荡运输副本")]
    [ProtoContract]
    public class SweepTransportResponse
    {
        [ProtoMember(3)]
        public RewardInfo rewardInfo;
        [ProtoMember(4)]
        public Int32 difficultDegree;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -624, description = "购买科研序列")]
    [ProtoContract]
    public class BuyScienceNumbResponse
    {
        [ProtoMember(3)]
        public Int32 totalDevs;
        [ProtoMember(4)]
        public Int32 buyNumb;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -623, description = "购买运输副本挑战次数")]
    [ProtoContract]
    public class BuyTransportTimesResponse
    {
        [ProtoMember(3)]
        public Int32 buyTimes;
        [ProtoMember(4)]
        public Int32 usedNumber;
        [ProtoMember(5)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -622, description = "玩家的运输玩法数据")]
    [ProtoContract]
    public class EndTransportResponse
    {
        [ProtoMember(3)]
        public RewardInfo rewardInfo;
        [ProtoMember(4)]
        public Int32 difficultDegree;
        [ProtoMember(5)]
        public Boolean win;
        [ProtoMember(6)]
        public List<FightUnitInfo> units;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -621, description = "进入运输副本")]
    [ProtoContract]
    public class StartTransportResponse
    {
        [ProtoMember(3)]
        public List<MonsterWaveInfo> monsters;
        [ProtoMember(4)]
        public List<MonsterInfo> trucks;
        [ProtoMember(5)]
        public Int32 resNumber;
        [ProtoMember(6)]
        public String battleToken;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -620, description = "玩家的运输玩法数据")]
    [ProtoContract]
    public class GetTransportInfoResponse
    {
        [ProtoMember(3)]
        public Int32 remainTimes;
        [ProtoMember(4)]
        public Int32 totalTimes;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -603, description = "PVP匹配开始的推送")]
    [ProtoContract]
    public class PVPNotify
    {
        [ProtoMember(1)]
        public String name;
        [ProtoMember(2)]
        public String pid;
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int64 time;
    }
    [Proto(value = -602, description = "获取天梯战斗记录返回")]
    [ProtoContract]
    public class GetLadderHistoryResponse
    {
        [ProtoMember(3)]
        public List<LadderBattleInfo> battles;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -601, description = "天梯战斗结束（推送）")]
    [ProtoContract]
    public class LadderBattleOverNotify
    {
        [ProtoMember(3)]
        public List<LadderPlayerBattleInfo> players;
        [ProtoMember(4)]
        public RewardInfo rewardInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -600, description = "天梯信息返回")]
    [ProtoContract]
    public class GetLadderInfoResponse
    {
        [ProtoMember(3)]
        public Int32 militaryRank;
        [ProtoMember(4)]
        public Int32 ladderScore;
        [ProtoMember(5)]
        public Int32 normalNumber;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -511, description = "（战斗服）返回战斗信息：战斗是否已经开始")]
    [ProtoContract]
    public class BattleStateResponse
    {
        [ProtoMember(2)]
        public Int32 state;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -510, description = "（战斗服）踢出战斗")]
    [ProtoContract]
    public class B2CKick
    {
        [ProtoMember(2)]
        public Int32 reason;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -509, description = "拉取全战场数据")]
    [ProtoContract]
    public class B2CPullAllBattleData
    {
        [ProtoMember(1)]
        public String battleKey;
    }
    [Proto(value = -507, description = "（战斗服）Pong")]
    [ProtoContract]
    public class B2CPong
    {
        [ProtoMember(2)]
        public Int64 sendTime;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -506, description = "（战斗服）发送全部数据")]
    [ProtoContract]
    public class B2CBattleFieldData
    {
        [ProtoMember(2)]
        public List<PVPPlayerInfo> playerInfos;
        [ProtoMember(3)]
        public List<PVPFlag> flags;
        [ProtoMember(4)]
        public List<BattleMonsterInfo> monsters;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -505, description = "（战斗服）使用技能")]
    [ProtoContract]
    public class B2CUseSkill
    {
        [ProtoMember(2)]
        public String pid;
        [ProtoMember(3)]
        public String uid;
        [ProtoMember(4)]
        public Int32 skillId;
        [ProtoMember(5)]
        public V3 position;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -504, description = "（战斗服）造兵")]
    [ProtoContract]
    public class B2CCreateArmy
    {
        [ProtoMember(2)]
        public String pid;
        [ProtoMember(3)]
        public Int32 remainPoint;
        [ProtoMember(4)]
        public Int32 bornPlace;
        [ProtoMember(5)]
        public UnitInfo unitInfo;
        [ProtoMember(6)]
        public MonsterInfo monsterInfo;
        [ProtoMember(7)]
        public Int32 teamIndex;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -503, description = "（战斗服）同步分数")]
    [ProtoContract]
    public class B2CSetSocre
    {
        [ProtoMember(2)]
        public List<PVPScoreInfo> scores;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -502, description = "（战斗服）造成伤害")]
    [ProtoContract]
    public class B2CDamage
    {
        [ProtoMember(2)]
        public Int32 skillId;
        [ProtoMember(3)]
        public String attackGoId;
        [ProtoMember(4)]
        public String hurtGoId;
        [ProtoMember(5)]
        public Int32 damage;
        [ProtoMember(6)]
        public Int32 hurtType;
        [ProtoMember(7)]
        public Boolean isBaoji;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -501, description = "（战斗服）占领旗帜")]
    [ProtoContract]
    public class B2CCaptureFlag
    {
        [ProtoMember(2)]
        public Int32 flagId;
        [ProtoMember(3)]
        public Int32 group;
        [ProtoMember(4)]
        public String pid;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -500, description = "（战斗服）洗旗状态需要改变")]
    [ProtoContract]
    public class B2CUpdateFlagStatus
    {
        [ProtoMember(2)]
        public Int32 flagId;
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = -402, description = "VIP信息改变的推送")]
    [ProtoContract]
    public class VIPInfoChangedNotify
    {
        [ProtoMember(3)]
        public Int32 newVipLv;
        [ProtoMember(4)]
        public Int32 newVipExp;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -401, description = "领取vip礼包返回")]
    [ProtoContract]
    public class GetVIPGiftResponse
    {
        [ProtoMember(3)]
        public Int32 vip;
        [ProtoMember(4)]
        public RewardInfo rewardInfo;
        [ProtoMember(5)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -400, description = "VIP信息返回")]
    [ProtoContract]
    public class VIPInfoResponse
    {
        [ProtoMember(3)]
        public Int32 vipLevel;
        [ProtoMember(4)]
        public Int32 vipExp;
        [ProtoMember(5)]
        public Int32 nextLvExp;
        [ProtoMember(6)]
        public List<Int32> receivedGifts;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -367, description = "审核设置")]
    [ProtoContract]
    public class ChangerCheckResponse
    {
        [ProtoMember(3)]
        public Boolean check;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -366, description = "群发邮件")]
    [ProtoContract]
    public class MassMailResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -365, description = "科技列表")]
    [ProtoContract]
    public class PartyScienceListResponse
    {
        [ProtoMember(3)]
        public String party;
        [ProtoMember(4)]
        public List<PartyScienceInfo> sciences;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -364, description = "解散")]
    [ProtoContract]
    public class DestroyPartyResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -363, description = "修改党信息")]
    [ProtoContract]
    public class ModifyPartyResponse
    {
        [ProtoMember(3)]
        public String party;
        [ProtoMember(4)]
        public String name;
        [ProtoMember(5)]
        public String icon;
        [ProtoMember(6)]
        public String note;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -362, description = "发言")]
    [ProtoContract]
    public class TalkOnBBSResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -361, description = "留言板")]
    [ProtoContract]
    public class PartyBBSResponse
    {
        [ProtoMember(3)]
        public String party;
        [ProtoMember(4)]
        public List<PartyWordsInfo> wordsList;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -360, description = "退党")]
    [ProtoContract]
    public class LeavePartyResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -359, description = "党详情")]
    [ProtoContract]
    public class PartyDetailResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public PartyInfo pi;
        [ProtoMember(5)]
        public List<PartyMemberInfo> members;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -358, description = "交党费")]
    [ProtoContract]
    public class PayPartyResponse
    {
        [ProtoMember(3)]
        public ContriLogInfo log;
        [ProtoMember(4)]
        public Int32 cur;
        [ProtoMember(5)]
        public RewardInfo rewardInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -357, description = "党费")]
    [ProtoContract]
    public class PartyContriResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public Int32 cur;
        [ProtoMember(5)]
        public Int32 max;
        [ProtoMember(6)]
        public List<ContriInfo> contries;
        [ProtoMember(7)]
        public List<ContriLogInfo> logs;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -356, description = "人事调整")]
    [ProtoContract]
    public class PersonnelResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public Int32 career;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -355, description = "处理入党申请")]
    [ProtoContract]
    public class ProcessApplyResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Boolean pass;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -354, description = "入党申请列表")]
    [ProtoContract]
    public class ApplyListResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public List<ApplyInfo> applies;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -353, description = "党员列表")]
    [ProtoContract]
    public class MemberListResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public List<PartyMemberInfo> members;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -352, description = "党列表")]
    [ProtoContract]
    public class PartyListResponse
    {
        [ProtoMember(3)]
        public List<PartyInfo> parties;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -351, description = "申请入党")]
    [ProtoContract]
    public class ApplyPartyResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -350, description = "建党")]
    [ProtoContract]
    public class CreatePartyResponse
    {
        [ProtoMember(3)]
        public PartyInfo party;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -333, description = "提交主线任务")]
    [ProtoContract]
    public class MainlineSubmitResponse
    {
        [ProtoMember(3)]
        public Int32 curId;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(5)]
        public Int32 chapter;
        [ProtoMember(6)]
        public Boolean finished;
        [ProtoMember(7)]
        public List<MainlineInfo> infos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -332, description = "主线任务完成推送")]
    [ProtoContract]
    public class MainlineCompleteNotify
    {
        [ProtoMember(3)]
        public Int32 curId;
        [ProtoMember(4)]
        public Int32 newId;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -331, description = "主线任务进度改变推送")]
    [ProtoContract]
    public class MainlineProgressChangeNotify
    {
        [ProtoMember(3)]
        public Int32 mainlineId;
        [ProtoMember(4)]
        public Int32 progress;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -330, description = "请求当前主线")]
    [ProtoContract]
    public class MainlineResponse
    {
        [ProtoMember(3)]
        public Int32 chapter;
        [ProtoMember(4)]
        public Boolean finished;
        [ProtoMember(5)]
        public List<MainlineInfo> infos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -312, description = "一键添加好友")]
    [ProtoContract]
    public class ProcessAllFriendAddResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<String> fs;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -311, description = "删除好友推送")]
    [ProtoContract]
    public class FriendDelNotify
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -310, description = "收到好友赠送原油通知")]
    [ProtoContract]
    public class GiveOilNotify
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -309, description = "收到加好友申请")]
    [ProtoContract]
    public class FriendAddRequestNotify
    {
        [ProtoMember(3)]
        public FriendInfo friend;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -308, description = "新好友通知")]
    [ProtoContract]
    public class NewFriendNotify
    {
        [ProtoMember(3)]
        public FriendInfo friend;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -307, description = "删除好友")]
    [ProtoContract]
    public class DelFriendResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -306, description = "处理好友申请")]
    [ProtoContract]
    public class ProcessFriendAddResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Boolean pass;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -305, description = "好友申请列表")]
    [ProtoContract]
    public class FriendAddListResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<FriendInfo> ps;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -304, description = "添加好友")]
    [ProtoContract]
    public class AddFriendResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -303, description = "推荐好友列表")]
    [ProtoContract]
    public class RecommendFriendListResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<FriendInfo> friends;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -302, description = "赠送好友原油")]
    [ProtoContract]
    public class GiveOilToFriendResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Boolean all;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -301, description = "收取好友赠送的原油")]
    [ProtoContract]
    public class GetOilFromFriendResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Boolean all;
        [ProtoMember(5)]
        public Int32 oilRemain;
        [ProtoMember(6)]
        public Int32 oilTimes;
        [ProtoMember(7)]
        public Int32 maxOilTimes;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -300, description = "好友列表")]
    [ProtoContract]
    public class FriendListResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public Int32 maxOilTimes;
        [ProtoMember(5)]
        public Int32 oilTimes;
        [ProtoMember(6)]
        public List<FriendInfo> friends;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -251, description = "回收兵种")]
    [ProtoContract]
    public class ReclaimUnitResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 diamond;
        [ProtoMember(5)]
        public UnitInfo unitInfo;
        [ProtoMember(6)]
        public RewardInfo rewardInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -225, description = "扫荡雪地营救返回")]
    [ProtoContract]
    public class SweepRescueResponse
    {
        [ProtoMember(3)]
        public Int32 difficulty;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -224, description = "购买雪地营救次数")]
    [ProtoContract]
    public class BuyRescueResponse
    {
        [ProtoMember(3)]
        public Int32 buyTimes;
        [ProtoMember(4)]
        public Int32 playedNumb;
        [ProtoMember(5)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -223, description = "结束雪地营救")]
    [ProtoContract]
    public class EndRescueResponse
    {
        [ProtoMember(3)]
        public RewardInfo reward;
        [ProtoMember(4)]
        public Boolean win;
        [ProtoMember(5)]
        public List<FightUnitInfo> units;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -222, description = "开始雪地营救返回")]
    [ProtoContract]
    public class StartRescueResponse
    {
        [ProtoMember(3)]
        public String battleId;
        [ProtoMember(4)]
        public List<TeamPlaceInfo> friendTeam;
        [ProtoMember(5)]
        public List<MonsterInfo> monster;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -221, description = "雪地营救信息")]
    [ProtoContract]
    public class GetRescueFriendsResponse
    {
        [ProtoMember(3)]
        public List<String> friends;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -220, description = "玩法信息")]
    [ProtoContract]
    public class GetPatternInfoResponse
    {
        [ProtoMember(3)]
        public List<PVEPatternInfo> infos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -200, description = "作弊返回")]
    [ProtoContract]
    public class CheatResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -153, description = "竞技场时间重置")]
    [ProtoContract]
    public class FlagCDResetResponse
    {
        [ProtoMember(3)]
        public Int64 nextTime;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -152, description = "查看玩家信息")]
    [ProtoContract]
    public class ShowPlayerResponse
    {
        [ProtoMember(3)]
        public String name;
        [ProtoMember(4)]
        public Int32 level;
        [ProtoMember(5)]
        public String legionName;
        [ProtoMember(6)]
        public String icon;
        [ProtoMember(7)]
        public Int32 vip;
        [ProtoMember(8)]
        public String pid;
        [ProtoMember(9)]
        public Boolean isfriend;
        [ProtoMember(10)]
        public Int32 power;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -151, description = "排行榜")]
    [ProtoContract]
    public class GetRankingListResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 myRank;
        [ProtoMember(5)]
        public List<RankInfo> rankInfos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -150, description = "查看阵容信息")]
    [ProtoContract]
    public class GetTeamInfoResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<TeamPlaceInfo> team;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -149, description = "夺旗排名奖励返回")]
    [ProtoContract]
    public class GrabFlagRankRewardResponse
    {
        [ProtoMember(3)]
        public List<GrabFlagRankRewardInfo> rewardInfos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -148, description = "夺旗奖励领取结果")]
    [ProtoContract]
    public class ReceiveGrabFlagScoreRewardResponse
    {
        [ProtoMember(3)]
        public Int32 rewardId;
        [ProtoMember(4)]
        public RewardInfo rewardInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -146, description = "夺旗积分奖励返回")]
    [ProtoContract]
    public class GrabFlagScoreResponse
    {
        [ProtoMember(3)]
        public Int32 score;
        [ProtoMember(4)]
        public List<GrabFlagScoreInfo> scoreInfos;
        [ProtoMember(5)]
        public Int64 nextTime;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -145, description = "夺旗战对战记录返回")]
    [ProtoContract]
    public class GrabFlagBattleHistoryResponse
    {
        [ProtoMember(3)]
        public List<GrabFlagBattleHistoryInfo> histories;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -144, description = "挑战请求返回")]
    [ProtoContract]
    public class GrabFlagBattleChallengeResponse
    {
        [ProtoMember(3)]
        public List<UnitInfo> adversaryUnits;
        [ProtoMember(4)]
        public List<UnitInfo> myUnits;
        [ProtoMember(5)]
        public String battleId;
        [ProtoMember(6)]
        public String enemyName;
        [ProtoMember(7)]
        public Int32 remainChallengeTimes;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -143, description = "挑战结束结果返回")]
    [ProtoContract]
    public class GrabFlagBattleChallengeOverResponse
    {
        [ProtoMember(3)]
        public String adversaryPid;
        [ProtoMember(4)]
        public List<FlagBreakRankReward> rewards;
        [ProtoMember(5)]
        public RewardInfo reward;
        [ProtoMember(6)]
        public Boolean win;
        [ProtoMember(7)]
        public Int32 remainChallengeTimes;
        [ProtoMember(8)]
        public Int32 orginalRank;
        [ProtoMember(9)]
        public Int32 currentRank;
        [ProtoMember(10)]
        public Int32 score;
        [ProtoMember(11)]
        public Int64 nextTime;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -142, description = "夺旗战的对手列表返回")]
    [ProtoContract]
    public class GrabFlagAdversariesResponse
    {
        [ProtoMember(3)]
        public Int32 remainChallengTimes;
        [ProtoMember(4)]
        public Int32 buyTimes;
        [ProtoMember(5)]
        public Int32 currentRank;
        [ProtoMember(6)]
        public Int32 score;
        [ProtoMember(7)]
        public List<GrabFlagAdversaryInfo> adversaries;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -141, description = "购买夺旗战挑战次数返回")]
    [ProtoContract]
    public class BuyGrabFlagChallengeTimesResponse
    {
        [ProtoMember(3)]
        public Int32 remainChallengeTimes;
        [ProtoMember(4)]
        public Int32 buyTimes;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -140, description = "踢下线，不要重连")]
    [ProtoContract]
    public class KickOutNotify
    {
        [ProtoMember(3)]
        public Int32 reason;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -137, description = "刷新结果")]
    [ProtoContract]
    public class MallShopRefreshResponse
    {
        [ProtoMember(3)]
        public List<MallShopInfo> shops;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -136, description = "购买宝箱")]
    [ProtoContract]
    public class BuyBoxResponse
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(5)]
        public Int32 remain;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -132, description = "兵种解锁返回")]
    [ProtoContract]
    public class UnlockUnitResponse
    {
        [ProtoMember(3)]
        public Int32 unitId;
        [ProtoMember(4)]
        public UnitInfo unitInfo;
        [ProtoMember(5)]
        public Int32 itemId;
        [ProtoMember(6)]
        public Int32 itemCnt;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -131, description = "购买物品")]
    [ProtoContract]
    public class BuyItemResponse
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(5)]
        public Int32 remain;
        [ProtoMember(6)]
        public Int32 res_type;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -130, description = "商城详情")]
    [ProtoContract]
    public class MallInfoResponse
    {
        [ProtoMember(3)]
        public List<MallShopInfo> items;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -129, description = "战斗结束")]
    [ProtoContract]
    public class BattleEndNotify
    {
        [ProtoMember(1)]
        public MatchBattleResultInfo resultInfo;
    }
    [Proto(value = -128, description = "（战斗服）战斗开始")]
    [ProtoContract]
    public class BattleStartNotify
    {
        [ProtoMember(1)]
        public Int64 startTime;
    }
    [Proto(value = -127, description = "（战斗服）战斗主机")]
    [ProtoContract]
    public class BattleHostNotify
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = -126, description = "（战斗服）战斗行为")]
    [ProtoContract]
    public class BattleActionNotify
    {
        [ProtoMember(1)]
        public ArmyOperate armyOperate;
        [ProtoMember(2)]
        public String pid;
        [ProtoMember(3)]
        public Int64 time;
    }
    [Proto(value = -125, description = "（战斗服）读条返回")]
    [ProtoContract]
    public class MatchBattleLoadingResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public Int32 progress;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -124, description = "开始加载战斗")]
    [ProtoContract]
    public class MatchStartLoadingNotify
    {
        [ProtoMember(3)]
        public Int32 randomSeed;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -123, description = "战斗开始确定")]
    [ProtoContract]
    public class MatchBattleConfirmResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -122, description = "匹配成功推送")]
    [ProtoContract]
    public class MatchSuccessNotify
    {
        [ProtoMember(3)]
        public List<MatchBattlePlayerInfo> playerInfos;
        [ProtoMember(4)]
        public Int32 conv;
        [ProtoMember(5)]
        public Int32 type;
        [ProtoMember(6)]
        public String ip;
        [ProtoMember(7)]
        public Int32 port;
        [ProtoMember(8)]
        public String token;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -121, description = "取消匹配结果")]
    [ProtoContract]
    public class MatchCancelResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -120, description = "发起匹配结果")]
    [ProtoContract]
    public class MatchResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -117, description = "重置工人")]
    [ProtoContract]
    public class ResetWorkerResponse
    {
        [ProtoMember(3)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -116, description = "领取工厂资源")]
    [ProtoContract]
    public class RecvFactoryResResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 cnt;
        [ProtoMember(5)]
        public Int32 facResCnt;
        [ProtoMember(6)]
        public Int64 nextTime;
        [ProtoMember(7)]
        public Int32 maxNumb;
        [ProtoMember(8)]
        public Int32 curNumb;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -115, description = "领取任务活跃点奖励")]
    [ProtoContract]
    public class QuestPointRewardResponse
    {
        [ProtoMember(3)]
        public Int32 rewardid;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -114, description = "物品数量改变的推送")]
    [ProtoContract]
    public class ResourceAmountChangedNotify
    {
        [ProtoMember(3)]
        public List<ResourceInfo> items;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -113, description = "任务接取")]
    [ProtoContract]
    public class QuestAccepted
    {
        [ProtoMember(3)]
        public QuestInfo questInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -112, description = "提交任务")]
    [ProtoContract]
    public class QuestSubmitResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(5)]
        public Int32 questPoint;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -111, description = "任务进度改变")]
    [ProtoContract]
    public class QuestProgressChanged
    {
        [ProtoMember(3)]
        public QuestInfo questInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -110, description = "任务进度加载")]
    [ProtoContract]
    public class QuestInfoResponse
    {
        [ProtoMember(3)]
        public List<QuestInfo> quests;
        [ProtoMember(4)]
        public Int32 questPoint;
        [ProtoMember(5)]
        public List<QuestPointRewardInfo> questPointRewards;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -109, description = "时间完成推送")]
    [ProtoContract]
    public class TimesUpNotify
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 lv;
        [ProtoMember(5)]
        public Int32 id;
        [ProtoMember(6)]
        public String unitid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -108, description = "分配工人返回")]
    [ProtoContract]
    public class AllotWorkerResponse
    {
        [ProtoMember(3)]
        public Int32 totalWorkers;
        [ProtoMember(4)]
        public Int32 idleWorkers;
        [ProtoMember(5)]
        public FactoryInfo factoryInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -107, description = "购买工人返回")]
    [ProtoContract]
    public class BuyWorkerResponse
    {
        [ProtoMember(3)]
        public Int32 totalWorkers;
        [ProtoMember(4)]
        public Int32 idleWorkers;
        [ProtoMember(5)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -106, description = "工厂升级加速返回")]
    [ProtoContract]
    public class BuildSpdUpResponse
    {
        [ProtoMember(3)]
        public Int32 itemId;
        [ProtoMember(4)]
        public Int32 itemCnt;
        [ProtoMember(5)]
        public Int32 diamond;
        [ProtoMember(6)]
        public FactoryInfo factoryInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -105, description = "取消建造返回")]
    [ProtoContract]
    public class CancelBuildResponse
    {
        [ProtoMember(3)]
        public FactoryInfo factoryInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -104, description = "升级工厂返回")]
    [ProtoContract]
    public class StartBuildResponse
    {
        [ProtoMember(3)]
        public Boolean immediately;
        [ProtoMember(4)]
        public FactoryInfo factoryInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -103, description = "后勤基地信息返回")]
    [ProtoContract]
    public class GetIndustryInfoResponse
    {
        [ProtoMember(3)]
        public Int32 totalWorkers;
        [ProtoMember(4)]
        public Int32 idleWorkers;
        [ProtoMember(5)]
        public List<FactoryInfo> factories;
        [ProtoMember(6)]
        public Int64 nextTime;
        [ProtoMember(7)]
        public Int32 maxNumb;
        [ProtoMember(8)]
        public Int32 curNumb;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -102, description = "引导完成返回")]
    [ProtoContract]
    public class GuideDoneResponse
    {
        [ProtoMember(3)]
        public Single gindex;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -101, description = "引导情况返回")]
    [ProtoContract]
    public class GuideInfoResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Single guide;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -100, description = "升级通知")]
    [ProtoContract]
    public class LevelupNotify
    {
        [ProtoMember(3)]
        public Int32 level;
        [ProtoMember(4)]
        public Int32 exp;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -99, description = "新邮件通知")]
    [ProtoContract]
    public class NewMailNotify
    {
        [ProtoMember(3)]
        public MailInfo mail;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -80, description = "查看物品使用后获得的随机道具和资源")]
    [ProtoContract]
    public class ItemRandomInfoResponse
    {
        [ProtoMember(3)]
        public List<Int32> itemIds;
        [ProtoMember(4)]
        public List<Int32> ress;
        [ProtoMember(5)]
        public List<Int32> ressCnt;
        [ProtoMember(6)]
        public Boolean all;
        [ProtoMember(7)]
        public List<Int32> itemCnt;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -77, description = "领取宝箱")]
    [ProtoContract]
    public class RecvResistBoxResponse
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public RewardInfo rewardInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -76, description = "重置波数")]
    [ProtoContract]
    public class ResistResetResponse
    {
        [ProtoMember(3)]
        public Int32 current;
        [ProtoMember(4)]
        public Int32 resetNumb;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -75, description = "公告推送")]
    [ProtoContract]
    public class NoticeNotify
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public List<NoticeArgInfo> Args;
        [ProtoMember(5)]
        public Int32 type;
        [ProtoMember(6)]
        public String content;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -74, description = "请求副本星星奖励信息返回")]
    [ProtoContract]
    public class FBGetStarRewardResponse
    {
        [ProtoMember(3)]
        public Int32 section;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(5)]
        public Int32 diamond;
        [ProtoMember(6)]
        public List<Int32> receiveds;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -73, description = "扫荡")]
    [ProtoContract]
    public class ResistSweepResponse
    {
        [ProtoMember(3)]
        public Int32 mode;
        [ProtoMember(4)]
        public Int32 current;
        [ProtoMember(5)]
        public Int32 token;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -72, description = "波战斗结果")]
    [ProtoContract]
    public class ResistFightResultResponse
    {
        [ProtoMember(3)]
        public Int32 wid;
        [ProtoMember(4)]
        public Boolean win;
        [ProtoMember(5)]
        public ResistWaveInfo wave;
        [ProtoMember(6)]
        public Int32 token;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -71, description = "开战的回复")]
    [ProtoContract]
    public class StartResistResponse
    {
        [ProtoMember(3)]
        public ResistWaveInfo wave;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -70, description = "抵抗前线的返回值")]
    [ProtoContract]
    public class ResistInfoResponse
    {
        [ProtoMember(3)]
        public Int32 best;
        [ProtoMember(4)]
        public Int32 current;
        [ProtoMember(5)]
        public Int32 resetNumb;
        [ProtoMember(6)]
        public List<Int32> recvBoxes;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -61, description = "获取聊天记录")]
    [ProtoContract]
    public class GetChatHistoryResponse
    {
        [ProtoMember(3)]
        public List<ChatHistory> histories;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -60, description = "聊天返回")]
    [ProtoContract]
    public class ChatResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public String text;
        [ProtoMember(5)]
        public String from;
        [ProtoMember(6)]
        public String icon;
        [ProtoMember(7)]
        public String nickyName;
        [ProtoMember(8)]
        public Int32 level;
        [ProtoMember(9)]
        public String partyName;
        [ProtoMember(10)]
        public Int32 camp;
        [ProtoMember(11)]
        public Int32 vip;
        [ProtoMember(12)]
        public Int64 time;
        [ProtoMember(13)]
        public Byte[] voice;
        [ProtoMember(14)]
        public Boolean targetOnline;
        [ProtoMember(15)]
        public Boolean isSystem;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -57, description = "取消收藏邮件")]
    [ProtoContract]
    public class CancelCollectResponse
    {
        [ProtoMember(3)]
        public String mid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -56, description = "收藏邮件")]
    [ProtoContract]
    public class CollectMailResponse
    {
        [ProtoMember(3)]
        public String mid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -55, description = "发送邮件返回")]
    [ProtoContract]
    public class SendMailResponse
    {
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -54, description = "返回删除邮件")]
    [ProtoContract]
    public class DeleteMailResponse
    {
        [ProtoMember(3)]
        public List<String> mids;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -53, description = "物品详情")]
    [ProtoContract]
    public class ItemInfoResponse
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public String name;
        [ProtoMember(5)]
        public Int32 type;
        [ProtoMember(6)]
        public Int32 quality;
        [ProtoMember(7)]
        public Int32 icon;
        [ProtoMember(8)]
        public Boolean useable;
        [ProtoMember(9)]
        public String desc;
        [ProtoMember(10)]
        public Int32 price;
        [ProtoMember(11)]
        public Int32 overlap;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -52, description = "领取附件")]
    [ProtoContract]
    public class TakeAttachmentResponse
    {
        [ProtoMember(3)]
        public List<String> mails;
        [ProtoMember(4)]
        public RewardInfo reward;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -51, description = "阅读邮件")]
    [ProtoContract]
    public class ReadMailResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Boolean readed;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -50, description = "邮件列表")]
    [ProtoContract]
    public class MailListResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public List<MailInfo> mails;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -48, description = "副本重置")]
    [ProtoContract]
    public class FBResetResponse
    {
        [ProtoMember(3)]
        public String fid;
        [ProtoMember(4)]
        public Int32 remainNumb;
        [ProtoMember(5)]
        public Int32 fight_times;
        [ProtoMember(6)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -47, description = "上传战斗结果获得奖励")]
    [ProtoContract]
    public class FBFightResultResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 star;
        [ProtoMember(5)]
        public RewardInfo reward;
        [ProtoMember(6)]
        public Boolean win;
        [ProtoMember(7)]
        public List<UnitInfo> units;
        [ProtoMember(8)]
        public Int32 exp;
        [ProtoMember(9)]
        public Int32 lv;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -46, description = "扫荡副本")]
    [ProtoContract]
    public class FBWipeResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 count;
        [ProtoMember(5)]
        public List<RewardInfo> rewards;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -45, description = "攻打副本")]
    [ProtoContract]
    public class FBFightResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public String token;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -44, description = "关卡的野怪列表")]
    [ProtoContract]
    public class FBMonsterInfoResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public List<MonsterInfo> monster;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -43, description = "副本")]
    [ProtoContract]
    public class FBInfoResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 section;
        [ProtoMember(5)]
        public Int32 type;
        [ProtoMember(6)]
        public List<FBInfo> fbs;
        [ProtoMember(7)]
        public List<Int32> receiveds;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -42, description = "章")]
    [ProtoContract]
    public class SectionInfoResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public List<SectionInfo> sections;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -40, description = "装备升阶")]
    [ProtoContract]
    public class UpGradeEquipResponse
    {
        [ProtoMember(3)]
        public Int32 unitId;
        [ProtoMember(4)]
        public Int32 position;
        [ProtoMember(5)]
        public EquipInfo equipInfo;
        [ProtoMember(6)]
        public UnitInfo unitInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -39, description = "升级装备")]
    [ProtoContract]
    public class LevelupEquipResponse
    {
        [ProtoMember(3)]
        public Int32 unitId;
        [ProtoMember(4)]
        public Int32 position;
        [ProtoMember(5)]
        public EquipInfo equipInfo;
        [ProtoMember(6)]
        public UnitInfo unitInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -37, description = "单位进阶")]
    [ProtoContract]
    public class ClazupUnitResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 gold;
        [ProtoMember(5)]
        public Int32 itemId;
        [ProtoMember(6)]
        public Int32 count;
        [ProtoMember(7)]
        public UnitInfo unitInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -35, description = "使用物品")]
    [ProtoContract]
    public class UseItemResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 lap;
        [ProtoMember(5)]
        public RewardInfo rewardInfo;
        [ProtoMember(6)]
        public UnitInfo unitInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -33, description = "出售物品")]
    [ProtoContract]
    public class SellItemResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 remain;
        [ProtoMember(5)]
        public Int32 gold;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -32, description = "背包")]
    [ProtoContract]
    public class PkgInfoResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<ItemInfo> items;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -31, description = "查看unit信息")]
    [ProtoContract]
    public class UnitInfoResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 level;
        [ProtoMember(5)]
        public Int32 claz;
        [ProtoMember(6)]
        public UnitInfo unit;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -30, description = "使用技能")]
    [ProtoContract]
    public class UseSkillResponse
    {
        [ProtoMember(3)]
        public Int32 sid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -29, description = "升级单位")]
    [ProtoContract]
    public class LevelupUnitResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 supply;
        [ProtoMember(5)]
        public Int32 iron;
        [ProtoMember(6)]
        public UnitInfo unitInfo;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -28, description = "携带技能")]
    [ProtoContract]
    public class CarrySkillResponse
    {
        [ProtoMember(3)]
        public Int32 sid;
        [ProtoMember(4)]
        public Boolean carry;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -27, description = "升级技能")]
    [ProtoContract]
    public class SkillLevelUpResponse
    {
        [ProtoMember(3)]
        public Int32 sid;
        [ProtoMember(4)]
        public Int32 lv;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -26, description = "技能列表")]
    [ProtoContract]
    public class SkillsInfoResponse
    {
        [ProtoMember(3)]
        public List<SkillInfo> skills;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -25, description = "设置阵容结果")]
    [ProtoContract]
    public class TeamSettingResponse
    {
        [ProtoMember(3)]
        public String tid;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -24, description = "阵容")]
    [ProtoContract]
    public class TeamResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<TeamInfo> teams5;
        [ProtoMember(5)]
        public List<TeamInfo> teams10;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -23, description = "资源采购详情")]
    [ProtoContract]
    public class ResPurchaseInfoResponse
    {
        [ProtoMember(3)]
        public List<BuyResInfo> buyResInfos;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -22, description = "购买资源")]
    [ProtoContract]
    public class BuyResResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 count;
        [ProtoMember(5)]
        public Int32 cost;
        [ProtoMember(6)]
        public Int32 costNext;
        [ProtoMember(7)]
        public Int32 timesRemain;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -21, description = "交换资源返回")]
    [ProtoContract]
    public class ExchangeResResponse
    {
        [ProtoMember(3)]
        public Int32 type;
        [ProtoMember(4)]
        public Int32 count;
        [ProtoMember(5)]
        public Int32 diamond;
        [ProtoMember(6)]
        public Int32 itemId;
        [ProtoMember(7)]
        public Int32 itemCnt;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -20, description = "设置当前默认阵容")]
    [ProtoContract]
    public class SetCurrentTeamResponse
    {
        [ProtoMember(3)]
        public String tid;
        [ProtoMember(4)]
        public Int32 type;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -18, description = "加速休整返回")]
    [ProtoContract]
    public class BuildUnitSpdUpResponse
    {
        [ProtoMember(3)]
        public String unitId;
        [ProtoMember(4)]
        public Int64 endTime;
        [ProtoMember(5)]
        public Int32 itemId;
        [ProtoMember(6)]
        public Int32 itemCnt;
        [ProtoMember(7)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -17, description = "休整结果")]
    [ProtoContract]
    public class BuildUnitResponse
    {
        [ProtoMember(3)]
        public String id;
        [ProtoMember(4)]
        public Int32 number;
        [ProtoMember(5)]
        public Int64 endTime;
        [ProtoMember(6)]
        public Int32 diamond;
        [ProtoMember(7)]
        public Int32 gold;
        [ProtoMember(8)]
        public Int32 supply;
        [ProtoMember(9)]
        public Int32 iron;
        [ProtoMember(10)]
        public Boolean cancel;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -16, description = "兵工厂详情")]
    [ProtoContract]
    public class FactoryResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<UnitInfo> units;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -15, description = "重命名返回")]
    [ProtoContract]
    public class RenameAndIconResponse
    {
        [ProtoMember(3)]
        public String nickyName;
        [ProtoMember(4)]
        public String icon;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -14, description = "查看兵营的返回")]
    [ProtoContract]
    public class UnitListResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public List<UnitInfo> units;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -13, description = "加速研发科技返回")]
    [ProtoContract]
    public class ScienceSpdUpResponse
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public Int64 devEndTime;
        [ProtoMember(5)]
        public Int32 itemId;
        [ProtoMember(6)]
        public Int32 itemCnt;
        [ProtoMember(7)]
        public Int32 diamond;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -12, description = "研发科技返回")]
    [ProtoContract]
    public class ScienceDevResponse
    {
        [ProtoMember(3)]
        public Int32 id;
        [ProtoMember(4)]
        public Int64 devEndTime;
        [ProtoMember(5)]
        public Int32 level;
        [ProtoMember(6)]
        public Int32 diamond;
        [ProtoMember(7)]
        public Int32 iron;
        [ProtoMember(8)]
        public Int32 gold;
        [ProtoMember(9)]
        public Int32 supply;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -11, description = "科技详情")]
    [ProtoContract]
    public class ScienceInfoResponse
    {
        [ProtoMember(3)]
        public List<ScienceInfo> sciences;
        [ProtoMember(4)]
        public List<Int32> devs;
        [ProtoMember(5)]
        public Int32 totalDevs;
        [ProtoMember(6)]
        public Int32 buyDevs;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -10, description = "随机名字")]
    [ProtoContract]
    public class RandomNickyNameResponse
    {
        [ProtoMember(3)]
        public Int32 sex;
        [ProtoMember(4)]
        public String nickyName;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -9, description = "资源详情")]
    [ProtoContract]
    public class ResResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(4)]
        public Int32 vip;
        [ProtoMember(5)]
        public Int32 level;
        [ProtoMember(6)]
        public String nickyName;
        [ProtoMember(7)]
        public String icon;
        [ProtoMember(8)]
        public Int32 renameCnt;
        [ProtoMember(9)]
        public List<ResInfo> resInfos;
        [ProtoMember(10)]
        public Int32 exp;
        [ProtoMember(11)]
        public Int32 nextExp;
        [ProtoMember(12)]
        public Int32 preExp;
        [ProtoMember(13)]
        public Int32 resistMaxWave;
        [ProtoMember(14)]
        public Int32 sid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -8, description = "创建角色的response")]
    [ProtoContract]
    public class CreatePlayerResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -7, description = "ping协议的返回")]
    [ProtoContract]
    public class Pong
    {
        [ProtoMember(3)]
        public Int64 time;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = -6, description = "登陆返回")]
    [ProtoContract]
    public class AuthResponse
    {
        [ProtoMember(3)]
        public String pid;
        [ProtoMember(1)]
        public Boolean success;
        [ProtoMember(2)]
        public String info;
    }
    [Proto(value = 6, description = "connector上的验证请求")]
    [ProtoContract]
    public class AuthRequest
    {
        [ProtoMember(1)]
        public String loginid;
        [ProtoMember(2)]
        public Int32 serverid;
        [ProtoMember(3)]
        public String Lang;
        [ProtoMember(4)]
        public String MAC;
        [ProtoMember(5)]
        public String IDFA;
        [ProtoMember(6)]
        public String GAID;
        [ProtoMember(7)]
        public String AndroidID;
        [ProtoMember(8)]
        public String UDID;
        [ProtoMember(9)]
        public String OpenUDID;
        [ProtoMember(10)]
        public String IMEI;
        [ProtoMember(11)]
        public String ver;
        [ProtoMember(12)]
        public String DeviceName;
        [ProtoMember(13)]
        public String OsVersion;
        [ProtoMember(14)]
        public String TelecomOper;
        [ProtoMember(15)]
        public String Network;
        [ProtoMember(16)]
        public Int32 ScreenWidth;
        [ProtoMember(17)]
        public Int32 ScreenHight;
        [ProtoMember(18)]
        public Int32 Memory;
        [ProtoMember(19)]
        public Int32 Type;
        [ProtoMember(20)]
        public String DID;
        [ProtoMember(21)]
        public Int32 iDIDRegTime;
        [ProtoMember(22)]
        public Int32 iUIDRegTime;
    }
    [Proto(value = 7, description = "ping协议，保活")]
    [ProtoContract]
    public class Ping
    {
        [ProtoMember(1)]
        public Int64 time;
    }
    [Proto(value = 8, description = "创建player")]
    [ProtoContract]
    public class CreatePlayerRequest
    {
        [ProtoMember(1)]
        public String loginid;
        [ProtoMember(2)]
        public String RegCountry;
        [ProtoMember(3)]
        public String DID;
        [ProtoMember(4)]
        public Int32 RegOS;
        [ProtoMember(5)]
        public String RegPackageName;
        [ProtoMember(6)]
        public String MAC;
        [ProtoMember(7)]
        public String IDFA;
        [ProtoMember(8)]
        public String GAID;
        [ProtoMember(9)]
        public String AndroidID;
        [ProtoMember(10)]
        public String UDID;
        [ProtoMember(11)]
        public String OpenUDID;
        [ProtoMember(12)]
        public String IMEI;
        [ProtoMember(13)]
        public String DeviceName;
        [ProtoMember(14)]
        public String OsVersion;
        [ProtoMember(15)]
        public String TelecomOper;
        [ProtoMember(16)]
        public String Network;
        [ProtoMember(17)]
        public Int32 ScreenWidth;
        [ProtoMember(18)]
        public Int32 ScreenHight;
        [ProtoMember(19)]
        public Int32 Memory;
        [ProtoMember(20)]
        public Int32 Type;
        [ProtoMember(21)]
        public String ver;
    }
    [Proto(value = 9, description = "资源查看")]
    [ProtoContract]
    public class ResRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 10, description = "随机名字")]
    [ProtoContract]
    public class RandomNickyNameRequest
    {
        [ProtoMember(1)]
        public Int32 sex;
    }
    [Proto(value = 11, description = "科技详情")]
    [ProtoContract]
    public class ScienceInfoRequest
    {
        [ProtoMember(1)]
        public Int32 id;
    }
    [Proto(value = 12, description = "研发科技")]
    [ProtoContract]
    public class ScienceDevRequest
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Boolean buy;
        [ProtoMember(3)]
        public Boolean cancel;
    }
    [Proto(value = 13, description = "加速研发")]
    [ProtoContract]
    public class ScienceSpdUpRequest
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 itemId;
        [ProtoMember(3)]
        public Int32 itemCnt;
    }
    [Proto(value = 14, description = "兵营查看")]
    [ProtoContract]
    public class UnitListRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 15, description = "重命名")]
    [ProtoContract]
    public class RenameAndIconRequest
    {
        [ProtoMember(1)]
        public String nickyName;
        [ProtoMember(2)]
        public String icon;
    }
    [Proto(value = 16, description = "兵工厂详细")]
    [ProtoContract]
    public class FactoryRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 17, description = "兵种休整")]
    [ProtoContract]
    public class BuildUnitRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Boolean immediately;
    }
    [Proto(value = 18, description = "休整加速")]
    [ProtoContract]
    public class BuildUnitSpdUpRequest
    {
        [ProtoMember(1)]
        public String unitId;
        [ProtoMember(2)]
        public Int32 itemId;
        [ProtoMember(3)]
        public Int32 itemCnt;
    }
    [Proto(value = 20, description = "选择当前阵容作为默认阵容")]
    [ProtoContract]
    public class SetCurrentTeamRequest
    {
        [ProtoMember(1)]
        public String tid;
        [ProtoMember(2)]
        public Int32 type;
    }
    [Proto(value = 21, description = "交换资源")]
    [ProtoContract]
    public class ExchangeResRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 itemId;
        [ProtoMember(3)]
        public Int32 itemCnt;
    }
    [Proto(value = 22, description = "购买资源")]
    [ProtoContract]
    public class BuyResRequest
    {
        [ProtoMember(1)]
        public Int32 type;
    }
    [Proto(value = 23, description = "资源采购详情")]
    [ProtoContract]
    public class ResPurchaseInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 24, description = "查看阵容")]
    [ProtoContract]
    public class TeamRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 25, description = "保存阵容配置")]
    [ProtoContract]
    public class TeamSettingRequest
    {
        [ProtoMember(1)]
        public TeamInfo team;
        [ProtoMember(2)]
        public Int32 type;
    }
    [Proto(value = 26, description = "技能列表")]
    [ProtoContract]
    public class SkillsInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 27, description = "升级技能")]
    [ProtoContract]
    public class SkillLevelUpRequest
    {
        [ProtoMember(1)]
        public Int32 sid;
    }
    [Proto(value = 28, description = "携带技能")]
    [ProtoContract]
    public class CarrySkillRequest
    {
        [ProtoMember(1)]
        public Int32 sid;
        [ProtoMember(2)]
        public Boolean carry;
    }
    [Proto(value = 29, description = "升级单位")]
    [ProtoContract]
    public class LevelupUnitRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Boolean adv;
    }
    [Proto(value = 30, description = "使用技能")]
    [ProtoContract]
    public class UseSkillRequest
    {
        [ProtoMember(1)]
        public Int32 sid;
    }
    [Proto(value = 31, description = "查看unit信息")]
    [ProtoContract]
    public class UnitInfoRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 level;
        [ProtoMember(3)]
        public Int32 claz;
    }
    [Proto(value = 32, description = "背包详情")]
    [ProtoContract]
    public class PkgInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 33, description = "出售物品")]
    [ProtoContract]
    public class SellItemRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 count;
    }
    [Proto(value = 35, description = "使用物品（有可能解锁兵种或随机包）")]
    [ProtoContract]
    public class UseItemRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 cnt;
    }
    [Proto(value = 37, description = "并总升阶")]
    [ProtoContract]
    public class ClazupUnitRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 39, description = "升级装备")]
    [ProtoContract]
    public class LevelupEquipRequest
    {
        [ProtoMember(1)]
        public Int32 unitId;
        [ProtoMember(2)]
        public Int32 position;
        [ProtoMember(3)]
        public Boolean multy;
    }
    [Proto(value = 40, description = "装备升阶")]
    [ProtoContract]
    public class UpGradeEquipRequest
    {
        [ProtoMember(1)]
        public Int32 unitId;
        [ProtoMember(2)]
        public Int32 position;
    }
    [Proto(value = 42, description = "章")]
    [ProtoContract]
    public class SectionInfoRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 43, description = "副本信息")]
    [ProtoContract]
    public class FBInfoRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 section;
        [ProtoMember(3)]
        public Int32 type;
    }
    [Proto(value = 44, description = "关卡的野怪表")]
    [ProtoContract]
    public class FBMonsterInfoRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 45, description = "攻打副本")]
    [ProtoContract]
    public class FBFightRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 46, description = "扫荡副本")]
    [ProtoContract]
    public class FBWipeRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 count;
    }
    [Proto(value = 47, description = "上传战斗结果")]
    [ProtoContract]
    public class FBFightResultRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public List<String> usedItems;
        [ProtoMember(3)]
        public List<FightUnitInfo> units;
        [ProtoMember(4)]
        public Boolean win;
        [ProtoMember(5)]
        public String token;
    }
    [Proto(value = 48, description = "副本信息")]
    [ProtoContract]
    public class FBResetRequest
    {
        [ProtoMember(1)]
        public String fid;
    }
    [Proto(value = 50, description = "邮件列表")]
    [ProtoContract]
    public class MailListRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 page;
    }
    [Proto(value = 51, description = "阅读邮件")]
    [ProtoContract]
    public class ReadMailRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 52, description = "领附件")]
    [ProtoContract]
    public class TakeAttachmentRequest
    {
        [ProtoMember(1)]
        public Boolean allTake;
        [ProtoMember(2)]
        public String id;
    }
    [Proto(value = 53, description = "查看物品配置详情")]
    [ProtoContract]
    public class ItemInfoRequest
    {
        [ProtoMember(1)]
        public Int32 id;
    }
    [Proto(value = 54, description = "删除邮件请求")]
    [ProtoContract]
    public class DeleteMailRequest
    {
        [ProtoMember(1)]
        public List<String> mids;
    }
    [Proto(value = 55, description = "发送邮件请求")]
    [ProtoContract]
    public class SendMailRequest
    {
        [ProtoMember(1)]
        public String recvName;
        [ProtoMember(2)]
        public String content;
        [ProtoMember(3)]
        public String title;
    }
    [Proto(value = 56, description = "收藏邮件")]
    [ProtoContract]
    public class CollectMailRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 57, description = "取消收藏邮件")]
    [ProtoContract]
    public class CancelCollectRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 60, description = "聊天请求")]
    [ProtoContract]
    public class ChatRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public String to;
        [ProtoMember(3)]
        public String text;
        [ProtoMember(4)]
        public Byte[] voice;
    }
    [Proto(value = 61, description = "获取聊天记录")]
    [ProtoContract]
    public class GetChatHistoryRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 70, description = "抵抗前线详情")]
    [ProtoContract]
    public class ResistInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 71, description = "开战")]
    [ProtoContract]
    public class StartResistRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 72, description = "铁壁战波战斗结果上报")]
    [ProtoContract]
    public class ResistFightResultRequest
    {
        [ProtoMember(1)]
        public Int32 wid;
        [ProtoMember(2)]
        public List<String> usedItems;
        [ProtoMember(3)]
        public Boolean win;
    }
    [Proto(value = 73, description = "扫荡")]
    [ProtoContract]
    public class ResistSweepRequest
    {
        [ProtoMember(1)]
        public Int32 mode;
    }
    [Proto(value = 74, description = "请求副本星星奖励信息")]
    [ProtoContract]
    public class FBGetStarRewardRequest
    {
        [ProtoMember(1)]
        public Int32 section;
        [ProtoMember(2)]
        public Int32 type;
        [ProtoMember(3)]
        public Int32 reward;
    }
    [Proto(value = 76, description = "重置波数")]
    [ProtoContract]
    public class ResistResetRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 77, description = "领取宝箱")]
    [ProtoContract]
    public class RecvResistBoxRequest
    {
        [ProtoMember(1)]
        public Int32 id;
    }
    [Proto(value = 80, description = "查看物品使用后获得的随机道具")]
    [ProtoContract]
    public class ItemRandomInfoRequest
    {
        [ProtoMember(1)]
        public Int32 id;
    }
    [Proto(value = 81, description = "引导日志")]
    [ProtoContract]
    public class LogGuideRequest
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public String gname;
        [ProtoMember(3)]
        public String vDeviceName;
        [ProtoMember(4)]
        public String vOsVersion;
        [ProtoMember(5)]
        public String vTelecomOper;
        [ProtoMember(6)]
        public String vNetwork;
        [ProtoMember(7)]
        public Int32 iScreenWidth;
        [ProtoMember(8)]
        public Int32 iScreenHight;
        [ProtoMember(9)]
        public Int32 iMemory;
        [ProtoMember(10)]
        public String vMAC;
        [ProtoMember(11)]
        public String vIDFA;
        [ProtoMember(12)]
        public String vGAID;
        [ProtoMember(13)]
        public String vAndroidID;
        [ProtoMember(14)]
        public String vUDID;
        [ProtoMember(15)]
        public String vOpenUDID;
        [ProtoMember(16)]
        public String vIMEI;
    }
    [Proto(value = 101, description = "引导情况")]
    [ProtoContract]
    public class GuideInfoRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 102, description = "引导上报")]
    [ProtoContract]
    public class GuideDoneRequest
    {
        [ProtoMember(1)]
        public Single gindex;
    }
    [Proto(value = 103, description = "请求后勤基地信息")]
    [ProtoContract]
    public class GetIndustryInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 104, description = "升级工厂")]
    [ProtoContract]
    public class StartBuildRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Boolean immediately;
    }
    [Proto(value = 105, description = "取消升级建造")]
    [ProtoContract]
    public class CancelBuildRequest
    {
        [ProtoMember(1)]
        public Int32 type;
    }
    [Proto(value = 106, description = "工厂升级加速")]
    [ProtoContract]
    public class BuildSpdUpRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 itemId;
        [ProtoMember(3)]
        public Int32 itemCnt;
    }
    [Proto(value = 107, description = "购买工人")]
    [ProtoContract]
    public class BuyWorkerRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 108, description = "分配工人")]
    [ProtoContract]
    public class AllotWorkerRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 workerCnt;
    }
    [Proto(value = 109, description = "请求更新")]
    [ProtoContract]
    public class RefreshTimerRequest
    {
        [ProtoMember(1)]
        public Int32 type;
    }
    [Proto(value = 110, description = "查询任务信息")]
    [ProtoContract]
    public class QuestInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 112, description = "提交任务")]
    [ProtoContract]
    public class QuestSubmitRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Int32 questType;
    }
    [Proto(value = 115, description = "领取任务活跃点奖励")]
    [ProtoContract]
    public class QuestPointRewardRequest
    {
        [ProtoMember(1)]
        public Int32 rewardid;
    }
    [Proto(value = 116, description = "领取工厂资源")]
    [ProtoContract]
    public class RecvFactoryResRequest
    {
        [ProtoMember(1)]
        public Int32 type;
    }
    [Proto(value = 117, description = "重置工人")]
    [ProtoContract]
    public class ResetWorkerRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 120, description = "发起匹配")]
    [ProtoContract]
    public class MatchRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 difficult;
    }
    [Proto(value = 121, description = "取消匹配")]
    [ProtoContract]
    public class MatchCancelRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 123, description = "战斗开始确定")]
    [ProtoContract]
    public class MatchBattleConfirmRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 125, description = "（战斗服）读条")]
    [ProtoContract]
    public class MatchBattleLoadingRequest
    {
        [ProtoMember(1)]
        public Int32 progress;
    }
    [Proto(value = 126, description = "（战斗服）战斗信息")]
    [ProtoContract]
    public class BattleActionRequest
    {
        [ProtoMember(1)]
        public ArmyOperate armyOperate;
        [ProtoMember(2)]
        public String pid;
    }
    [Proto(value = 130, description = "商城详情")]
    [ProtoContract]
    public class MallInfoRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 131, description = "购买物品")]
    [ProtoContract]
    public class BuyItemRequest
    {
        [ProtoMember(1)]
        public Int32 id;
        [ProtoMember(2)]
        public Int32 type;
    }
    [Proto(value = 132, description = "请求解锁兵种")]
    [ProtoContract]
    public class UnlockUnitRequest
    {
        [ProtoMember(1)]
        public Int32 unitId;
    }
    [Proto(value = 136, description = "购买宝箱")]
    [ProtoContract]
    public class BuyBoxRequest
    {
        [ProtoMember(1)]
        public Int32 id;
    }
    [Proto(value = 137, description = "请求刷新商店")]
    [ProtoContract]
    public class MallShopRefreshRequest
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public Int32 type;
    }
    [Proto(value = 141, description = "请求购买夺旗战挑战次数")]
    [ProtoContract]
    public class BuyGrabFlagChallengeTimesRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 142, description = "请求夺旗战的对手列表")]
    [ProtoContract]
    public class GrabFlagAdversariesRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 143, description = "夺旗战斗结束")]
    [ProtoContract]
    public class GrabFlagBattleChallengeOverRequest
    {
        [ProtoMember(1)]
        public String battleId;
        [ProtoMember(2)]
        public List<String> usedItems;
        [ProtoMember(3)]
        public Boolean win;
        [ProtoMember(4)]
        public List<FightUnitInfo> units;
    }
    [Proto(value = 144, description = "请求挑战")]
    [ProtoContract]
    public class GrabFlagBattleChallengeRequest
    {
        [ProtoMember(1)]
        public String adversaryPid;
    }
    [Proto(value = 145, description = "请求夺旗战对战记录")]
    [ProtoContract]
    public class GrabFlagBattleHistoryRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 146, description = "积分奖励请求")]
    [ProtoContract]
    public class GrabFlagScoreRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 148, description = "请求领取夺旗积分奖励")]
    [ProtoContract]
    public class ReceiveGrabFlagScoreRewardRequest
    {
        [ProtoMember(1)]
        public Int32 rewardId;
    }
    [Proto(value = 149, description = "夺旗排名奖励")]
    [ProtoContract]
    public class GrabFlagRankRewardRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 150, description = "查看阵容信息")]
    [ProtoContract]
    public class GetTeamInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 151, description = "请求排行榜")]
    [ProtoContract]
    public class GetRankingListRequest
    {
        [ProtoMember(1)]
        public Int32 type;
    }
    [Proto(value = 152, description = "查看玩家信息")]
    [ProtoContract]
    public class ShowPlayerRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 153, description = "竞技场时间重置")]
    [ProtoContract]
    public class FlagCDResetRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 200, description = "作弊")]
    [ProtoContract]
    public class CheatRequest
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public String action;
    }
    [Proto(value = 220, description = "获取玩法信息")]
    [ProtoContract]
    public class GetPatternInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 221, description = "获取雪地营救过的好友")]
    [ProtoContract]
    public class GetRescueFriendsRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 222, description = "开始雪地营救")]
    [ProtoContract]
    public class StartRescueRequest
    {
        [ProtoMember(1)]
        public String friendId;
        [ProtoMember(2)]
        public Int32 difficulty;
    }
    [Proto(value = 223, description = "结束雪地营救")]
    [ProtoContract]
    public class EndRescueRequest
    {
        [ProtoMember(1)]
        public String battleId;
        [ProtoMember(2)]
        public Boolean win;
        [ProtoMember(3)]
        public List<String> usedSkills;
        [ProtoMember(4)]
        public List<FightUnitInfo> units;
    }
    [Proto(value = 224, description = "购买雪地营救次数")]
    [ProtoContract]
    public class BuyRescueRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 225, description = "扫荡雪地营救")]
    [ProtoContract]
    public class SweepRescueRequest
    {
        [ProtoMember(1)]
        public Int32 difficulty;
    }
    [Proto(value = 251, description = "回收兵种")]
    [ProtoContract]
    public class ReclaimUnitRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Boolean sure;
    }
    [Proto(value = 300, description = "好友列表")]
    [ProtoContract]
    public class FriendListRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 301, description = "收取好友赠送的原油")]
    [ProtoContract]
    public class GetOilFromFriendRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Boolean all;
    }
    [Proto(value = 302, description = "赠送好友原油")]
    [ProtoContract]
    public class GiveOilToFriendRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Boolean all;
    }
    [Proto(value = 303, description = "推荐好友列表")]
    [ProtoContract]
    public class RecommendFriendListRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 304, description = "添加好友")]
    [ProtoContract]
    public class AddFriendRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 305, description = "好友申请列表")]
    [ProtoContract]
    public class FriendAddListRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 306, description = "处理好友申请")]
    [ProtoContract]
    public class ProcessFriendAddRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Boolean pass;
    }
    [Proto(value = 307, description = "删除好友")]
    [ProtoContract]
    public class DelFriendRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 312, description = "一键添加好友")]
    [ProtoContract]
    public class ProcessAllFriendAddRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 330, description = "请求当前主线")]
    [ProtoContract]
    public class MainlineRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 333, description = "提交主线任务")]
    [ProtoContract]
    public class MainlineSubmitRequest
    {
        [ProtoMember(1)]
        public Int32 id;
    }
    [Proto(value = 350, description = "建党")]
    [ProtoContract]
    public class CreatePartyRequest
    {
        [ProtoMember(1)]
        public String name;
        [ProtoMember(2)]
        public String shortName;
        [ProtoMember(3)]
        public String icon;
        [ProtoMember(4)]
        public String note;
        [ProtoMember(5)]
        public Boolean check;
    }
    [Proto(value = 351, description = "申请入党")]
    [ProtoContract]
    public class ApplyPartyRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public String name;
    }
    [Proto(value = 352, description = "党列表")]
    [ProtoContract]
    public class PartyListRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 353, description = "党员列表")]
    [ProtoContract]
    public class MemberListRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 354, description = "入党申请列表")]
    [ProtoContract]
    public class ApplyListRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 355, description = "处理入党申请")]
    [ProtoContract]
    public class ProcessApplyRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public Boolean pass;
    }
    [Proto(value = 356, description = "人事调整")]
    [ProtoContract]
    public class PersonnelRequest
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public Int32 action;
    }
    [Proto(value = 357, description = "党费")]
    [ProtoContract]
    public class PartyContriRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 358, description = "交党费")]
    [ProtoContract]
    public class PayPartyRequest
    {
        [ProtoMember(1)]
        public Int32 contri;
    }
    [Proto(value = 359, description = "党详情")]
    [ProtoContract]
    public class PartyDetailRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 360, description = "退党")]
    [ProtoContract]
    public class LeavePartyRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 361, description = "留言板")]
    [ProtoContract]
    public class PartyBBSRequest
    {
        [ProtoMember(1)]
        public String party;
    }
    [Proto(value = 362, description = "发言")]
    [ProtoContract]
    public class TalkOnBBSRequest
    {
        [ProtoMember(1)]
        public String message;
    }
    [Proto(value = 363, description = "修改党信息")]
    [ProtoContract]
    public class ModifyPartyRequest
    {
        [ProtoMember(1)]
        public String party;
        [ProtoMember(2)]
        public String name;
        [ProtoMember(3)]
        public String icon;
        [ProtoMember(4)]
        public String note;
    }
    [Proto(value = 364, description = "解散")]
    [ProtoContract]
    public class DestroyPartyRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 365, description = "科技列表")]
    [ProtoContract]
    public class PartyScienceListRequest
    {
        [ProtoMember(1)]
        public String party;
    }
    [Proto(value = 366, description = "群发邮件")]
    [ProtoContract]
    public class MassMailRequest
    {
        [ProtoMember(1)]
        public String id;
        [ProtoMember(2)]
        public String content;
        [ProtoMember(3)]
        public String title;
    }
    [Proto(value = 367, description = "审核调整")]
    [ProtoContract]
    public class ChangeCheckRequest
    {
        [ProtoMember(1)]
        public Boolean check;
    }
    [Proto(value = 400, description = "请求获取vip信息")]
    [ProtoContract]
    public class VIPInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 401, description = "请求领取vip礼包")]
    [ProtoContract]
    public class GetVIPGiftRequest
    {
        [ProtoMember(1)]
        public Int32 vip;
    }
    [Proto(value = 500, description = "（战斗服）进入洗旗范围")]
    [ProtoContract]
    public class C2BEnterFlagArea
    {
        [ProtoMember(1)]
        public String uid;
        [ProtoMember(2)]
        public String goId;
        [ProtoMember(3)]
        public Int32 flagId;
    }
    [Proto(value = 501, description = "（战斗服）离开洗旗范围")]
    [ProtoContract]
    public class C2BExitFlagArea
    {
        [ProtoMember(1)]
        public String goId;
        [ProtoMember(2)]
        public Int32 flagId;
    }
    [Proto(value = 502, description = "（战斗服）造成伤害")]
    [ProtoContract]
    public class C2BDamage
    {
        [ProtoMember(1)]
        public Int32 skillId;
        [ProtoMember(2)]
        public String attackGoId;
        [ProtoMember(3)]
        public Int32 hurtType;
        [ProtoMember(4)]
        public String hurtGoId;
        [ProtoMember(5)]
        public Int32 damage;
        [ProtoMember(6)]
        public Int32 index;
        [ProtoMember(7)]
        public Boolean isBaoji;
    }
    [Proto(value = 503, description = "（战斗服）请求同步分数")]
    [ProtoContract]
    public class C2BGetSocre
    {
        [ProtoMember(1)]
        public String nothing;
    }
    [Proto(value = 504, description = "（战斗服）请求造兵")]
    [ProtoContract]
    public class C2BCreateArmy
    {
        [ProtoMember(1)]
        public String uid;
        [ProtoMember(2)]
        public Int32 bornPlace;
    }
    [Proto(value = 505, description = "（战斗服）请求使用技能")]
    [ProtoContract]
    public class C2BUseSkill
    {
        [ProtoMember(1)]
        public String uid;
        [ProtoMember(2)]
        public Int32 skillId;
        [ProtoMember(3)]
        public V3 position;
    }
    [Proto(value = 506, description = "（战斗服）请求全部数据")]
    [ProtoContract]
    public class C2BGetBattleFieldData
    {
        [ProtoMember(1)]
        public List<String> hadUnitinfos;
    }
    [Proto(value = 507, description = "（战斗服）PING")]
    [ProtoContract]
    public class C2BPing
    {
        [ProtoMember(1)]
        public Int64 sendTime;
    }
    [Proto(value = 508, description = "（战斗服）验证")]
    [ProtoContract]
    public class C2BAuth
    {
        [ProtoMember(1)]
        public String token;
    }
    [Proto(value = 509, description = "上传全战场信息")]
    [ProtoContract]
    public class C2BPushAllBattleData
    {
        [ProtoMember(1)]
        public String key;
        [ProtoMember(2)]
        public List<PVPPlayerInfo> playerInfos;
        [ProtoMember(3)]
        public List<PVPFlag> flags;
        [ProtoMember(4)]
        public List<BattleMonsterInfo> monsters;
    }
    [Proto(value = 511, description = "（战斗服）查询战斗状态，战斗是否开启")]
    [ProtoContract]
    public class BattleStateRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 599, description = "移动坐标")]
    [ProtoContract]
    public class MovePositionUpload
    {
        [ProtoMember(1)]
        public String name;
        [ProtoMember(2)]
        public V3 position;
    }
    [Proto(value = 600, description = "获取天梯信息")]
    [ProtoContract]
    public class GetLadderInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 602, description = "获取天梯战斗记录")]
    [ProtoContract]
    public class GetLadderHistoryRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 620, description = "获取玩家的运输玩法数据")]
    [ProtoContract]
    public class GetTransportInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 621, description = "请求开始运输玩法")]
    [ProtoContract]
    public class StartTransportRequest
    {
        [ProtoMember(1)]
        public Int32 difficultDegree;
    }
    [Proto(value = 622, description = "结束运输玩法")]
    [ProtoContract]
    public class EndTransportRequest
    {
        [ProtoMember(1)]
        public String battleToken;
        [ProtoMember(2)]
        public List<String> usedSkills;
        [ProtoMember(3)]
        public List<Int32> remainTruckHP;
        [ProtoMember(4)]
        public List<FightUnitInfo> units;
        [ProtoMember(5)]
        public Boolean win;
    }
    [Proto(value = 623, description = "购买运输副本挑战次数")]
    [ProtoContract]
    public class BuyTransportTimesRequest
    {
        [ProtoMember(1)]
        public String nothing;
    }
    [Proto(value = 624, description = "购买科研序列")]
    [ProtoContract]
    public class BuyScienceNumbRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 625, description = "扫荡运输玩法")]
    [ProtoContract]
    public class SweepTransportRequest
    {
        [ProtoMember(1)]
        public Int32 difficultDegree;
    }
    [Proto(value = 651, description = "（战斗服）抢滩保卫战，购买造兵点")]
    [ProtoContract]
    public class MultiDefenceBuyCreatePointRequest
    {
        [ProtoMember(1)]
        public Int32 buyPoint;
    }
    [Proto(value = 653, description = "查询抢滩战信息")]
    [ProtoContract]
    public class GetMultiDefenceInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 654, description = "激活兵种")]
    [ProtoContract]
    public class MultiDefenceActivateUnitRequest
    {
        [ProtoMember(1)]
        public Int32 unitId;
    }
    [Proto(value = 656, description = "（战斗服）抢滩保卫战，准备完毕")]
    [ProtoContract]
    public class MultiDefenceReadyRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 700, description = "查询活动类型列表")]
    [ProtoContract]
    public class ActivityListRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 701, description = "请求活动数据")]
    [ProtoContract]
    public class ActivityInfoRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 tag;
    }
    [Proto(value = 702, description = "领取活动奖励")]
    [ProtoContract]
    public class ReceiveActivityRewardRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 tag;
        [ProtoMember(3)]
        public Int32 id;
    }
    [Proto(value = 703, description = "购买成长套餐")]
    [ProtoContract]
    public class ActivityBuyCZRequest
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public Int32 tag;
    }
    [Proto(value = 704, description = "请求全部活动数据")]
    [ProtoContract]
    public class ActivityAllInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 705, description = "请求限时活动礼包")]
    [ProtoContract]
    public class LimitGiftRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 706, description = "购买限时活动礼包")]
    [ProtoContract]
    public class BuyGiftRequest
    {
        [ProtoMember(1)]
        public String product_id;
    }
    [Proto(value = 710, description = "请求充值信息")]
    [ProtoContract]
    public class RechargeInfoRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 711, description = "在线奖励信息")]
    [ProtoContract]
    public class GetOnlineRewardInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 712, description = "领取在线奖励")]
    [ProtoContract]
    public class RecvOnlineRewardRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 713, description = "七日福利信息")]
    [ProtoContract]
    public class QiRiInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 714, description = "领取七日福利")]
    [ProtoContract]
    public class ReceiveWalfareRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 id;
    }
    [Proto(value = 715, description = "领取目标福利")]
    [ProtoContract]
    public class ReceiveAimRewardRequest
    {
        [ProtoMember(1)]
        public Int32 id;
    }
    [Proto(value = 800, description = "（公会战内）请求公会战战场信息")]
    [ProtoContract]
    public class GVGMapRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 802, description = "（游戏）请求公会战的举办情况")]
    [ProtoContract]
    public class GVGInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 803, description = "报名参加公会战")]
    [ProtoContract]
    public class GVGEnrollRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 804, description = "（公会战）出战")]
    [ProtoContract]
    public class GVGFightRequest
    {
        [ProtoMember(1)]
        public String destPositionId;
        [ProtoMember(2)]
        public Boolean speedUp;
    }
    [Proto(value = 805, description = "（公会战）驻军")]
    [ProtoContract]
    public class GVGGarrisonRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 806, description = "（公会战）捐献")]
    [ProtoContract]
    public class GVGDonateRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Boolean useDiamond;
    }
    [Proto(value = 807, description = "（公会战）加速行军")]
    [ProtoContract]
    public class GVGSpeedUpRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 811, description = "（公会战）设置出征阵容")]
    [ProtoContract]
    public class GVGSetTeamRequest
    {
        [ProtoMember(1)]
        public String uid;
    }
    [Proto(value = 812, description = "公会战登录")]
    [ProtoContract]
    public class GVGLoginRequest
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public String token;
    }
    [Proto(value = 813, description = "请求该点关联的部队")]
    [ProtoContract]
    public class QueryArmiesByPointRequest
    {
        [ProtoMember(1)]
        public String pointId;
    }
    [Proto(value = 814, description = "（公会战内）请求公会详情")]
    [ProtoContract]
    public class GuildDetailRequest
    {
        [ProtoMember(1)]
        public String gid;
    }
    [Proto(value = 815, description = "查看地图上部队的详细信息")]
    [ProtoContract]
    public class ArmyDetailRequest
    {
        [ProtoMember(1)]
        public String id;
    }
    [Proto(value = 816, description = "查看自己的详细信息")]
    [ProtoContract]
    public class PlayerDetailRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 817, description = "发送公会私信")]
    [ProtoContract]
    public class SendGuildMessageRequest
    {
        [ProtoMember(1)]
        public String gid;
        [ProtoMember(2)]
        public String msg;
    }
    [Proto(value = 819, description = "请求查收所有公会私信")]
    [ProtoContract]
    public class GuildMessageRequest
    {
        [ProtoMember(1)]
        public String gid;
    }
    [Proto(value = 820, description = "查看资源点详情")]
    [ProtoContract]
    public class ResPointRequest
    {
        [ProtoMember(1)]
        public String pointId;
    }
    [Proto(value = 821, description = "查看我的公会的详细记录")]
    [ProtoContract]
    public class GetGuildDetailInfoRequest
    {
        [ProtoMember(1)]
        public String gid;
    }
    [Proto(value = 822, description = "查看公会战斗记录")]
    [ProtoContract]
    public class GVGBattleHistoriesRequest
    {
        [ProtoMember(1)]
        public String gid;
    }
    [Proto(value = 823, description = "查看公会战斗记录详情")]
    [ProtoContract]
    public class GVGBattleHistoyFullInfoRequest
    {
        [ProtoMember(1)]
        public String battleId;
    }
    [Proto(value = 824, description = "查看军团成员列表")]
    [ProtoContract]
    public class GVGGuildMembersRequest
    {
        [ProtoMember(1)]
        public String gid;
    }
    [Proto(value = 825, description = "兵种休整")]
    [ProtoContract]
    public class GVGRestRequest
    {
        [ProtoMember(1)]
        public String unitId;
    }
    [Proto(value = 826, description = "查看军团建筑")]
    [ProtoContract]
    public class GuildBuildingInfoRequest
    {
        [ProtoMember(1)]
        public String gid;
    }
    [Proto(value = 828, description = "军队召回")]
    [ProtoContract]
    public class ArmyBackRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 829, description = "查看军团排行榜")]
    [ProtoContract]
    public class GuildRankRequest
    {
        [ProtoMember(1)]
        public String nothing;
    }
    [Proto(value = 830, description = "维修主城")]
    [ProtoContract]
    public class GuildCityFixRequest
    {
        [ProtoMember(1)]
        public Boolean useDiamond;
    }
    [Proto(value = 831, description = "兵种休整立即完成")]
    [ProtoContract]
    public class GVGRestFinishRequest
    {
        [ProtoMember(1)]
        public String unitId;
    }
    [Proto(value = 901, description = "请求充值信息")]
    [ProtoContract]
    public class RebateInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 905, description = "获取抽奖相关信息")]
    [ProtoContract]
    public class GetLotteryInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 906, description = "抽奖")]
    [ProtoContract]
    public class LotteryRequest
    {
        [ProtoMember(1)]
        public Int32 mode;
        [ProtoMember(2)]
        public Int32 method;
    }
    [Proto(value = 910, description = "请求周常信息")]
    [ProtoContract]
    public class GetWeekInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 911, description = "挑战周常关卡")]
    [ProtoContract]
    public class WeekBattleStartRequest
    {
        [ProtoMember(1)]
        public String pid;
        [ProtoMember(2)]
        public Int32 diff;
    }
    [Proto(value = 912, description = "挑战周常关卡")]
    [ProtoContract]
    public class WeekBattleEndRequest
    {
        [ProtoMember(1)]
        public List<String> usedItems;
        [ProtoMember(2)]
        public List<FightUnitInfo> units;
        [ProtoMember(3)]
        public Boolean win;
        [ProtoMember(4)]
        public String token;
        [ProtoMember(5)]
        public Int32 diff;
    }
    [Proto(value = 913, description = "领取周常宝箱")]
    [ProtoContract]
    public class RecvWeekBoxRequest
    {
        [ProtoMember(1)]
        public Int32 id;
    }
    [Proto(value = 1001, description = "清档")]
    [ProtoContract]
    public class ClearPlayerRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 1002, description = "绑定账号完成")]
    [ProtoContract]
    public class BindPlayerRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 1101, description = "请求公告信息")]
    [ProtoContract]
    public class BulletinRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 1202, description = "请求所有充值活动信息")]
    [ProtoContract]
    public class RechargeAllRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 1203, description = "领取奖励")]
    [ProtoContract]
    public class ReceiveRewardRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 tag;
        [ProtoMember(3)]
        public Int32 id;
    }
    [Proto(value = 1301, description = "请求大厅信息")]
    [ProtoContract]
    public class HallInfoRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 diff;
    }
    [Proto(value = 1302, description = "开房间")]
    [ProtoContract]
    public class CreateRoomRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 diff;
    }
    [Proto(value = 1303, description = "设置密码")]
    [ProtoContract]
    public class SetRoomPasswordRequest
    {
        [ProtoMember(1)]
        public String password;
    }
    [Proto(value = 1304, description = "请求进入房间")]
    [ProtoContract]
    public class EnterRoomRequest
    {
        [ProtoMember(1)]
        public String roomId;
        [ProtoMember(2)]
        public String password;
    }
    [Proto(value = 1305, description = "离开房间")]
    [ProtoContract]
    public class ExitRoomRequest
    {
        [ProtoMember(1)]
        public String roomId;
    }
    [Proto(value = 1306, description = "踢出成员")]
    [ProtoContract]
    public class KickOutRoomRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 1307, description = "更换房主")]
    [ProtoContract]
    public class ChangeRoomOwnerRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 1308, description = "邀请成员")]
    [ProtoContract]
    public class InviteMemberRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 1310, description = "答复邀请")]
    [ProtoContract]
    public class ReplyInvitationRequest
    {
        [ProtoMember(1)]
        public String roomId;
        [ProtoMember(2)]
        public Int32 op;
    }
    [Proto(value = 1311, description = "请求推荐列表")]
    [ProtoContract]
    public class RecommendationListRequest
    {
        [ProtoMember(1)]
        public Int32 type;
    }
    [Proto(value = 1313, description = "开始战斗")]
    [ProtoContract]
    public class MultiPlayerBattleRequest
    {
        [ProtoMember(1)]
        public String nothing;
    }
    [Proto(value = 1314, description = "快速进入房间")]
    [ProtoContract]
    public class QuickEnterRoomRequest
    {
        [ProtoMember(1)]
        public Int32 type;
        [ProtoMember(2)]
        public Int32 diff;
    }
    [Proto(value = 1315, description = "检查我的开房信息")]
    [ProtoContract]
    public class CheckMyRoomInfoRequest
    {
        [ProtoMember(1)]
        public String pid;
    }
    [Proto(value = 5000, description = "进入匹配")]
    [ProtoContract]
    public class S2SMatchRequest
    {
        [ProtoMember(1)]
        public MatchBattlePlayerInfo info;
        [ProtoMember(2)]
        public Int32 type;
        [ProtoMember(3)]
        public Int32 diff;
    }
    [Proto(value = 5001, description = "添加战斗服务器")]
    [ProtoContract]
    public class S2SAddBattleServer
    {
        [ProtoMember(1)]
        public S2SBattleServerInfo battleServerInfo;
    }
    [Proto(value = 5002, description = "移除战斗服务器")]
    [ProtoContract]
    public class S2SRemoveBattleServer
    {
        [ProtoMember(1)]
        public String address;
    }
    [Proto(value = 5003, description = "显示战斗服务器")]
    [ProtoContract]
    public class S2SShowBattleServersRequest
    {
        [ProtoMember(1)]
        public Int32 nothing;
    }
    [Proto(value = 5004, description = "显示战斗服务器返回")]
    [ProtoContract]
    public class S2SShowBattleServersResponse
    {
        [ProtoMember(1)]
        public List<S2SBattleServerInfo> servers;
    }
    [Proto(value = 5005, description = "开启战场")]
    [ProtoContract]
    public class S2SEnterBattle
    {
        [ProtoMember(1)]
        public List<S2SBattlePlayerInfo> players;
        [ProtoMember(2)]
        public Int32 type;
        [ProtoMember(3)]
        public Int32 diff;
    }
    [Proto(value = 5006, description = "离开战场")]
    [ProtoContract]
    public class S2SExitBattle
    {
        [ProtoMember(1)]
        public List<MatchBattleResultInfo> resultInfos;
        [ProtoMember(2)]
        public Int32 type;
        [ProtoMember(3)]
        public Int32 diff;
        [ProtoMember(4)]
        public Int64 battleOverTime;
        [ProtoMember(5)]
        public Int64 battleUsedTime;
        [ProtoMember(6)]
        public String toPid;
        [ProtoMember(7)]
        public Int32 reason;
    }
    [Proto(value = 5007, description = "开启战场返回")]
    [ProtoContract]
    public class S2SEnterBattleOkResponse
    {
        [ProtoMember(1)]
        public List<String> pids;
        [ProtoMember(2)]
        public String ip;
        [ProtoMember(3)]
        public Int32 port;
    }
}
