using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Threading;

namespace MongoApi
{
    public class Program
    {

       // public static bool IsNotified = false;
        
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args)
            //.Build().Run();

            
            string conString = "User Id=SCE;Password=110978;Data Source=localhost:1521/XEPDB1";

            OracleConnection con = null;
            OracleDependency dep = null;

            

            try{
                con = new OracleConnection(conString);
                OracleCommand cmd = new OracleCommand("select * from SCE.TESTSCE", con);
                con.Open();
                
                OracleDependency.Port = 1005;

                dep = new OracleDependency(cmd);

                dep.QueryBasedNotification = true;
                cmd.Notification.IsNotifiedOnce = false;

                dep.OnChange += new OnChangeEventHandler(Program.OnMyNotificaton);
                cmd.ExecuteNonQuery();

                /** OracleTransaction txn = con.BeginTransaction();
                // Create a new command which will update emp table
                string updateCmdText = 
                "insert into SCE.TESTSCE values(13,'yep')";
                OracleCommand updateCmd = new OracleCommand(updateCmdText, con);
                // Update the emp table
                updateCmd.ExecuteNonQuery();
                //When the transaction is committed, a notification will be sent from
                //the database
                txn.Commit();

                Console.WriteLine("commit...");
                */

                
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }

            con.Close();

            Console.WriteLine("thread...");
            //Thread.Sleep(50000);
                        

                  

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
        public static void OnMyNotificaton(object src, OracleNotificationEventArgs args)
        {
            Console.WriteLine("Notification Received");
            DataTable changeDetails = args.Details;
            //changeDetails.Rows[0].
            OracleNotificationType t = args.Type;

            OracleDependency d = (OracleDependency)src;
            
            Console.WriteLine(src);
            Console.WriteLine("83333");
            //string rowid = changeDetails.Rows[0]["Rowid"].ToString();
            
            Console.WriteLine("Data has changed in {0}", changeDetails.Rows[0]["ResourceName"]); 
            Console.WriteLine("Data has changed in {0}", changeDetails.Rows[0]["ResourceName"]);     

            for (int i = 1; i < args.Details.Rows.Count; i++)
            {
            DataRow detailRow = args.Details.Rows[i];
                string rowid = detailRow["Rowid"].ToString();
                Console.WriteLine(rowid);

            }


            foreach (DataRow row in changeDetails.Rows){
                Console.WriteLine("yep {0}", row[0]);
                Console.WriteLine("yep {0}", row[1]);
                Console.WriteLine("yep {0}", row[2]);

                for(int cpt=0;cpt<row.ItemArray.Length;cpt++){
                     Console.WriteLine("yeps {0}", row[cpt]);
                }

                  

            }
            Console.WriteLine(t.GetType());        
        }
    }

    
}
