using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolManagment_API.Data.Models
{
    public class School
    {
        public int id { get; set; }
        
        [Required,MaxLength(150)]
        public string name { get; set; }

        [Phone]
        public string phone { get; set; }
        [MaxLength(250)]
        public string address { get; set; }

        
        public ICollection<Class> classes { get; set; }
    }
}
