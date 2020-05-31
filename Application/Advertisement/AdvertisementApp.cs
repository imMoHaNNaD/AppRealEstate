using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Status;
using Domain.Repository.Application;
using Domain.Repository;

using LanguageExt;
using Infrastructure;
using System.Linq;

namespace Application.Advertisement
{
    public class AdvertisementApp : IAdvertisementRepositoryApp
    {
        private IAdvertisementRepository _advertisement = new AdvertisementDB();
        public Either<UserServicesStatus, bool> Add(Domain.Entity.Advertisement val)
        {
            var res = _advertisement.Add(val);
            if (!res)
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res;
        }

        public Either<UserServicesStatus, bool> DeleteByID(string id)
        {
            var res = _advertisement.DeleteByID(id);
            if (!res)
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res;
        }

        public Either<UserServicesStatus, Domain.Entity.Advertisement> GetByID(string id)
        {
            var res = _advertisement.GetByID(id);
            if (res.IsNull())
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res;
        }

        public Either<UserServicesStatus, IEnumerable<Domain.Entity.Advertisement>> GetByUserID(string userID)
        {
            var res = _advertisement.GetByUserID(userID);
            if (res.IsNull())
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res.ToList();
        }

        public Either<UserServicesStatus, bool> Update(Domain.Entity.Advertisement val)
        {
            var res = _advertisement.Update(val);
            if (!res)
            {
                return UserServicesStatus.NotFoundUser;
            }
            return res;
        }
    }
}
