﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;

namespace StandardAPI.Controllers.api
{
    [ApiController]
    [Route("api/sysinfo")]
    public class SystemInfoController : ControllerBase
    {

        IBeerstoreDatabaseSettings _settings;
        public SystemInfoController(IBeerstoreDatabaseSettings settings){
            _settings = settings;
        }

        [HttpGet]
        public SystemInfo Get()
        {

            string envNet = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string mongoDbUrl = Environment.GetEnvironmentVariable("MONGODB_URL");
            
            return new SystemInfo
            {
                Ip = HttpContext.Connection.RemoteIpAddress.ToString(),
                Host = HttpContext.Request.Host.Host,
                LocalIp = HttpContext.Connection.LocalIpAddress.ToString(),
                AspNetCoreEnv = envNet,
                MongoDbUrl = mongoDbUrl

            };
            /*
        var ClientIPAddr = HttpContext.Connection.RemoteIpAddress?.ToString();
        HttpContext.Request.Host.Host
        */
        }
    }
}
