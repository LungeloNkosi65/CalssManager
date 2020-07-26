using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CalssManagement.Models
{
    public class Subjects
    {
        [Key]
        public String SubjectId { get; set; }
        public String SubjectName { get; set; }
        public double Mark { get; set; }
    }
}
