using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoApi.Services
{
    public class MongoInfo
    {
        public List<string> Databasenames { get; set; }

        public string ConnectionString { get; set; }

    }
}