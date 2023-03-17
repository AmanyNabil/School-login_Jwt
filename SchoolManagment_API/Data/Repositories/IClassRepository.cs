using SchoolManagment_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment_API.Data.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<IEnumerable<Class>> GetAllEntities(int schoolId);
       Task<bool> CheckClassIsExist(string className, int schoolID);
        
    }
}
