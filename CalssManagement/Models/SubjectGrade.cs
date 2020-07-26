using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalssManagement.Models
{
    public class SubjectGrade
    {
        public string SubjectGradeId { get; set; }
        public string GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        public String SubjectId { get; set; }
        public virtual Subjects Subjects { get; set; }
        ApplicationDbContext db = new ApplicationDbContext();

        public bool CheckIfExits()
        {
            bool resut = false;
            var dbRecord = db.SubjectGrades;
            foreach(var item in dbRecord)
            {
                if(item.GradeId==GradeId && item.SubjectId == SubjectId)
                {
                    resut = true;
                }
            }
            return resut;
        }
    }
}
