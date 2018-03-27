using Frontline.Data;
using Frontline.GameDesign;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using SKit.Common.Utils;
using Frontline.Common;

namespace Frontline.GameControllers
{
    public class LotteryController : GameController
    {
        private GameDesignContext _designDb;
        private DataContext _db;

        public Dictionary<int, DLottery> DLotteries { get; private set; }
        public Dictionary<int, DLotteryGroup> DLotteryGroups { get; private set; }
        public Dictionary<int, List<DLotteryRand>> DLotteryRands { get; private set; }



        public LotteryController(DataContext db, GameDesignContext design)
        {
            _db = db;
            _designDb = design;
        }

        protected override void OnReadGameDesignTables()
        {
            DLotteries = _designDb.DLotteries.AsNoTracking().ToDictionary(x => x.id, x => x);
            DLotteryGroups = _designDb.DLotteryGroups.AsNoTracking().ToDictionary(x => x.id, x => x);
            DLotteryRands = _designDb.DLotteryRands.AsNoTracking().GroupBy(x => x.group).ToDictionary(x => x.Key, x => x.ToList());
        }

        protected override void OnRegisterEvents()
        {
            var playerController = this.Server.GetController<PlayerController>();
            playerController.PlayerCreating += PlayerController_PlayerCreating;
            playerController.PlayerLoading += PlayerController_PlayerLoading;
            playerController.PlayerLoaded += PlayerController_PlayerLoaded;
            playerController.PlayerEverydayRefresh += PlayerController_PlayerEverydayRefresh;
        }

        private void PlayerController_PlayerLoaded(object sender, Player e)
        {
            if(e.Lottery == null)
            {
                var dl1 = DLotteries[1];
                var dl2 = DLotteries[2];
                var now = DateTime.Now;
                e.Lottery = new Lottery()
                {
                    PlayerId = e.Id,
                    GoldUsedNumb = 0,//今日金币抽次数  
                    GoldFreeNextTime = now,//下次免费金币抽刷新时间
                    GoldBaseNumb = GameConfig.lottery_base_cnt,//剩余出金币抽保底奖励的次数
                    GoldLastTime = now,//最后一次金币抽时间
                    GoldFreeNumb = dl1.free_cnt,
                    DmdUsedNumb = 0,//今日钻石抽次数   
                    DmdFreeNextTime = now,//下次免费钻石抽时间
                    DmdBaseNumb = GameConfig.lottery_base_cnt,//剩余出钻石保底奖励的次数
                    DmdLastTime = now,//最后一次钻石抽时间
                    DmdFreeNumb = dl2.free_cnt,
                };
            }
        }

        private void PlayerController_PlayerCreating(object sender, Player e)
        {
            var dl1 = DLotteries[1];
            var dl2 = DLotteries[2];
            var now = DateTime.Now;
            e.Lottery = new Lottery()
            {
                PlayerId = e.Id,
                GoldUsedNumb = 0,//今日金币抽次数  
                GoldFreeNextTime = now,//下次免费金币抽刷新时间
                GoldBaseNumb = GameConfig.lottery_base_cnt,//剩余出金币抽保底奖励的次数
                GoldLastTime = now,//最后一次金币抽时间
                GoldFreeNumb = dl1.free_cnt,
                DmdUsedNumb = 0,//今日钻石抽次数   
                DmdFreeNextTime = now,//下次免费钻石抽时间
                DmdBaseNumb = GameConfig.lottery_base_cnt,//剩余出钻石保底奖励的次数
                DmdLastTime = now,//最后一次钻石抽时间
                DmdFreeNumb = dl2.free_cnt,
            };
        }

        private void PlayerController_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader.Include(x => x.Lottery);
        }

        private void PlayerController_PlayerEverydayRefresh(object sender, Player e)
        {
            var dl1 = DLotteries[1];
            var dl2 = DLotteries[2];
            var lottery = e.Lottery;
            lottery.DmdFreeNumb = dl2.free_cnt;
            lottery.GoldFreeNumb = dl1.free_cnt;
        }
        #region 事件
        #endregion

        #region 辅助方法
        private DLotteryRand Rand(int lotteryId, int lv)
        {
            DLotteryGroup group = DLotteryGroups[lotteryId];

            int index = MathUtil.RandomIndex(group.group_w.Object);
            int groupId = group.group.Object[index];
            var rands = DLotteryRands[groupId].Where(r => r.lv_min <= lv && r.lv_max >= lv).ToList();
            var rand = MathUtil.RandomElement(rands, e => e.w);
            return rand;
        }

        #endregion

