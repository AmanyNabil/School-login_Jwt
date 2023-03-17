using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment_API.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllEntities();
        Task<T> GetEntityById(int id);
        Task<T> CreateEntity(T entity);
        Task<T> UpdateEntity(T entity);
     
        Task<bool> DeleteEntity(T entity);
    }
}
