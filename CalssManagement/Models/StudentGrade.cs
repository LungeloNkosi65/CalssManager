using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalssManagement.Models
{
    public class StudentGrade
    {
       
        public int StudentGradeID { get; set; }
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        ApplicationDbContext db = new ApplicationDbContext();

        public bool CheckIfEixists()
        {
            bool result = false;
            var dbRecord = db.StudentGrades;
            foreach (var item in dbRecord)
            {
                if(item.StudentId==StudentId && item.GradeId == GradeId)
                {
                    result =true;
                }
            }
            return result;
        }
    }
}
