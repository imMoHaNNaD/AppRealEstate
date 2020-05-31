using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Repository;
using MongoDB.Driver;

namespace Infrastructure
{
    public class AdvertisementDB : IAdvertisementRepository
    {
        private IMongoCollection<Advertisement> advertisement;
        public AdvertisementDB() 
        { 
            
        
            var client = new MongoClient("mongodb+srv://mohannad:UuY9EwZlx37lE69a@cluster0-jl3cv.mongodb.net/test?retryWrites=true&w=majority"

               );

            var database = client.GetDatabase("test");
            advertisement = database.GetCollection<Advertisement>("Advertisement");
        }
        public bool Add(Advertisement val)
        {
            advertisement.InsertOne(val);
            return true;
        }

        public bool DeleteByID(string id)
        {
            var res = advertisement.DeleteOne(e => e.id == id);
            return res.DeletedCount > 0 ? true : false;
        }

        //public bool DeleteByID(string id, string userid)
        //{
        //    var res = advertisement.DeleteOne(e => e.id == id && e.userID == userid);
        //    return res.DeletedCount > 0 ? true : false;
        //}

        public IEnumerable<Advertisement> GetAll()
        {
            var res = advertisement.Find(_ => true);
            return res.ToEnumerable();
        }

        //public IEnumerable<Advertisement> GetAll(string userid)
        //{
        //    var res = advertisement.Find(e => e.userID == userid);
        //    return res.ToEnumerable();
        //}

        public Advertisement GetByID(string id)
        {
            var res = advertisement.Find(e => e.id == id);
            return res.FirstOrDefault();
        }

        public IEnumerable<Advertisement> GetByUserID(string userID)
        {
            var res = advertisement.Find(e => e.userID == userID);
            return res.ToEnumerable();
        }

        //public Advertisement GetByID(string id, string userid)
        //{
        //    var res = advertisement.Find(e => e.id == id && e.userID == userid);
        //    return res.FirstOrDefault();
        //}

        public bool Update(Advertisement val)
        {
            var res = advertisement.ReplaceOne(e => e.id == val.id , val);
            return res.ModifiedCount > 0 ? true : false;
        }

        //public bool Update(Advertisement val, string userid)
        //{
        //    var res = advertisement.ReplaceOne(e => e.id == val.id && e.userID == userid, val) ;
        //    return res.ModifiedCount > 0 ? true : false;
        //}
    }
}
