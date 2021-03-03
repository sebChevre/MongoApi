using System.Text.Json.Serialization;

namespace MongoApi.Models
{
    public class SystemInfo
    {
        public string Ip { get; set; }
        public string Host { get; set; }
        public string LocalIp { get; set; }


        [JsonPropertyName("ASPNETCORE_ENVIRONMENT")]        
        public string AspNetCoreEnv { get; internal set; }

        [JsonPropertyName("MONGODB_URL")]      
        public string MongoDbUrl { get; internal set; }
    }
}
