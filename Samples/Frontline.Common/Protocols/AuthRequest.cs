using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// connector上的验证请求 协议:6
    /// </summary>
	[Proto(value=6,description="connector上的验证请求")]
	[ProtoContract]
	public class AuthRequest
	{
        /// <summary>
        ///  用户中心的加密id
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string loginid;
        /// <summary>
        ///  登陆的服务器id
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public int serverid;
        /// <summary>
        ///  (必填)设备语言或者玩家选择的游戏语言
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string Lang;
        /// <summary>
        ///  玩家登录时设备MAC地址
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string MAC;
        /// <summary>
        ///  登录时苹果IDFA
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string IDFA;
        /// <summary>
        ///  登录时设备的谷歌id 默认 null 字符串
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string GAID;
        /// <summary>
        ///  登录时设备安卓id
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string AndroidID;
        /// <summary>
        ///  登录时设备udid
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string UDID;
        /// <summary>
        ///  登录时设备OpenUDID
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string OpenUDID;
        /// <summary>
        ///  登录时设备IMEI
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public string IMEI;
        /// <summary>
        ///  登录时客户端游戏版本号
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public string ver;
        /// <summary>
        ///  (可选)移动终端机型, 如 iphone6 iphone6s mi4 等
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public string DeviceName;
        /// <summary>
        ///  (可选)移动终端操作系统版本
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public string OsVersion;
        /// <summary>
        ///  (必填)运营商
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public string TelecomOper;
        /// <summary>
        ///  (可选)3G/WIFI/2G/4G
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public string Network;
        /// <summary>
        ///  (可选)显示屏宽度
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int ScreenWidth;
        /// <summary>
        ///  (可选)显示屏高度
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int ScreenHight;
        /// <summary>
        ///  (可选)内存信息单位M
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public int Memory;
        /// <summary>
        ///  (必填)登录类型(1/设备 2/账号 3/角色)
        /// </summary>
		[ProtoMember(19, IsRequired = false)]
		public int Type;
        /// <summary>
        ///  DID
        /// </summary>
		[ProtoMember(20, IsRequired = false)]
		public string DID;
        /// <summary>
        ///  DID注册时间，登录服登录后获取
        /// </summary>
		[ProtoMember(21, IsRequired = false)]
		public int iDIDRegTime;
        /// <summary>
        ///  UID注册时间，登录服登录后获取
        /// </summary>
		[ProtoMember(22, IsRequired = false)]
		public int iUIDRegTime;

	}
}