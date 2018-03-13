using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class SectionInfo
	{
        /// <summary>
        ///  章id（策划id）
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  章类型（1普通2精英）
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;
        /// <summary>
        ///  名称
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string name;
        /// <summary>
        ///  是否已经打开（如果本章所有关卡已经打通或者当前可以进攻此章任何一个副本，则为true）
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool open;

	}
}