using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;

namespace Domain.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        string GetContactinfo(string id);
        bool Validaion(string token);
        User Login(string email);
        bool Logout(string token);
        bool LogoutAll(string token);
        bool CreateToken(Token token, string userID);


    }
}
