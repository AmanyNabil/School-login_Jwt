using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagment_API.Data;
using EntityFramework.Exceptions.Common;
using SchoolManagment_API.Data.Repositories;

namespace SchoolManagment_API.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly School_dbcontext _context;
        public Repository(School_dbcontext context)
        {
            _context = context;
        }
       
        
       public async Task<IEnumerable<T>>  GetAllEntities()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);

            }
        }

        public async Task<T> CreateEntity(T entity)
        {
            try
            {
                var obj = await _context.Set<T>().AddAsync(entity);
                _context.SaveChanges();

                return obj.Entity;
            }
            catch (UniqueConstraintException e)
            {
                throw new NotImplementedException(e.Message);
            }
            catch (CannotInsertNullException e)
            {
                throw new NotImplementedException(e.Message);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<T> UpdateEntity(T entity)
        {
            try
            {
                var obj = _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            catch (UniqueConstraintException e)
            {
                throw new NotImplementedException(e.Message);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
        public async Task<bool> DeleteEntity(T entity)
        {
            try
            {
                var obj =_context.Set<T>().Remove(entity);
               await  _context.SaveChangesAsync();
               
                return obj != null ? true : false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


    }
}
