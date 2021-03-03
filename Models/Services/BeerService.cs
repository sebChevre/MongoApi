
using MongoApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoApi.Infrastructure;

namespace MongoApi.Services
{
    public class BeerService
    {
        private readonly IMongoCollection<Beer> _beers;

        private readonly MongoDbHandler _mongoDbHandler;

        public BeerService(IBeerstoreDatabaseSettings settings)
        {

            _mongoDbHandler = new MongoDbHandler(settings);

           
            _beers =  _mongoDbHandler.GetDataBase().GetCollection<Beer>(settings.BeerCollectionName);
        }


        public List<Beer> Get() =>
            _beers.Find(beer => true).ToList();

        public Beer Get(string id) =>
            _beers.Find<Beer>(book => book.Id == id).FirstOrDefault();

        public Beer Create(Beer beer)
        {
            _beers.InsertOne(beer);
            return beer;
        }

        public void Update(string id, Beer beerIn) =>
            _beers.ReplaceOne(beer => beer.Id == id, beerIn);

        public void Remove(Beer bookIn) =>
            _beers.DeleteOne(beer => beer.Id == bookIn.Id);

        public DeleteResult Remove(string id) =>
            _beers.DeleteOne(beer => beer.Id == id);
    }
}
