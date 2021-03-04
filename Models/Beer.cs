using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MongoApi.Models
{
    public class Beer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("BeerName")]
        [Required, MaxLength(30), RegularExpression(@"^[a-zA-Zàâçéèêëîïôûùüÿñæœ''-'\s]{1,40}$")] ///^[a-zàâçéèêëîïôûùüÿñæœ .-]*$/i
        public string BeerName { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }
    }
}