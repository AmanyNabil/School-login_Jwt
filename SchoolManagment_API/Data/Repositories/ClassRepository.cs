using SchoolManagment_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagment_API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagment_API.Data.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(School_dbcontext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Class>> GetAllEntities(int SchoolId)
        {
            try
            {
                return await _context.Classes.AsQueryable().Where(c=>c.schoolId == SchoolId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> CheckClassIsExist(string className, int schoolID)
        {
            return await _context.Classes.AsQueryable().Where(
                c => c.name == className &&
                c.schoolId == schoolID).CountAsync() > 0 ? true : false;
        }
       
    }
}
