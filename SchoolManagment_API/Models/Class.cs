using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolManagment_API.Data.Models
{

    public class Class
    {
        public int id { get; set; }

        [Required, MaxLength(150)]
        public string name { get; set; }

        public int floor { get; set; }
        [Required]
        public int schoolId { get; set; }

        
        public School school { get; set; }
    }
}
