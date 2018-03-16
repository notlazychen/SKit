using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class PlayerCurrency
    {
        public string PlayerId { get; set; }

        public int Type { get; set; }
        public int Value { get; set; }
    }

    public static class CurrencyType
    {
        public const int SUPPLY = 1;//军需
        public const int IRON = 2;//钢铁
        public const int DIAMOND = 3;//钻石
        public const int GOLD = 4;//黄金
        public const int OIL = 5;//原油
        public const int WIPES = 6;//扫荡点数
        public const int HORN = 8;//聊天小喇叭
        public const int TOKEN = 9;//令牌
        public const int TEC = 10;//科技点数
        public const int SMOKE = 11;//香烟
        public const int LEGIONCOIN = 12;//军团币

        public const int MAX_TYPE = 12;
    }
}
