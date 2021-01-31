using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using MongoApi.Services;

namespace StandardAPI.Controllers
{
    [ApiController]
    [Route("/api/Beer")]
    public class SystemInfBeerApiController : ControllerBase
    {

        IBeerstoreDatabaseSettings _settings;
        BeerService _beerService;

        public SystemInfBeerApiController(BeerService beerService,IBeerstoreDatabaseSettings settings){
            _settings = settings;
            _beerService = beerService;
        }

        [HttpPost]
        [Route("save")]
        public Beer Save([FromBody]Beer beer)
        {
            Console.WriteLine("Post Create");
            Console.WriteLine(beer.BeerName);
            _beerService.Create(beer);
            return beer;
        }
    }
}
