using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZyGames.Framework.Common.Security;
using ZyGames.Framework.Game.Lang;
using ZyGames.Framework.Game.Runtime;
using ZyGames.Framework.Game.Service;
using ZyGames.Framework.Game.Sns;
using GameServer.Script.Model;
using ZyGames.Framework.Cache.Generic;
namespace GameServer.Script.CsScript.Action
{
    class Action1009 : BaseStruct
    {

        List<StaticServer> staticServerList;

        public Action1009(ActionGetter actionGetter)
            : base((short)ActionType.Servers, actionGetter)
        {
        }


        /// <summary>
        /// 业务逻辑处理
        /// </summary>
        /// <returns>false:中断后面的方式执行并返回Error</returns>
        public override bool TakeAction()
        {
            var serverCache = new ShareCacheStruct<StaticServer>();

            staticServerList = serverCache.FindAll(false);

            //StaticServer serverData;



                return true;

        }
        /// <summary>
        /// 下发给客户的包结构数据
        /// </summary>
        public override void BuildPacket()
        {
            foreach (StaticServer server in staticServerList)
            {
                DataStruct  ds = new DataStruct();
                ds.PushIntoStack(server.ServerId);
                ds.PushIntoStack(server.Name);
                ds.PushIntoStack(server.Ip);
                ds.PushIntoStack(server.Port);
                this.PushIntoStack(ds);
            }
        }

    }
}
