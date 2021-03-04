
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Controllers.Api.Response;
using MongoApi.Infrastructure;
using System.Net.Http;
using System.Threading.Tasks;

namespace MongoApi.Controllers.Api{

    [ApiController]
    [Route("api/buildinfo")]
    public class BuildInfoController : ControllerBase
    {
        [HttpGet]
        public BuildInfoResponse Index()
        {
                return new BuildInfoResponse{
                    BaseTag = ThisAssembly.Git.BaseTag,
                    Branche = ThisAssembly.Git.Branch,
                    Commit = ThisAssembly.Git.Commit,
                    CommitDate = ThisAssembly.Git.CommitDate,
                    Tag = ThisAssembly.Git.Tag,
                    Sha = ThisAssembly.Git.Sha,
                    Version = ThisAssembly.Git.SemVer.Major + "." + ThisAssembly.Git.SemVer.Minor + "." + ThisAssembly.Git.SemVer.Patch
                };
        }
        
        
        
    }

}