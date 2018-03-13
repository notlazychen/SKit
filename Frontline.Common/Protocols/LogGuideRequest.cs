using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 引导日志 协议:81
    /// </summary>
	[Proto(value=81,description="引导日志")]
	[ProtoContract]
	public class LogGuideRequest
	{
        /// <summary>
        ///  引导步骤id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  引导步骤名称
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string gname;
        /// <summary>
        ///  移动终端机型, 如 iphone6 iphone6s mi4 等
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string vDeviceName;
        /// <summary>
        ///  移动终端操作系统版本
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string vOsVersion;
        /// <summary>
        ///  运营商
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string vTelecomOper;
        /// <summary>
        ///  3G/WIFI/2G/4G
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string vNetwork;
        /// <summary>
        ///  显示屏宽度
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int iScreenWidth;
        /// <summary>
        ///  显示屏高度
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int iScreenHight;
        /// <summary>
        ///  内存信息单位M
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int iMemory;
        /// <summary>
        ///  当前设备MAC地址
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public string vMAC;
        /// <summary>
        ///  当前苹果IDFA
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public string vIDFA;
        /// <summary>
        ///  当前设备的谷歌id
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public string vGAID;
        /// <summary>
        ///  当前设备安卓id
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public string vAndroidID;
        /// <summary>
        ///  当前设备udid
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public string vUDID;
        /// <summary>
        ///  当前设备OpenUDID
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public string vOpenUDID;
        /// <summary>
        ///  当前设备IMEI
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public string vIMEI;

	}
}