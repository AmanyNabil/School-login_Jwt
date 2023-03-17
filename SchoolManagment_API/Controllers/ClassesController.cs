using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment_API.Data.Models;
using SchoolManagment_API.Services;
using SchoolManagment_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using System.Security.Claims;
namespace SchoolManagment_API.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;
      
        public ClassesController(IClassService classService)
        {
            _classService = classService;
           
        }


        
        [HttpGet("Classes")]
        public async Task<ActionResult<IEnumerable<Class>>> GetAllClasses()
        {
            
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
               

                var sID = User.Claims.FirstOrDefault(c => c.Type.Equals("schoolId"));
                if (sID == null || sID.Value == "")
                    return BadRequest("This User not Assign for any School");

                IEnumerable<Class> classes = await _classService.GetAllClassesForSchool(int.Parse(sID.Value));

                if (classes == null || classes.Count() == 0)
                    return NotFound("School not found");
                return Ok(classes.ToList());
            }
            return NotFound("Claims Not Found");
        }

        [HttpGet("Class/{classId}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<Class>> GetClassByID(int classId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sID = User.Claims.FirstOrDefault(c => c.Type.Equals("schoolId"));
            if (sID == null || sID.Value == "")
                return Unauthorized("This User not Assign for any School");

            if(classId == 0)
                return BadRequest("Invalid Value For ClassId");
            
            var @class = await _classService.GetClassByID(classId);

            if (@class == null )
                return NotFound("Class not found");

            if (@class.schoolId != int.Parse(sID.Value))
                return Unauthorized("Access Denayed, You Dont Have Permission to Access This Class");
            
            return Ok(@class);
        }


       [Authorize(Roles = "Admin")]
        [HttpPost("AddClass")]
        public async Task<ActionResult> CreateClass([FromBody] ClassDTO @class)
        {
            //ModelState.IsValid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var sID = User.Claims.FirstOrDefault(c => c.Type.Equals("schoolId"));
                if (sID == null || sID.Value == "")
                    return Unauthorized("This User not Assign for any School So Can't Create The class");

                if (await _classService.CheckClassIsAlreadyExist(@class.className,int.Parse(sID.Value)))
                    return Conflict("This Class Is Already Exist ");
               
                var result = await _classService.AddClass(@class.className, @class.floor, int.Parse(sID.Value));
                
                if (result == null)
                    return BadRequest("School is Not Exist or this Class is Already Exist ");

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteClass/{classID}")]
        public async Task<ActionResult> DeleteClass(int classID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sID = User.Claims.FirstOrDefault(c => c.Type.Equals("schoolId"));
            if (sID == null || sID.Value == "")
                return Unauthorized("This User not Assign for any School, so Can't Delete it");

            if (classID == 0)
                return BadRequest("Invalid Value For ClassId");

            var @class = await _classService.GetClassByID(classID);

            if (@class == null)
                return NotFound("Class not found");

            if (@class.schoolId != int.Parse(sID.Value))
                return Unauthorized("Access Denayed, You Don't Have Permission to Access This Class");

            return await _classService.DeleteClass(classID) == true ? Ok("Class Deleted ") : NotFound("This Class Not Found");
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("EditClass/{classId}")]
        public async Task<ActionResult<Class>> UpdateClass(int classId, string name = "", int floor = -1)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (name == "" && floor == -1)
                return BadRequest("New Data Is Empty");

            var sID = User.Claims.FirstOrDefault(c => c.Type.Equals("schoolId"));
            if (sID == null || sID.Value == "")
                return Unauthorized("This User not Assign for any School, so Can't Delete it");

            if (classId == 0)
                return BadRequest("Invalid Value For ClassId");
            
            if (await _classService.CheckClassIsAlreadyExist(name, int.Parse(sID.Value)))
                return Conflict("This Class Is Already Exist ");

            var @class = await _classService.GetClassByID(classId);

            if (@class == null)
                return NotFound("Class not found");

            if (@class.schoolId != int.Parse(sID.Value))
                return Unauthorized("Access Denayed, You Don't Have Permission to Access This Class");


            var result = await _classService.EditClass(@class, name, floor);
            return result != null ? Ok(result) : BadRequest("this class not Found or Alresdy Exist");

        }



    }
}
