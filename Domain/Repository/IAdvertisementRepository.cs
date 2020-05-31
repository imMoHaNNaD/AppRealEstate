using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;

namespace Domain.Repository
{
    public interface IAdvertisementRepository : IRepositoryBase<Advertisement>
    {
        IEnumerable<Advertisement> GetByUserID(string userID);

    }
}
