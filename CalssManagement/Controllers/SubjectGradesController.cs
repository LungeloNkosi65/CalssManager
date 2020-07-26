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
    public class SubjectGradesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectGrades
        public ActionResult Index()
        {
            var subjectGrades = db.SubjectGrades.Include(s => s.Grade).Include(s => s.Subjects);
            return View(subjectGrades.ToList());
        }

        // GET: SubjectGrades/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGrade subjectGrade = db.SubjectGrades.Find(id);
            if (subjectGrade == null)
            {
                return HttpNotFound();
            }
            return View(subjectGrade);
        }

        // GET: SubjectGrades/Create
        public ActionResult Create()
        {
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: SubjectGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectGradeId,GradeId,SubjectId")] SubjectGrade subjectGrade)
        {
            if (ModelState.IsValid)
            {
                if (subjectGrade.CheckIfExits() == true)
                {
                    ModelState.AddModelError("", "You can not add the same subject twice");
                    ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", subjectGrade.GradeId);
                    ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", subjectGrade.SubjectId);
                    return View(subjectGrade);
                }
                db.SubjectGrades.Add(subjectGrade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", subjectGrade.GradeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", subjectGrade.SubjectId);
            return View(subjectGrade);
        }

        // GET: SubjectGrades/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGrade subjectGrade = db.SubjectGrades.Find(id);
            if (subjectGrade == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", subjectGrade.GradeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", subjectGrade.SubjectId);
            return View(subjectGrade);
        }

        // POST: SubjectGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectGradeId,GradeId,SubjectId")] SubjectGrade subjectGrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectGrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", subjectGrade.GradeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", subjectGrade.SubjectId);
            return View(subjectGrade);
        }

        // GET: SubjectGrades/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGrade subjectGrade = db.SubjectGrades.Find(id);
            if (subjectGrade == null)
            {
                return HttpNotFound();
            }
            return View(subjectGrade);
        }

        // POST: SubjectGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SubjectGrade subjectGrade = db.SubjectGrades.Find(id);
            db.SubjectGrades.Remove(subjectGrade);
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
