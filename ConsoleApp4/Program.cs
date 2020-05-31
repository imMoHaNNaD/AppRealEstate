using System;
using System.Linq;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Infrastructure;
using Application;
using Domain.Entity;
using Domain.Repository;
using System.Collections.Generic;
using LanguageExt;
using Application.User;

namespace ConsoleApp4
{
  
    class Program
    {
        static public Either<string,int> Check(bool t)
        {
            if(t)
            return 1;

            return "ff";
        }
        static void Main(string[] args)
        {

            var user = new UserApp();
            
            var advertisement = new AdvertisementDB();


            try
            {
               var i =  user.Validaion("");
                //var add = user.Add(
                //new User
                //{
                //    email = "mahanad@gmail.com",
                //    name = "mohannad",
                //    tokens = new List<Token>
                //    {
                //    new Token {
                //        expierdDate = DateTime.Now.ToUniversalTime(),
                //        token = "ASDFGHJKL"
                //    }
                //    }

                //  //});
                var r = Check(true);
                r.Bind(Check(true));
                var re = r.Match(
                  Left: l => $"Invalid value: {l}",
                  Right: r => $"The result is: {r}");
              
                Console.WriteLine(re);
                advertisement.Add(new Advertisement
                {
                    title = "",
                border = new List<Border> { new Border { IsStreet = false , direction = "" } }
               
                }
                    );
                  //var DeleteByID = user.DeleteByID("5ecc56c2609b036c58066ef1");
                //var addtoken = user.CreateToken(new Token {token = "jkfjkfjkfjkfj", expierdDate = DateTime.Now.ToUniversalTime() }, "5ecc57aca0c0e69ad86c4fec");
                //Console.WriteLine(DeleteByID);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }






        }
    }
    
    class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
