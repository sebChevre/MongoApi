using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MongoApi.Controllers.api.rsponse;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using MongoApi.Models;
using MongoApi.Infrastructure;


namespace MongoApi.Controllers.api
{
    [ApiController]
    [Route("api/pipedream")]

     public class PipeDreamApiController : ControllerBase
    {
    
    
    [HttpGet]
    public async Task<PipeDreamResponse> Index()
        {
            return await new PipeDreamHandler().GetPipeDreamResponse();
        }
    
    
    }

}
