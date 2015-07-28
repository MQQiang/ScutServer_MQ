using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZyGames.Framework.Cache.Generic;

namespace GameServer.Script.Model
{
     public  class StaticServerModule:MemoryCacheStruct<StaticServerEntity>
    {
         public bool Refresh(int userId)
         {
             return true;
         }

         public bool ReceiveSuccess(StaticServerEntity server)
         {
             if (TryRemove(server.ServerId.ToString()))
             {
                 server.ModifyLocked(()=>{
                     
                     

                 }

                    
                     )
             }
         }

    }
}
