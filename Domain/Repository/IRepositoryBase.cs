using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Domain.Repository
{
   public interface IRepositoryBase<T>
    {
        
        T GetByID(string id);
        bool DeleteByID(string id);
        bool Update(T val);
        IEnumerable<T> GetAll();
        bool Add(T val);
       
    
    }
}
