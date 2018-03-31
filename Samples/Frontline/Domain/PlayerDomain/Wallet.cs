using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Wallet
    {
        [Key]
        public string PlayerId { get; set; }

        public int SUPPLY { get; private set; }//军需
        public int IRON { get; private set; }//钢铁
        public int DIAMOND { get; private set; }//钻石
        public int GOLD { get; private set; }//黄金
        public int OIL { get; private set; }//原油
        public int WIPES { get; private set; }//扫荡点数
        public int HORN { get; private set; }//聊天小喇叭
        public int TOKEN { get; private set; }//令牌
        public int TEC { get; private set; }//科技点数
        public int SMOKE { get; private set; }//香烟
        public int LEGIONCOIN { get; private set; }//军团币

        public int OilBuyTimes { get; set; }
        public int GoldBuyTimes { get; set; }

        public int AddCurrency(int type, int value)
        {
            switch (type)
            {
                case 1: return SUPPLY += value;
                case 2: return IRON += value;
                case 3: return DIAMOND += value;
                case 4: return GOLD += value;
                case 5: return OIL += value;
                case 6: return WIPES += value;
                case 8: return HORN += value;
                case 9: return TOKEN += value;
                case 10: return TEC += value;
                case 11: return SMOKE += value;
                case 12: return LEGIONCOIN += value;
            }
            return 0;
        }

        public int GetCurrency(int type)
        {
            switch (type)
            {
                case 1: return SUPPLY;
                case 2: return IRON;
                case 3: return DIAMOND;
                case 4: return GOLD;
                case 5: return OIL;
                case 6: return WIPES;
                case 8: return HORN;
                case 9: return TOKEN;
                case 10: return TEC;
                case 11: return SMOKE;
                case 12: return LEGIONCOIN;
            }
            return 0;
        }
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
