using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 创建player 协议:8
    /// </summary>
	[Proto(value=8,description="创建player")]
	[ProtoContract]
	public class CreatePlayerRequest
	{
        /// <summary>
        ///  loginid
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string loginid;
        /// <summary>
        ///  (必填)注册的国家 两位的国家代码参看http://doc.chacuo.net/iso-3166-1
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string RegCountry;
        /// <summary>
        ///  (必填)玩家注册时设备号 Quick提供接口得到
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string DID;
        /// <summary>
        ///  (必填)注册时手机系统 0 ios 1 Android
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int RegOS;
        /// <summary>
        ///  (必填)注册时包名
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string RegPackageName;
        /// <summary>
        ///  玩家注册时设备MAC地址
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string MAC;
        /// <summary>
        ///  注册时苹果IDFA
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string IDFA;
        /// <summary>
        ///  注册时设备的谷歌id 默认 null 字符串
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string GAID;
        /// <summary>
        ///  注册时设备安卓id
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string AndroidID;
        /// <summary>
        ///  注册时设备udid
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public string UDID;
        /// <summary>
        ///  注册时设备OpenUDID
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public string OpenUDID;
        /// <summary>
        ///  注册时设备IMEI
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public string IMEI;
        /// <summary>
        ///  (可选)移动终端机型, 如 iphone6 iphone6s mi4 等
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public string DeviceName;
        /// <summary>
        ///  (可选)移动终端操作系统版本
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public string OsVersion;
        /// <summary>
        ///  (必填)运营商
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public string TelecomOper;
        /// <summary>
        ///  (可选)3G/WIFI/2G/4G
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public string Network;
        /// <summary>
        ///  (可选)显示屏宽度
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int ScreenWidth;
        /// <summary>
        ///  (可选)显示屏高度
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public int ScreenHight;
        /// <summary>
        ///  (可选)内存信息单位M
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public int Memory;
        /// <summary>
        ///  (必填)注册类型(1/设备 2/账号 3/角色)
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public int Type;
        /// <summary>
        ///  登录时客户端游戏版本号
        /// </summary>
		[ProtoMember(21, IsRequired = false)]
		public string ver;

	}
}