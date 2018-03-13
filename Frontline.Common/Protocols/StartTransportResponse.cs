using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 进入运输副本 协议:-621
    /// </summary>
	[Proto(value=-621,description="进入运输副本")]
	[ProtoContract]
	public class StartTransportResponse
	{
        /// <summary>
        ///  野怪列表
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<MonsterWaveInfo> monsters;
        /// <summary>
        ///  货车集合
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<MonsterInfo> trucks;
        /// <summary>
        ///  护送总量
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int resNumber;
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string battleToken;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}