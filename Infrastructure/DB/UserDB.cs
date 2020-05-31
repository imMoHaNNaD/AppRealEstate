using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Repository;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure
{
   public class UserDB : IUserRepository
    {
        private IMongoCollection<User> user;
      public  UserDB() {
            var  client = new MongoClient("mongodb+srv://mohannad:UuY9EwZlx37lE69a@cluster0-jl3cv.mongodb.net/test?retryWrites=true&w=majority"

               );

            var database = client.GetDatabase("test");
             user = database.GetCollection<User>("User");
        }
        
        public bool Add(User val)
        {
            user.InsertOne(val);
            return true;
        }

        public bool CreateToken(Token token, string userID)
        {

            var update = Builders<User>.Update
                .Push(e=>e.tokens,token);
            var res = user.UpdateOne(e=>e.id ==userID, update);
            return res.ModifiedCount > 0 ? true : false;

        }
        public bool DeleteByID(string id)
        {
            var res =  user.DeleteOne(e=>e.id == id);
            return res.DeletedCount > 0 ? true : false ;
        }

        //public bool DeleteByID(string id, string userid)
        //{
        //    var res = user.DeleteOne(
        //        e => e.id == userid
               
        //        );
        //    return res.DeletedCount > 0 ? true : false;
        //}

        public IEnumerable<User> GetAll()
        {
            var res =user.Find(_=> true);
            return res.ToEnumerable();
        }

        //public IEnumerable<User> GetAll(string userid)
        //{
        //    var res = user.Find(e =>e.id == userid);
        //    return res.ToEnumerable();
        //}

        public User GetByID(string id)
        {
            var res = user.Find(e => e.id == id);
            return res.FirstOrDefault();
        }

        //public User GetByID(string id, string userid)
        //{
        //    var res = user.Find(e => e.id == userid);
        //    return res.FirstOrDefault();
        //}

        public string GetContactinfo(string id)
        {
            
            var res = user.Find(e => e.id == id);
            return res.FirstOrDefault().phone;
        }

        public User Login(string email)
        {
            var res = user.Find(e => e.email ==email );
            return res.FirstOrDefault();
        }

        public bool Logout(string token)
        {
            var update = Builders<User>.Update
                .PullFilter(e => e.tokens, f => f.token == token);
            var res = user.UpdateOne(e => e.tokens.Any(e => e.token == token), update);
            return res.ModifiedCount > 0 ? true : false;

        }

        public bool LogoutAll(string token)
        {
            var update = Builders<User>.Update
                .PullFilter(e => e.tokens, f =>true);

            var res = user.UpdateOne(e=>e.tokens.Any(e=> e.token ==token), update);

            return res.ModifiedCount>  0 ? true : false;
        }

        public bool Update(User val)
        {
            var filter = Builders<User>.Filter.Eq(e=> e.id,val.id);
            var update = Builders<User>.Update
                .Set(e=>e.phone ,val.phone)
                .Set(e=>e.email , val.email);
            var res = user.UpdateOne(filter, update);

          return res.ModifiedCount>0?true:false;

        }

        //public bool Update(User val, string userid)
        //{
        //    var filter = Builders<User>.Filter.Eq(e => e.id, val.id);
        //    var update = Builders<User>.Update
        //        .Set(e => e.phone, val.phone)
        //        .Set(e => e.email, val.email);
        //    var res = user.UpdateOne(filter, update);

        //    return res.ModifiedCount > 0 ? true : false;
        //}

        public bool Validaion(string token)
        {
            var res = user.Find(e => e.tokens.Any(e => e.token == token)); 
            return res.CountDocuments() > 0 ? true:false ;
        }
    }
}
