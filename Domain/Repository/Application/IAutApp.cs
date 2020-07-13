using Domain.Core.Status;
using Domain.Entity;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository.Application
{
   public interface IAutApp
    {
        Either<UserServicesStatus, string> Login(string email, string password);
        Either<UserServicesStatus, bool> Logout(string token);
        Either<UserServicesStatus, bool> LogoutAll(string token);
        Either<UserServicesStatus, bool> ValadtionToken(string token);
    }
}
