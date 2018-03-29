using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class FacTask
    {
        [Key]
        public string Id { get; set; }

        public string PlayerId { get; set; }

        public int Tid { get; set; }
        public int Type { get; set; }

        /// <summary>
        /// 0 未派遣, 1已派遣, 2已完成
        /// </summary>
        public FacTaskState State { get; set; }
        public DateTime EndTime { get; set; }
        [MaxLength(512)]
        public string FacWorkers { get; set; } = string.Empty;
        public bool IsWorkersReleased { get; set; }
    }

    public enum FacTaskState
    {
        Waiting = 0,
        Doing = 1,
        Finish = 2,
    }
}
