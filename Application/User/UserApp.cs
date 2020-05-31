using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core;
using Domain.Repository.Application;
using Domain.Entity;
using Infrastructure;
using LanguageExt;
using Domain.Core.Status;
using Domain.Repository;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Application.NewFolder;

namespace Application.User
{

  public  class UserApp : IUserRepositoryApp
    {

        private IUserRepository _userServices= new UserDB();

       
        public Either<UserServicesStatus, Token> CreateToken(Token token, string userID)
        {

            var CreateToken = _userServices.CreateToken(token, userID);
            if (!CreateToken)
                return UserServicesStatus.ServicesFailed;
            return token;
        }

        public Either<UserServicesStatus, bool> CreateUser(Domain.Entity.User user)

        {
            var checkemail = _userServices.Login(user.email);
            if (!checkemail.IsNull()) {
                return UserServicesStatus.EmailExisting;
            }
            var res = _userServices.Add(user);
            if (!res)
            {
                return UserServicesStatus.ServicesFailed;
            }
            return res;
        }

        public Either<UserServicesStatus, bool> DeleteUser(string id)
        {
            var res = _userServices.DeleteByID(id);
            if (!res)
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res;
        }

        public Either<UserServicesStatus, Domain.Entity.User> GetByIDUser(string id)
        {
            var res = _userServices.GetByID(id);
            if (res.IsNull())
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res;
        }

        public Either<UserServicesStatus, string> GetContactinfo(string id)
        {
            var res = _userServices.GetByID(id);
            if (res.IsNull())
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res.email;
        }

        public Either<UserServicesStatus, List<Domain.Entity.User>> GetUser()
        {

            var res = _userServices.GetAll();
            if (res.IsNull())
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res.ToList();
        }

        public Either<UserServicesStatus, Token> Login(string email, string password)
        {
            var res = _userServices.Login(email);
            if (res.IsNull()){
                return UserServicesStatus.NotFoundUser;
            }
            if (password != res.password) {
                return UserServicesStatus.WrongUserNameOrPassword;
            }
          
            Token token = new Token { token = Class1.GenerateToken(res) };
        
            var CreateToken = _userServices.CreateToken(token, res.id);
            if (!CreateToken)
            {
                return UserServicesStatus.ServicesFailed;
            }

            return token;
        }

        public Either<UserServicesStatus, bool> Logout(string token)
        {
            var res = _userServices.Logout(token);
            if (res)
            {
                return UserServicesStatus.ServicesFailed;
            }
            return res;
        }

        public Either<UserServicesStatus, bool> LogoutAll(string token)
        {
            var res = _userServices.LogoutAll(token);
            if (res)
            {
                return UserServicesStatus.ServicesFailed;
            }
            return res;
        }

        public Either<UserServicesStatus, bool> Validaion(string token)
        {
            var res = _userServices.Validaion(token);
            if (!res)
            {
                return UserServicesStatus.Unauthenticated;
            }
            return res;
        }
    }
}
