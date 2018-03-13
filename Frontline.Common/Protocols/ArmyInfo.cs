using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ArmyInfo
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  军团id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string gid;
        /// <summary>
        ///  名字
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string name;
        /// <summary>
        ///  当前位置百分比
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public float position;
        /// <summary>
        ///  出发时间
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public long startTime;
        /// <summary>
        ///  到达时间
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public long arriveTime;
        /// <summary>
        ///  起点
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string origin;
        /// <summary>
        ///  目的地
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string target;
        /// <summary>
        ///  状态1出发，2战斗中，3返回中
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int state;
        /// <summary>
        ///  是否加速行军
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public bool speedUp;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int fightPoint;

	}
}