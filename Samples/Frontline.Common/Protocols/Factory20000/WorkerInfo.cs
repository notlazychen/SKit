using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class WorkerInfo
    {
        [ProtoMember(1, IsRequired = false)]
        public String Id;
        [ProtoMember(2, IsRequired = false)]
        public int Tid;
        /// <summary>
        /// 工人状态 0休息中,1派遣中, 2未雇佣
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
        public int State;
    }
}