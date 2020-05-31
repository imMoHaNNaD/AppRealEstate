using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
   public class Advertisement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string userID { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public string type { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }
        public long space { get; set; }
        public List<Border> border { get; set; } = new List<Border>();




    }

    public class Border
    {
        public string direction { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public bool IsStreet { get; set; }

    }
}
