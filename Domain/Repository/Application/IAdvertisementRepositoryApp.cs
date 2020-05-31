using Domain.Core.Status;
using Domain.Entity;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository.Application
{
   public interface IAdvertisementRepositoryApp
    {
        Either<UserServicesStatus, Advertisement> GetByID(string id);
        Either<UserServicesStatus, IEnumerable<Advertisement>> GetByUserID(string userID);
        Either<UserServicesStatus, bool> DeleteByID(string id);
        Either<UserServicesStatus, bool> Update(Advertisement val);
        //Either<UserServicesStatus, bool> IEnumerable<T> GetAll();
        Either<UserServicesStatus, bool> Add(Advertisement val);
    }
}
