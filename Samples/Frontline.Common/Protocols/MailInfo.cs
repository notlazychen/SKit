using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MailInfo
	{
        /// <summary>
        ///  id（数据库id）
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  发信人
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string from;
        /// <summary>
        ///  标题
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string title;
        /// <summary>
        ///  头像
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  内容
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string content;
        /// <summary>
        ///  发信时间
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public long time;
        /// <summary>
        ///  军团名
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string partyName;
        /// <summary>
        ///  附件
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public RewardInfo attachment;
        /// <summary>
        ///  是否已经阅读过
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public bool readed;
        /// <summary>
        ///  是否已经收藏过
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public bool collected;
        /// <summary>
        ///  是否军团邮件
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public bool isPartyMail;
        /// <summary>
        ///  邮件类型，1系统邮件，2竞技场每日排名，3军团战赛季结束，4禁言，0普通邮件
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int mailType;
        /// <summary>
        ///  邮件内容参数
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public List<string> mailArgs;

	}
}