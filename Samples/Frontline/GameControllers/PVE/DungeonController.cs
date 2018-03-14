using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class DungeonController : GameController
    {
        public void SectionInfo(GameSession session, SectionInfoRequest request)
        {
            SectionInfoResponse response = JsonConvert.DeserializeObject<SectionInfoResponse>("{\"id\":\"10000f2\",\"sections\":[{\"name\":\"初临战场\",\"id\":1,\"type\":1,\"open\":true},{\"name\":\"初临战场\",\"id\":1,\"type\":2,\"open\":false},{\"name\":\"激烈交战\",\"id\":2,\"type\":1,\"open\":false},{\"name\":\"激烈交战\",\"id\":2,\"type\":2,\"open\":false},{\"name\":\"白色方案\",\"id\":3,\"type\":1,\"open\":false},{\"name\":\"白色方案\",\"id\":3,\"type\":2,\"open\":false},{\"name\":\"闪电战\",\"id\":4,\"type\":1,\"open\":false},{\"name\":\"闪电战\",\"id\":4,\"type\":2,\"open\":false},{\"name\":\"西线战场\",\"id\":5,\"type\":1,\"open\":false},{\"name\":\"西线战场\",\"id\":5,\"type\":2,\"open\":false},{\"name\":\"北非战场\",\"id\":6,\"type\":1,\"open\":false},{\"name\":\"北非战场\",\"id\":6,\"type\":2,\"open\":false},{\"name\":\"巴巴罗萨计划\",\"id\":7,\"type\":1,\"open\":false},{\"name\":\"巴巴罗萨计划\",\"id\":7,\"type\":2,\"open\":false},{\"name\":\"霸王行动\",\"id\":8,\"type\":1,\"open\":false},{\"name\":\"霸王行动\",\"id\":8,\"type\":2,\"open\":false},{\"name\":\"突破包围网\",\"id\":9,\"type\":1,\"open\":false},{\"name\":\"突破包围网\",\"id\":9,\"type\":2,\"open\":false},{\"name\":\"帝国的毁灭\",\"id\":10,\"type\":1,\"open\":false},{\"name\":\"帝国的毁灭\",\"id\":10,\"type\":2,\"open\":false},{\"name\":\"斩首行动\",\"id\":11,\"type\":1,\"open\":false},{\"name\":\"斩首行动\",\"id\":11,\"type\":2,\"open\":false},{\"name\":\"殊死一战\",\"id\":12,\"type\":1,\"open\":false},{\"name\":\"殊死一战\",\"id\":12,\"type\":2,\"open\":false}],\"success\":true}");
            session.SendAsync(response);
        }

        public void FbInfo(GameSession session, FBInfoRequest request)
        {
            FBInfoResponse response = JsonConvert.DeserializeObject<FBInfoResponse>("{\"fbs\":[{\"fid\":\"10000f2m31010100\",\"remainTimes\":99,\"icon\":\"plain_day\",\"type\":1,\"drop_items\":[41151201],\"gold\":500,\"fight_times\":99,\"map_res_name\":\"plain_day\",\"id\":31010100,\"power\":500,\"time_limit_1\":1200,\"exp\":100,\"resetRemainNumb\":1,\"time_limit_2\":240,\"time_limit_3\":120,\"oil_cost\":10,\"wipe_cost\":1,\"star\":0,\"remainBuyTimes\":0,\"level_limit\":1,\"name\":\"前线先锋\",\"screen_id\":\"plain_day\",\"map_file_name\":\"plain_day\",\"random_id\":69100101,\"map_fighting\":\"FB1 - 1\",\"open\":true,\"desc\":\"占领敌军据点，进行补给\",\"dropItems\":[41151201]},{\"remainTimes\":0,\"icon\":\"village_fengche\",\"type\":1,\"drop_items\":[41152201],\"gold\":500,\"fight_times\":99,\"map_res_name\":\"village_fengche\",\"id\":31010200,\"power\":600,\"time_limit_1\":1200,\"exp\":100,\"resetRemainNumb\":0,\"time_limit_2\":240,\"time_limit_3\":120,\"oil_cost\":10,\"wipe_cost\":1,\"star\":0,\"remainBuyTimes\":0,\"level_limit\":1,\"name\":\"落难的民兵\",\"screen_id\":\"village_fengche\",\"map_file_name\":\"village_fengche\",\"random_id\":69100102,\"map_fighting\":\"FB1 - 2\",\"open\":false,\"desc\":\"请尽快救出被困的民兵\"},{\"remainTimes\":0,\"icon\":\"village_2bridge\",\"type\":1,\"drop_items\":[41151301],\"gold\":500,\"fight_times\":99,\"map_res_name\":\"village_2bridge\",\"id\":31010300,\"power\":700,\"time_limit_1\":1200,\"exp\":200,\"resetRemainNumb\":0,\"time_limit_2\":240,\"time_limit_3\":120,\"oil_cost\":10,\"wipe_cost\":1,\"star\":0,\"remainBuyTimes\":0,\"level_limit\":1,\"name\":\"击退反攻\",\"screen_id\":\"village_2bridge\",\"map_file_name\":\"village_2bridge\",\"random_id\":69100103,\"map_fighting\":\"FB1 - 3\",\"open\":false,\"desc\":\"打退敌军反攻，守住哨岗\"}],\"success\":true,\"section\":1,\"id\":\"10000f2\",\"type\":1}");

            session.SendAsync(response);
        }
    }
}
