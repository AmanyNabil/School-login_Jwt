using Microsoft.AspNetCore.Identity;
using SchoolManagment_API.Data.Models;
using SchoolManagment_API.Data.Repositories;
using SchoolManagment_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment_API.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _schoolClass;

        public ClassService(IClassRepository schoolClass)
        {
            _schoolClass = schoolClass;
           
        }
        public async Task<IEnumerable<Class>> GetAllClassesForSchool(int schoolId)
        {
            return await _schoolClass.GetAllEntities(schoolId);
        }

        public async Task<Class> GetClassByID(int classId)
        {
            return await _schoolClass.GetEntityById(classId);
        }

        public async Task<bool> CheckClassIsAlreadyExist(string name, int schoolId)
        {
           return await _schoolClass.CheckClassIsExist(name, schoolId);
        }
        public async Task<Class> AddClass(string name, int floor, int schoolId)
        {
           
           return await _schoolClass.CreateEntity(new Class { name = name, floor = floor, schoolId = schoolId });
            
        }


        public async Task<Class> EditClass(Class @class, string name, int floor)
        {
            @class.name = name;
            @class.floor = floor;
            
            return await _schoolClass.UpdateEntity(@class);
        }
           
        public async Task<bool> DeleteClass(int id)
        {
            var result = await _schoolClass.GetEntityById(id);
            return  result != null ? await _schoolClass.DeleteEntity(result) : false;
        }
    }
}
