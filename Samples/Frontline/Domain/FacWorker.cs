using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class FacWorker
    {
        [Key]
        public string Id { get; set; }

        public string PlayerId { get; set; }

        public int Tid { get; set; }

        /// <summary>
        /// 工人状态 0休息中,1派遣中, 2未雇佣
        /// </summary>
        public FacWorkerState State { get; set; }

        public string FacTaskId { get; set; }
    }

    public enum FacWorkerState
    {
        Idle = 0,
        Working,
        Free,
    }
}
