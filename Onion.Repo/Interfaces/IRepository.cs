using System.Collections.Generic;
using Onion.Data.Entities;

namespace Onion.Repo.Interfaces
{
    public interface IRepository<T> where T : BaseAuditClass  
    {  
        IEnumerable<T> GetAll();  
        T Get(long id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);  
        void Remove(T entity);  
        void SaveChanges();  
    }
}