using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using MongoDB.Driver;
using MongoApi.Services;

namespace MongoApi.Infrastructure
{
    public class MongoDbHandler
    {
        private readonly IMongoCollection<MongoInfo> _beers;
        private readonly MongoClient _client;
        IBeerstoreDatabaseSettings _settings;
        IMongoDatabase _dataBase;
        public MongoDbHandler(IBeerstoreDatabaseSettings settings)
        {
            var mongoUrl =  Environment.GetEnvironmentVariable("MONGODB_URL");
            
            if(mongoUrl == null){
                mongoUrl = settings.ConnectionString;
            }

            _client = new MongoClient(mongoUrl);
            _settings = settings;
            _dataBase = _client.GetDatabase(settings.DatabaseName);
        }

public IMongoDatabase GetDataBase(){
    return this._dataBase;
}
        public  List<string> GetListDatabaseName () {
            
            var t = _client.ListDatabaseNames();
            return getDatabaseNamesAsList(t);
        }

        public MongoInfo getMongoInfo() {

            return new MongoInfo
            {
                Databasenames = (List<string>)this.getDatabaseNamesAsList(_client.ListDatabaseNames()),
                ConnectionString = _settings.ConnectionString
            };
        }

        private List<string> getDatabaseNamesAsList(IAsyncCursor<string> dbNames) {

            List<string> databaseNames = new List<string>();

            dbNames.ForEachAsync<string>(element => { databaseNames.Add(element);return; });

            return databaseNames;
        }
        


    }
}
