using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalssManagement.Models
{
    public class TeacherGrade
    {
        [Key]
        public int  TeacherGradeId { get; set; }
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public string GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        ApplicationDbContext db = new ApplicationDbContext();
        
        public bool CheckIfExists()
        {
            bool result = false;
            var dbRecord = db.TeacherGrades;

            foreach(var item in dbRecord)
            {
                if(item.TeacherId==TeacherId && item.GradeId == GradeId)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
