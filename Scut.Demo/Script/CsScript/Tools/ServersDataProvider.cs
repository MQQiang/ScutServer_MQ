using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ServiceStack.Common.Extensions;
using ZyGames.Framework.Common;
using ZyGames.Framework.Common.Configuration;
using ZyGames.Framework.Data;
using ZyGames.Framework.Data.Sql;
using ZyGames.Framework.Game.Config;
using System;
using GameServer.Script.Model;
using ZyGames.Framework.Cache.Generic;

namespace GameServer.Script.CsScript.Tools
{
    public  class ServersDataProvider:IDisposable
    {



        DbBaseProvider _provider;

        private List<StaticServer> ServerList ;

        private const string ConnectKey = "ConnData";
        //private MiddlewareSection section;

        public ServersDataProvider()
        {
            if (_provider == null)
            {
                _provider = DbConnectionProvider.CreateDbProvider(ConnectKey);

                var command = _provider.CreateCommandStruct("StaticServer", CommandMode.Inquiry,"ServerId,Name,Ip,Port");

                command.Parser();

                using (var dr = _provider.ExecuteReader(CommandType.Text, command.Sql, command.Parameters))
                {
                   
                    var serversDatas = new ShareCacheStruct<StaticServer>();
                    while (dr.Read())
                    {
                        StaticServer oneServerModel = new StaticServer();
                        oneServerModel.ServerId = Convert.ToInt32(dr["ServerId"]) ;
                        oneServerModel.Name = dr["Name"].ToString();
                        oneServerModel.Ip = dr["Ip"].ToString();
                        oneServerModel.Port = Convert.ToInt32(dr["Port"]);
                        //ServerList.Add(oneServerModel);
                        serversDatas.Add(oneServerModel);
                        

                    }
                }
                //this.AddATestCache();

            }



        }

        private void AddATestCache(){

            var serversDatas = new ShareCacheStruct<StaticServer>();
            {
                StaticServer oneServerModel = new StaticServer();
                oneServerModel.ServerId = 5;
                oneServerModel.Name = "MQ";
                oneServerModel.Ip = "127.0.0.1";
                oneServerModel.Port = 9001;
                serversDatas.Add(oneServerModel);
            }
        }

         public   void Dispose()
        {

        }

    }
}
