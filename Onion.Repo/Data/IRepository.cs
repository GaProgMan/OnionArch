using System.Collections.Generic;
using Onion.Data.Entities;

namespace Onion.Repo.Data
{
    public interface IRepository<T> where T : BaseAuditClass  
    {  
        IEnumerable<T> GetAll();  
        T Get(int id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);  
        void Remove(T entity);  
        void SaveChanges();  
    }
}