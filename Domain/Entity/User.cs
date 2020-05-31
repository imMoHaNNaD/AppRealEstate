using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public List<Token> tokens { get; set; } = new List<Token>();
    }

    public class Token
    {
        public string token { get; set; }
        //public DateTime expierdDate { get; set; }
    }
}