        #region 客户端接口
        public int Call_LotteryInfo(GetLotteryInfoRequest request)
        {
            GetLotteryInfoResponse response = new GetLotteryInfoResponse();
            var player = CurrentSession.GetBindPlayer();
            var lottery = player.Lottery;
            response.success = true;
            response.goldUsedNumb = lottery.GoldUsedNumb;//今日金币抽次数  
            response.goldFreeNextTime = lottery.GoldFreeNextTime.ToUnixTime();//下次免费金币抽刷新时间
            response.goldBaseNumb = lottery.GoldBaseNumb;//剩余出金币抽保底奖励的次数
            response.goldFreeNumb = lottery.GoldFreeNumb;
            response.diamondUsedNumb = lottery.DmdUsedNumb;//今日钻石抽次数   
            response.diamondFreeNextTime = lottery.DmdFreeNextTime.ToUnixTime();//下次免费钻石抽时间
            response.diamondBaseNumb = lottery.DmdBaseNumb;//剩余出钻石保底奖励的次数
            response.diamondFreeNumb = lottery.DmdFreeNumb;
            CurrentSession.SendAsync(response);
            return 0;
        }

        public int Call_LotteryDraw(LotteryRequest request)
        {
            LotteryResponse response = new LotteryResponse();
            var p = this.CurrentSession.GetBindPlayer();
            Lottery l = p.Lottery;
            DateTime now = DateTime.Now;

            int method = response.method = request.method;
            int mode = response.mode = request.mode;
            response.rewardInfo = new RewardInfo()
            {
                items = new List<RewardItem>(),
                units = new List<UnitInfo>(),
                res = new List<ResInfo>()
            };
            PlayerController playerController = Server.GetController<PlayerController>();
            PkgController pkgController = Server.GetController<PkgController>();
            //先判断是否免费
            if (method == 1)
            {
                //单抽
                if (mode == 1)
                {
                    //金币单抽
                    DLottery dl = DLotteries[1];
                    if (now >= l.GoldFreeNextTime)
                    {
                        DLotteryRand rand = null;
                        if (l.GoldBaseNumb <= 1)
                        {
                            rand = this.Rand(dl.rand_sp, p.Level);
                            l.GoldBaseNumb = GameConfig.lottery_base_cnt;
                        }
                        else
                        {
                            rand = this.Rand(dl.rand, p.Level);
                            l.GoldBaseNumb -= 1;
                        }
                        response.success = true;
                        response.rewardInfo.items.Add(new RewardItem()
                        {
                            id = rand.item_id,
                            count = rand.item_cnt,
                        });
                        //todo: 滚屏广播

                        l.GoldUsedNumb += 1;
                        l.GoldFreeNumb -= 1;
                        if (l.GoldFreeNumb > 0)
                        {
                            l.GoldFreeNextTime = now.AddMinutes(dl.free_cd);//下次免费金币抽刷新时间
                        }
                        else
                        {
                            l.GoldFreeNextTime = DateTime.Today.AddDays(1);
                        }

                    }
                    else
                    {
                        bool canChou = false;
                        //扣道具
                        string reason = "金币单抽";
                        if (pkgController.TrySubItem(p, dl.cost_item, 1, reason, out var item))
                        {
                            canChou = true;
                        }
                        else
                        {
                            //扣钱
                            if (playerController.IsCurrencyEnough(p, CurrencyType.GOLD, dl.cost_res_cnt))
                            {
                                canChou = true;
                                playerController.AddCurrency(p, CurrencyType.GOLD, -dl.cost_res_cnt, reason);
                            }
                        }
                        if (canChou)
                        {
                            DLotteryRand rand = null;
                            if (l.GoldBaseNumb <= 1)
                            {
                                rand = this.Rand(dl.rand_sp, p.Level);
                                l.GoldBaseNumb = GameConfig.lottery_base_cnt;
                            }
                            else
                            {
                                rand = this.Rand(dl.rand, p.Level);
                                l.GoldBaseNumb -= 1;
                            }
                            response.success = true;
                            response.rewardInfo.items.Add(new RewardItem()
                            {
                                id = rand.item_id,
                                count = rand.item_cnt
                            });

                            l.GoldUsedNumb += 1;

                            //todo: 滚屏广播
                        }
                    }
                }
                else//钻石单抽奖
                {
                    DLottery dl = DLotteries[2];
                    if (now >= l.DmdFreeNextTime)
                    {
                        DLotteryRand rand = null;
                        if (l.DmdBaseNumb <= 1)
                        {
                            rand = this.Rand(dl.rand_sp, p.Level);
                            l.DmdBaseNumb = GameConfig.lottery_base_cnt;
                        }
                        else
                        {
                            rand = this.Rand(dl.rand, p.Level);
                            l.DmdBaseNumb -= 1;
                        }
                        if (l.DmdUsedNumb == 0)
                        {
                            rand = new DLotteryRand();
                            rand.item_id = GameConfig.lottery_first_item_id;
                            rand.item_cnt = GameConfig.lottery_first_item_cnt;
                        }
                        response.success = true;

                        response.rewardInfo.items.Add(new RewardItem()
                        {
                            id = rand.item_id,
                            count = rand.item_cnt
                        });

                        //todo: 滚屏广播
                        l.DmdUsedNumb += 1;
                        l.DmdFreeNumb -= 1;
                        l.DmdFreeNextTime = now.AddMinutes(dl.free_cd);//下次免费金币抽刷新时间

                    }
                    else
                    {
                        bool canChou = false;
                        //扣道具
                        string reason = "钻石单抽";
                        if (pkgController.TrySubItem(p, dl.cost_item, 1, reason, out var item))
                        {
                            canChou = true;
                        }
                        else
                        {
                            //扣钱
                            if (playerController.IsCurrencyEnough(p, CurrencyType.DIAMOND, dl.cost_res_cnt))
                            {
                                canChou = true;
                                playerController.AddCurrency(p, CurrencyType.DIAMOND, -dl.cost_res_cnt, reason);
                            }
                        }
                        if (canChou)
                        {

                            DLotteryRand rand = null;
                            if (l.DmdBaseNumb <= 1)
                            {
                                rand = this.Rand(dl.rand_sp, p.Level);
                                l.DmdBaseNumb = GameConfig.lottery_base_cnt;
                            }
                            else
                            {
                                rand = this.Rand(dl.rand, p.Level);
                                l.DmdBaseNumb -= 1;
                            }
                            response.success = true;
                            response.rewardInfo.items.Add(new RewardItem()
                            {
                                id = rand.item_id,
                                count = rand.item_cnt
                            });
                            //todo: 滚屏广播
                            l.DmdUsedNumb += 1;
                        }
                    }
                }
            }
            else
            {
                //十连抽
                if (mode == 1)
                {//金币抽
                    string reason = "金币十连抽";
                    DLottery dl = DLotteries[1];
                    int cost = (int)(dl.cost_res_cnt * 10d * dl.ten_discount / 100d);
                    if (playerController.IsCurrencyEnough(p, CurrencyType.GOLD, cost))
                    {
                        playerController.AddCurrency(p, CurrencyType.GOLD, -cost, reason);

                        for (int i = 0; i < 10; i++)
                        {
                            DLotteryRand rand = null;
                            if (l.GoldBaseNumb <= 1)
                            {
                                rand = this.Rand(dl.rand_sp, p.Level);
                                l.GoldBaseNumb = GameConfig.lottery_base_cnt;
                            }
                            else
                            {
                                rand = this.Rand(dl.rand, p.Level);
                                l.GoldBaseNumb -= 1;
                            }

                            response.rewardInfo.items.Add(new RewardItem()
                            {
                                id = rand.item_id,
                                count = rand.item_cnt
                            });
                        }
                        //todo: 滚屏广播


                        response.success = true;
                        l.Gold10UsedNumb += 1;
                    }
                }
                else
                {//钻石抽
                    string reason = "钻石十连抽";
                    DLottery dl = DLotteries[2];
                    int cost = (int)(dl.cost_res_cnt * 10d * dl.ten_discount / 100d);
                    if (playerController.IsCurrencyEnough(p, CurrencyType.DIAMOND, cost))
                    {
                        playerController.AddCurrency(p, CurrencyType.DIAMOND, -cost, reason);

                        for (int i = 0; i < 10; i++)
                        {
                            DLotteryRand rand = null;
                            if (l.DmdBaseNumb <= 1)
                            {
                                if (l.Dmd10UsedNumb == 0)
                                {
                                    rand = this.Rand(dl.rand_first10, p.Level);
                                }
                                else
                                {
                                    rand = this.Rand(dl.rand_sp, p.Level);
                                }
                                l.DmdBaseNumb = GameConfig.lottery_base_cnt;
                            }
                            else
                            {
                                rand = this.Rand(dl.rand, p.Level);
                                l.DmdBaseNumb -= 1;
                            }

                            response.rewardInfo.items.Add(new RewardItem()
                            {
                                id = rand.item_id,
                                count = rand.item_cnt
                            });
                        }
                        //todo: 滚屏广播

                        l.Dmd10UsedNumb += 1;
                        response.success = true;

                    }
                }
            }

            if (response.success)
            {

                String reason;
                if (mode == 1)
                {
                    reason = "金币";
                }
                else
                {
                    reason = "钻石";
                }
                if (method == 1)
                {
                    reason += "单抽";
                }
                else
                {
                    reason += "十连抽";
                }
                foreach(var kv in response.rewardInfo.items.GroupBy(x => x.id))
                {
                    int itemid = kv.Key;
                    int itemcnt = kv.Sum(m => m.count);
                    pkgController.AddItem(p, itemid, itemcnt, reason);
                }
            }

            _db.SaveChanges();

            response.diamond = p.Wallet.DIAMOND;
            response.diamondBaseNumb = l.DmdBaseNumb;
            response.diamondFreeNextTime = l.DmdFreeNextTime.ToUnixTime();
            response.diamondUsedNumb = l.DmdUsedNumb;
            response.gold = p.Wallet.GOLD;
            response.goldBaseNumb = l.GoldBaseNumb;
            response.goldFreeNextTime = l.GoldFreeNextTime.ToUnixTime();
            response.goldUsedNumb = l.GoldUsedNumb;
            response.goldFreeNumb = l.GoldFreeNumb;
            response.diamondFreeNumb = l.DmdFreeNumb;

            CurrentSession.SendAsync(response);
            return 0;
        }
        #endregion
    }

}

