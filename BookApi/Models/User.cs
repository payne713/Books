﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
