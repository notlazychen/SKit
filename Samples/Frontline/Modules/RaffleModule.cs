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

namespace Frontline.Modules
{
    public class RaffleModule : GameModule
    {
        
        private DataContext _db;

        public Dictionary<int, List<DRaffle>> DRaffles { get; private set; }//group>id>x
        public Dictionary<int, DRaffleGroup> DRaffleGroups { get; private set; }

        public RaffleModule(DataContext db, GameDesignContext design)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DRaffles = designDb.DRaffle.AsNoTracking().GroupBy(r=>r.drop).ToDictionary(x => x.Key, x => x.ToList());
                DRaffleGroups = designDb.DRaffleGroup.AsNoTracking().ToDictionary(x => x.type, x => x);
            });
        }

        #region 事件
        #endregion

        #region 辅助方法
        private Dictionary<string, Dictionary<int, Raffle>> _ins = new Dictionary<string, Dictionary<int, Raffle>>();

        public Raffle QueryRaffle(string pid, int type)
        {
            if(!_ins.TryGetValue(pid, out var rs))
            {
                rs = _db.Raffles.Where(x=>x.PlayerId == pid).ToDictionary(x=>x.Type, x=>x);
                DateTime now = DateTime.Now;
                if (rs.Count == 0)
                {
                    foreach(var g in this.DRaffleGroups.Values)
                    {
                        Raffle r = new Raffle()
                        {
                            PlayerId = pid,
                            Type = g.type,
                            BaseNumb = g.base_numb,
                            FreeNextTime = now,
                            LastTime = now,
                            FreeNumb = 0,
                            UsedNumb = 0,
                            UsedNumb10 = 0,
                        };
                        rs.Add(r.Type, r);
                    }
                    _db.Raffles.AddRange(rs.Values);
                    _db.SaveChanges();
                }
                else
                {
                    if(rs.Count != this.DRaffleGroups.Count)
                    {
                        //todo: 如果打算以后增开地话
                        foreach(var g in this.DRaffleGroups.Values)
                        {
                            if(!rs.TryGetValue(g.type, out var r))
                            {
                                if (r == null)
                                {
                                    r = new Raffle()
                                    {
                                        PlayerId = pid,
                                        Type = g.type,
                                        BaseNumb = g.base_numb,
                                        FreeNextTime = now,
                                        LastTime = now,
                                        FreeNumb = 0,
                                        UsedNumb = 0,
                                        UsedNumb10 = 0,
                                    };
                                    rs.Add(r.Type, r);
                                    _db.Raffles.Add(r);
                                    _db.SaveChanges();
                                }
                            }                            
                        }
                    }
                }
                
                _ins.Add(pid, rs);
            }
            
            return rs[type];
        }
        #endregion
    }

}

