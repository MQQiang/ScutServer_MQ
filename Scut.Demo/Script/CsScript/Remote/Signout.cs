using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZyGames.Framework.Game.Runtime;
using ZyGames.Framework.Game.Service;
using ZyGames.Framework.RPC.IO;
using ZyGames.Framework.Game.Contract;

namespace GameServer.Script.CsScript.Remote
{
    public class SignOut : RemoteStruct
    {

        public SignOut(ActionGetter paramGetter, MessageStructure response)
            : base(paramGetter, response)
        {



        }

        protected override bool Check()
        {
            return true;
        }

        protected override void TakeRemote()
        {
            var sesson = paramGetter.GetSession();
            if (sesson == null)
            {
                return;
            }
            GameEnvironment.IsCanceled = true;

        }

        protected override void BuildPacket()
        {
            response.PushIntoStack("hello");
        }

        static void Test()
        {
            var socketRemote = RemoteService.CreateTcpProxy("proxy1", "127.0.0.1",9001,10);
            socketRemote.Call("SignOut",new RequestParam(), result =>{
                
            });

        }

    }
}
