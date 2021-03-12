using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MongoApi.Controllers.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using MongoApi.Models;
using MongoApi.Infrastructure;
using Oracle.ManagedDataAccess.Client;




namespace MongoApi.Controllers.api
{
    [ApiController]
    [Route("api/oracle")]

     public class OracleController : ControllerBase
    {
    
    
    [HttpGet]
    public  List<string> Index()
        {
            List<string> dbResults = new List<string>();

            string conString = "User Id=SCE;Password=110978;Data Source=localhost:1521/XEPDB1";

                using(OracleConnection con = new OracleConnection(conString)){
                    
                    using(OracleCommand cmd = con.CreateCommand()){

                        try{
                            con.Open();
                            cmd.BindByName = true;
                            cmd.CommandText = "select * from SYS.TEST";

                            OracleDataReader reader = cmd.ExecuteReader();

                            while(reader.Read()){
                                dbResults.Add(reader.GetString(1));
                                //await context.Response.Body.WriteAsync("" + reader.GetString(1));
                            }
                        }catch(Exception ex){
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

            return dbResults;
        }
    
    
    }

}
