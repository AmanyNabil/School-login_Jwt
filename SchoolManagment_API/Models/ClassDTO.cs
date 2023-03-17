using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment_API.Models
{
    public class ClassDTO
    {
       
        [Required]
        public string className { get; set; }
        [Required]
        public int floor { get; set; }
      

    }
}
