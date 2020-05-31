using Domain.Core.Status;
using Domain.Entity;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository.Application
{
  public  interface IUserRepositoryApp
    {
        Either<UserServicesStatus, string> GetContactinfo(string id);
        Either<UserServicesStatus, bool> Validaion(string token);
        Either<UserServicesStatus, Token> Login(string email, string password);
        Either<UserServicesStatus, bool> Logout(string token);
        Either<UserServicesStatus, bool> LogoutAll(string token);
        //Either<UserServicesStatus, Token> CreateToken(Token token, string userID);
        Either<UserServicesStatus, bool> CreateUser(User user);
        Either<UserServicesStatus, bool> DeleteUser(string id);
        Either<UserServicesStatus, User> GetByIDUser(string id);
        Either<UserServicesStatus, List<User>> GetUser();




    }
}
