using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class CampController : GameController
    {
        public void Info(UnitListRequest request)
        {
            UnitListResponse response = JsonConvert.DeserializeObject<UnitListResponse>("{ \"units\":[{\"mob\":72,\"max_energy\":99,\"nation\":4,\"hp\":642,\"pid\":\"10000f2\",\"equips\":[{\"equipId\":10101,\"level\":1,\"id\":\"10000f2u21140101e10101\"},{\"equipId\":10102,\"level\":1,\"id\":\"10000f2u21140101e10102\"},{\"equipId\":10103,\"level\":1,\"id\":\"10000f2u21140101e10103\"},{\"equipId\":10104,\"level\":1,\"id\":\"10000f2u21140101e10104\"},{\"equipId\":10105,\"level\":1,\"id\":\"10000f2u21140101e10105\"},{\"equipId\":10106,\"level\":1,\"id\":\"10000f2u21140101e10106\"}],\"prop_type\":[1,2,3],\"type\":1,\"supply\":0,\"prop_val\":[360,120,640],\"tid\":21140101,\"type_detail\":6,\"att_ex\":0,\"number\":81,\"rank\":1,\"id\":\"10000f2u21140101\",\"exp\":0,\"energy\":1,\"att\":361,\"hp_growth\":25,\"rev\":0,\"hp_add\":0,\"level\":1,\"hp_ex\":0,\"hurt_multiple\":0.5,\"count\":3,\"att_growth\":14,\"exist\":1,\"prop_grow_val\":[14,4,25],\"armor\":1,\"preparing\":false,\"crit_v\":0,\"name\":\"皇家步兵分队\",\"hurt_add\":0,\"att_add\":0,\"desc\":\"装备“李 - 恩菲尔德”短步枪。英军的主力，虽然名头听起来很高大，其实就是人数多，能力一般。\",\"distance\":12,\"defence\":120,\"claz\":0,\"def_ex\":0,\"speed\":2.9,\"gold\":0,\"levelLimit\":0,\"prop_grow_type\":[1,2,3],\"prepareEndTime\":0,\"pvp_point\":20,\"last_time\":1,\"hurt_sub_v\":0,\"hurt_sub\":0,\"power\":4852,\"bullet_count\":1,\"crit_hurt\":1.5,\"rev_body\":330,\"cd\":2,\"star\":1,\"off\":0.8,\"r\":0,\"crit\":0.05,\"equip\":[10101,10102,10103,10104,10105,10106],\"def_add\":0,\"defence_growth\":4,\"iron\":0,\"pvp_dec_score\":8,\"hurt_add_v\":0}],\"success\":true}");
            
            CurrentSession.SendAsync(response);
        }

        public void teamList(TeamRequest request)
        {
            TeamResponse response = JsonConvert.DeserializeObject<TeamResponse>("{\"teams5\":[{\"bps\":[\"10000f2u21140101\",\"\",\"\",\"\",\"\"],\"selected\":true,\"id\":\"10000f2t1\"},{\"bps\":[\"10000f2u21140101\",\"\",\"\",\"\",\"\"],\"selected\":false,\"id\":\"10000f2t2\"},{\"bps\":[\"10000f2u21140101\",\"\",\"\",\"\",\"\"],\"selected\":false,\"id\":\"10000f2t3\"}],\"pid\":\"10000f2\",\"teams10\":[{\"bps\":[\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"],\"selected\":true,\"id\":\"10000f2t1\"},{\"bps\":[\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"],\"selected\":false,\"id\":\"10000f2t2\"},{\"bps\":[\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"],\"selected\":false,\"id\":\"10000f2t3\"}],\"success\":true}");

            CurrentSession.SendAsync(response);
        }
    }
}
