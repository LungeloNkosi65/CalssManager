using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalssManagement.Models
{
    public class Teacher
    {
        [Key]
        public string TeacherId  { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname{ get; set; }
        [EmailAddress]
        public string TeacherEmail { get; set; }
    }
}
