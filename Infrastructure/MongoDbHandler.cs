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
    
        private readonly MongoClient _client;
        IBeerstoreDatabaseSettings _settings;
        IMongoDatabase _dataBase;

        string _mongoUrl;
        public MongoDbHandler(IBeerstoreDatabaseSettings settings)
        {
            _mongoUrl =  Environment.GetEnvironmentVariable("MONGODB_URL");
            
            if(_mongoUrl != null){
                _client = new MongoClient(_mongoUrl);
                _settings = settings;
                _dataBase = _client.GetDatabase(settings.DatabaseName);
            }

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
                ConnectionString = _mongoUrl
            };
        }

        private List<string> getDatabaseNamesAsList(IAsyncCursor<string> dbNames) {

            List<string> databaseNames = new List<string>();

            dbNames.ForEachAsync<string>(element => { databaseNames.Add(element);return; });

            return databaseNames;
        }
        


    }
}
