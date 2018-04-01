using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Newtonsoft.Json.Linq;
using protocol;
using SKit;
using SKit.Common;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class BuyResCommand : GameCommand<BuyResRequest>
    {
        PlayerModule _playerModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            BuyResResponse response = new BuyResResponse();
            Player player = _playerModule.QueryPlayer(Session.PlayerId);
            BuyRes(player, response, Request.type);
            Session.SendAsync(response);
            return 0;
        }

        private void BuyRes(Player player, BuyResResponse response, int type)
        {
            int maxTimes = GameConfig.MaxBuyResNumb; 
            int boughtTimes = 0;
            switch (type)
            {
                case CurrencyType.GOLD:
                    boughtTimes = player.Wallet.TodayBuyGold;
                    break;
                case CurrencyType.OIL:
                    boughtTimes = player.Wallet.TodayBuyOil;
                    break;
                case CurrencyType.SUPPLY:
                    boughtTimes = player.Wallet.TodayBuySupply;
                    break;
                case CurrencyType.IRON:
                    boughtTimes = player.Wallet.TodayBuyOil;
                    break;
                default:
                    return;
            }
            if (maxTimes > boughtTimes)
            {
                int costTimesIndex = boughtTimes < _playerModule.DResPrices.Count ?
                    boughtTimes + 1 : _playerModule.DResPrices.Count;

                int nextCostIndex = boughtTimes + 1 < _playerModule.DResPrices.Count ?
                    boughtTimes + 2 : _playerModule.DResPrices.Count;
                 int nextCost = 0;
                int cost = 0;
                int recv = 0;
                switch (type)
                {
                    case CurrencyType.GOLD:
                        cost = _playerModule.DResPrices[costTimesIndex].gold_cost;
                        recv = _playerModule.DResPrices[costTimesIndex].gold;
                        nextCost = _playerModule.DResPrices[nextCostIndex].gold_cost;
                        break;
                    case CurrencyType.OIL:
                        cost = _playerModule.DResPrices[costTimesIndex].oil_cost;
                        recv = _playerModule.DResPrices[costTimesIndex].oil;
                        nextCost = _playerModule.DResPrices[nextCostIndex].oil_cost;
                        break;
                    case CurrencyType.SUPPLY:
                        cost = _playerModule.DResPrices[costTimesIndex].supply_cost;
                        recv = _playerModule.DResPrices[costTimesIndex].supply;
                        nextCost = _playerModule.DResPrices[nextCostIndex].supply_cost;
                        break;
                    case CurrencyType.IRON:
                        cost = _playerModule.DResPrices[costTimesIndex].iron_cost;
                        recv = _playerModule.DResPrices[costTimesIndex].iron;
                        nextCost = _playerModule.DResPrices[nextCostIndex].iron_cost;
                        break;
                }
                if (player.Wallet.DIAMOND >= cost)//可以购买
                {
                    _playerModule.AddCurrencies(
                        player,
                        new[] { CurrencyType.DIAMOND, type },
                        new[] { -cost, recv },
                        "钻石购买资源");
                    //加购买次数
                    boughtTimes++;
                    switch (type)
                    {
                        case CurrencyType.GOLD:
                            player.Wallet.TodayBuyGold = boughtTimes;
                            break;
                        case CurrencyType.OIL:
                            player.Wallet.TodayBuyOil = boughtTimes;
                            break;
                        case CurrencyType.SUPPLY:
                            player.Wallet.TodayBuySupply = boughtTimes;
                            break;
                        case CurrencyType.IRON:
                            player.Wallet.TodayBuyOil = boughtTimes;
                            break;
                    }
                    response.success = true;
                    response.cost = cost;
                    response.count = recv;
                    response.type = type;
                    response.timesRemain = maxTimes - boughtTimes;
                    response.costNext = nextCost;
                }
                else
                {
                    response.info = GameErrorCode.资源不足.ToString();
                }
            }
            else
            {
                response.info = GameErrorCode.资源不足.ToString();
            }
        }
    }
}
