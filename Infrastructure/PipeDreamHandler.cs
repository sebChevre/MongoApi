using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using MongoDB.Driver;
using MongoApi.Services;
using MongoApi.Controllers.Api.Response;
using System.Net.Http;
using Newtonsoft.Json;

namespace MongoApi.Infrastructure
{

    
    public class PipeDreamHandler
    {
        
       private readonly string _pipeDreamUrl;

        public PipeDreamHandler()
        {
            _pipeDreamUrl =  Environment.GetEnvironmentVariable("PIPEDREAM_URL");
            Console.WriteLine("Pipedream url: " + _pipeDreamUrl);
        }

        public async Task<PipeDreamResponse> GetPipeDreamResponse(){
            
            PipeDreamResponse pipeDreamResponse = new PipeDreamResponse();
            
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_pipeDreamUrl))
                {
                     Console.WriteLine("Pipedream request: " + _pipeDreamUrl);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                     Console.WriteLine("Pipedream response: " + apiResponse);
                    pipeDreamResponse = JsonConvert.DeserializeObject<PipeDreamResponse>(apiResponse);
                }
            }

            return pipeDreamResponse;
        }



    }
}
