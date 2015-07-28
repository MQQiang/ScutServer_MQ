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
    [EntityTable(CacheType.Entity, "ConnData")]
    public   class StaticServer:ShareEntity
    {

        public StaticServer()
            : base(false)
        {

        }

        [ProtoMember(1)]
        [EntityField(true)]
        public int ServerId
        {
            get;
            set;
        }
        [ProtoMember(2)]
        [EntityField]
        public string Name
        {
            get;
            set;
        }
        [ProtoMember(3)] 
        [EntityField]
        public string Ip
        {
            get;
            set;
        }
        [ProtoMember(4)]
        [EntityField]
        public int Port
        {
            get;
            set; 
        }

        protected override int GetIdentityId()
        {
            return ServerId;
        }
    }
}
