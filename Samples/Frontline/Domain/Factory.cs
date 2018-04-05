using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Factory
    {
        [Key]
        public string PlayerId { get; set; }

        /// <summary>
        /// 已雇佣工人数量
        /// </summary>
        public int HireWorkerNumb { get; set; }

        public DateTime LastRefreshDay { get; set; }
        public int TodayMarketRefreshTimes { get; set; }

        public List<FacTask> FacTasks { get; set; } = new List<FacTask>();
        public List<FacWorker> FacWorkers { get; set; } = new List<FacWorker>();
    }
}
