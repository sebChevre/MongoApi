namespace MongoApi.Models
{
    public class SystemInfo
    {
        public string Ip { get; set; }
        public string Host { get; set; }
        public string LocalIp { get; set; }

        public string MongoDbConnectionString {get; set;}
        public string Env { get; internal set; }
        public string MongUrl { get; internal set; }
    }
}
