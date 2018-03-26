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

        public List<Friendship> Friends { get; set; }
        public List<FriendApplication> FriendApplications { get; set; }
    }

    /// <summary>
    /// 好友信息
    /// </summary>
    public class Friendship
    {
        public string Id { get; set; }

        public string FriendListId { get; set; }

        public string PlayerId { get; set; }
        public DateTime FromTime { get; set; }
        public bool IsSendOil { get; set; }
        public bool IsRecvOil { get; set; }
    }

    /// <summary>
    /// 好友申请信息
    /// </summary>
    public class FriendApplication
    {
        public string Id { get; set; }

        public string FriendListId { get; set; }

        public string PlayerId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
