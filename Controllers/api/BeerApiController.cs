using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using MongoApi.Services;
using MongoDB.Driver;

namespace StandardAPI.Controllers.api
{
    [ApiController]
    [Route("/api/Beer")]
    public class BeerApiController : ControllerBase
    {

        IBeerstoreDatabaseSettings _settings;
        BeerService _beerService;

        public BeerApiController(BeerService beerService,IBeerstoreDatabaseSettings settings){
            _settings = settings;
            _beerService = beerService;
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(string id)
        {
            var result = _beerService.Remove(id);
            
            return result.IsAcknowledged;
        }

        [HttpPost]
        public Beer Save([FromBody]Beer beer)
        {
            Console.WriteLine("Post Create");
            Console.WriteLine(beer.BeerName);
            _beerService.Create(beer);
            return beer;
        }

        [HttpGet]
        public List<Beer> List()
        {
            return _beerService.Get();
        }
    }
}
