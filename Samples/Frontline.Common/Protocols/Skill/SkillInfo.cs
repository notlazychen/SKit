using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    [ProtoContract]
    public class SkillInfo
    {
        /// <summary>
        /// 技能id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
        public int sid;
        /// <summary>
        ///  技能等级
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
        public int lv;
    }
}