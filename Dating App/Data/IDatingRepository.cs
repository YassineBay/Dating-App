using Dating_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.Data
{
    public interface IDatingRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
