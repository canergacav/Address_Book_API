using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Address_Book_API.Domain.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
