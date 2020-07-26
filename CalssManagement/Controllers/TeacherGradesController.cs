using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalssManagement.Models;

namespace CalssManagement.Controllers
{
    public class TeacherGradesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherGrades
        public ActionResult Index()
        {
            var teacherGrades = db.TeacherGrades.Include(t => t.Grade).Include(t => t.Teacher);
            return View(teacherGrades.ToList());
        }

        // GET: TeacherGrades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherGrade teacherGrade = db.TeacherGrades.Find(id);
            if (teacherGrade == null)
            {
                return HttpNotFound();
            }
            return View(teacherGrade);
        }

        // GET: TeacherGrades/Create
        public ActionResult Create()
        {
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName");
            return View();
        }

        // POST: TeacherGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherGradeId,TeacherId,GradeId")] TeacherGrade teacherGrade)
        {
            if (ModelState.IsValid)
            {
                if (teacherGrade.CheckIfExists()==true)
                {
                    ModelState.AddModelError("", "You can not assign the same teacher to the same class twice");
                    ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", teacherGrade.GradeId);
                    ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", teacherGrade.TeacherId);
                    return View(teacherGrade);
                }
                else
                {
                    db.TeacherGrades.Add(teacherGrade);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
             
            }

            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", teacherGrade.GradeId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", teacherGrade.TeacherId);
            return View(teacherGrade);
        }

        // GET: TeacherGrades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherGrade teacherGrade = db.TeacherGrades.Find(id);
            if (teacherGrade == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", teacherGrade.GradeId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", teacherGrade.TeacherId);
            return View(teacherGrade);
        }

        // POST: TeacherGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherGradeId,TeacherId,GradeId")] TeacherGrade teacherGrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherGrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", teacherGrade.GradeId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", teacherGrade.TeacherId);
            return View(teacherGrade);
        }

        // GET: TeacherGrades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherGrade teacherGrade = db.TeacherGrades.Find(id);
            if (teacherGrade == null)
            {
                return HttpNotFound();
            }
            return View(teacherGrade);
        }

        // POST: TeacherGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherGrade teacherGrade = db.TeacherGrades.Find(id);
            db.TeacherGrades.Remove(teacherGrade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
