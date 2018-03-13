using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class LadderBattleInfo
	{
        /// <summary>
        ///  我方是否胜利
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  敌方pid
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string enemyPid;
        /// <summary>
        ///  敌方icon
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string enemyIcon;
        /// <summary>
        ///  敌方name
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string enemyName;
        /// <summary>
        ///  enemyVIP
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int enemyVIP;
        /// <summary>
        ///  enemyLevel
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int enemyLevel;
        /// <summary>
        ///  敌方服务器名
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string enemySerName;
        /// <summary>
        ///  敌方赛前积分
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int enemyLadderScoreBefore;
        /// <summary>
        ///  敌方赛前军衔
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int enemyMilitaryRankBefore;
        /// <summary>
        ///  敌方赛后积分
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int enemyLadderScoreAfter;
        /// <summary>
        ///  敌方赛后军衔
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int enemyMilitaryRankAfter;
        /// <summary>
        ///  myVIP
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int myVIP;
        /// <summary>
        ///  myLevel
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int myLevel;
        /// <summary>
        ///  我方服务器名
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public string mySerName;
        /// <summary>
        ///  我方赛后积分
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public int myLadderScoreAfter;
        /// <summary>
        ///  我方赛后军衔
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int myMilitaryRankAfter;
        /// <summary>
        ///  我方赛前积分
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int myLadderScoreBefore;
        /// <summary>
        ///  我方赛前军衔
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public int myMilitaryRankBefore;
        /// <summary>
        ///  战斗结束时间
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public long battleOverTime;
        /// <summary>
        ///  战斗经历时间
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public long battleUsedTime;

	}
}