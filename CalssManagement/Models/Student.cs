using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CalssManagement.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
    }
}
