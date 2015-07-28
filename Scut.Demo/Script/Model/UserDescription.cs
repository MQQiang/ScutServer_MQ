using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using ZyGames.Framework.Game.Context;
using ZyGames.Framework.Model;

namespace GameServer.Script.Model
{
    [Serializable,ProtoContract]
    [EntityTable("ConnData")]
    public   class UserDescription:BaseEntity
    {



        [ProtoMember(1)]
        [EntityField(true)]
        public int UserId
        {
            get;
            set;
        }
        [ProtoMember(2)]
        [EntityField]
        public string UserName
        {
            get;
            set;
        }

        protected override int GetIdentityId()
        {

            return UserId;
            throw new NotImplementedException();
        }


    }
}
