using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using MongoApi.Services;

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
