using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZyGames.Framework.Model;

namespace GameServer.Script.Model
{
    [EntityTable(CacheType.Entity,"ConnData",StorageType= StorageType.ReadOnlyDB)]
    public class StaticServerEntity : MemoryEntity
    {
        [EntityField(true, IsIdentity = true)]
        public int ServerId
        {
            get;
            set;
        }
        [EntityField]
          public string Name
        {
            get;
            set;
        }
        [EntityField]
        public string Ip
        {
            get;
            set;
        }
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

        public override string GetKeyCode()
        {
            return ServerId.ToString();
        }
    }
}
