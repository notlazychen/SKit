using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
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
    public class LegionCareerChangeCommand : GameCommand<PersonnelRequest>
    {
        PlayerModule _playerModule;
        LegionModule _legionModule;
        DataContext _db;

        protected override void OnInit()
        {
            _legionModule = Server.GetModule<LegionModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }
        
        public override int ExecuteCommand()
        {
            if(string.IsNullOrEmpty(Request.pid) || Request.pid == Session.PlayerId){
                return -2;
            }
            var pm = _legionModule.QueryLegionMember(Session.PlayerId);
            if (string.IsNullOrEmpty(pm.LegionId))
            {
                return (int)GameErrorCode.军团不存在;
            }
            var legion = _legionModule.QueryLegion(pm.LegionId);
            var player = _playerModule.QueryPlayerBaseInfo(pm.PlayerId);
            var pm1 = legion.Members.FirstOrDefault(m => m.PlayerId == Request.pid);
            if (pm1 == null)
            {
                return -2;
            }
            if (pm.Career <= pm1.Career)
            {
                return (int)GameErrorCode.军团操作权限不足;
            }
            switch (Request.action)
            {
                case 0://踢出

                    if (legion.GvgState != LegionModule.GVG_STATE_NONE)
                    {
                        return (int)GameErrorCode.军团战期间不能退团;
                    }
                    legion.Members.Remove(pm1);
                    pm1.Career = LegionCareer.Free;
                    pm1.LastLeftTime = DateTime.Now;
                    pm1.LegionId = string.Empty;
                    pm1.Contribution = 0;
                    pm1.IsTodayDonated = false;
                    break;
                case -1://降职
                    if (pm1.Career > LegionCareer.Member)
                    {
                        pm1.Career = (LegionCareer)((int)pm1.Career - 1);
                    }
                    break;
                case 1://升职
                    var career = (LegionCareer)((int)pm1.Career + 1);
                    if (career == LegionCareer.Commander)//升任党首
                    {
                        pm.Career = LegionCareer.ViceCommander;
                        pm1.Career = career;
                    }
                    else
                    {
                        var count = legion.Members.Count(m => m.Career == career);
                        var dl = _legionModule.DLegions[legion.Level];
                        int max = dl.max;
                        switch(career)
                        {
                            case LegionCareer.ViceCommander:
                                max = GameConfig.LegionViceCommanderCount;
                                break;
                            case LegionCareer.Captain:
                                max = GameConfig.LegionCaptinCount;
                                break;
                        }
                        if(count < max)
                        {
                            //判断职位够不够
                            pm1.Career = career;
                        }
                        else
                        {
                            return (int)GameErrorCode.军团空闲职位不足;
                        }
                    }
                    break;
            }
            _db.SaveChanges();

            PersonnelResponse response = new PersonnelResponse();
            response.pid = Request.pid;
            response.career = (int)pm1.Career;
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
