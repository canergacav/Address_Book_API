using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Address_Book_API.Domain.Models
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Created { get; set; } = DateTime.Now;

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? Updated { get; set; }
    }
}
