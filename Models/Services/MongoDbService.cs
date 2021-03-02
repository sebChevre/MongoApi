using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using MongoDB.Driver;
using MongoApi.Infrastructure;

namespace MongoApi.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<MongoInfo> _beers;
        private readonly MongoClient _client;
        IBeerstoreDatabaseSettings _settings;

        private readonly MongoDbHandler _mongoDbHandler;
        public MongoDbService(IBeerstoreDatabaseSettings settings)
        {
           _mongoDbHandler = new MongoDbHandler(settings);  
        
        }

        public MongoInfo getMongoInfo() {


            return _mongoDbHandler.getMongoInfo();
            
        }

        private List<string> getDatabaseNamesAsList(IAsyncCursor<string> dbNames) {

           return _mongoDbHandler.GetListDatabaseName();
        }
        


    }
}
