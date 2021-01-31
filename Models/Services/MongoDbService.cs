using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using MongoDB.Driver;

namespace MongoApi.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<MongoInfo> _beers;
        private readonly MongoClient _client;
        IBeerstoreDatabaseSettings _settings;
        public MongoDbService(IBeerstoreDatabaseSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _settings = settings;
            var database = _client.GetDatabase(settings.DatabaseName);

            var t = _client.ListDatabaseNames();

            _beers = database.GetCollection<MongoInfo>(settings.BeerCollectionName);
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
