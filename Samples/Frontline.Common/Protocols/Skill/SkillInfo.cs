using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    [ProtoContract]
    public class SkillInfo
    {
        /// <summary>
        ///  （策划）技能id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
        public int sid;
        /// <summary>
        ///  技能等级
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
        public int lv;
        /// <summary>
        ///  是否携带
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
        public bool carry;

    }
}