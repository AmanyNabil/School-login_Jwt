using SchoolManagment_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment_API.Services
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAllClassesForSchool(int SchoolId);
        Task<Class> AddClass(string name,int floor,int SchoolId);
        Task<Class> GetClassByID(int classId);
        Task<bool> CheckClassIsAlreadyExist(string name, int schoolId);
        Task<Class> EditClass(Class @class,string  name,int floor);
        Task<bool> DeleteClass(int id);
    }
}
