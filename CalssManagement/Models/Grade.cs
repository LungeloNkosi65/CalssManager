using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CalssManagement.Models
{
    public class Grade
    {
        [Key]

        public String GradeId{ get; set; }
        public string GradeNamne { get; set; }
       // [Required,("This field is required")]
        [Range(25,50)]
        public int NumberOfStudents { get; set; }
    }
}
