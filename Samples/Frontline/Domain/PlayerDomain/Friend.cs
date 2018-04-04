using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class FriendList
    {
        [Key]
        public string PlayerId { get; set; }
        
        public int RecvTimes { get; set; }
        public DateTime LastRefreshTime { get; set; }

        public List<Friendship> Friends { get; set; } = new List<Friendship>();
        public List<FriendApplication> FriendApplications { get; set; } = new List<FriendApplication>();
    }

    /// <summary>
    /// 好友信息
    /// </summary>
    public class Friendship
    {
        public string FriendListId { get; set; }
        [MaxLength(64)]
        public string PlayerId { get; set; }
        public DateTime FromTime { get; set; }
        public bool CanSendOil { get; set; }
        public bool CanRecvOil { get; set; }
    }

    /// <summary>
    /// 好友申请信息
    /// </summary>
    public class FriendApplication
    {
        public string FriendListId { get; set; }
        [MaxLength(64)]
        public string PlayerId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
