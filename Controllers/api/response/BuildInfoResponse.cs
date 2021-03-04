using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
namespace MongoApi.Controllers.Api.Response
{
    public class BuildInfoResponse
    {
         public String BaseTag {get; set;}
         public String Branche {get; set;}
          public String Commit {get; set;}
           public String CommitDate {get; set;}
           public String Tag {get; set;}
           public String Sha {get; set;}
          public String Version {get; set;}
       
    }
}