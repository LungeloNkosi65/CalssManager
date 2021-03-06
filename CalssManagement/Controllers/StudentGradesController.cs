﻿using System;
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
    public class StudentGradesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentGrades
        public ActionResult Index()
        {
            var studentGrades = db.StudentGrades.Include(s => s.Grade).Include(s => s.Student);
            return View(studentGrades.ToList());
        }

        // GET: StudentGrades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGrade studentGrade = db.StudentGrades.Find(id);
            if (studentGrade == null)
            {
                return HttpNotFound();
            }
            return View(studentGrade);
        }

        // GET: StudentGrades/Create
        public ActionResult Create()
        {
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: StudentGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentGradeID,StudentId,GradeId")] StudentGrade studentGrade)
        {
            if (ModelState.IsValid)
            {
                if (studentGrade.CheckIfEixists() == true)
                {
                    ModelState.AddModelError("", "You can not add the same student twice");
                    ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", studentGrade.GradeId);
                    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", studentGrade.StudentId);
                    return View(studentGrade);
                }
                else
                {
                    db.StudentGrades.Add(studentGrade);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
          
            }

            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", studentGrade.GradeId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", studentGrade.StudentId);
            return View(studentGrade);
        }

        // GET: StudentGrades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGrade studentGrade = db.StudentGrades.Find(id);
            if (studentGrade == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", studentGrade.GradeId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", studentGrade.StudentId);
            return View(studentGrade);
        }

        // POST: StudentGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentGradeID,StudentId,GradeId")] StudentGrade studentGrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentGrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeNamne", studentGrade.GradeId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", studentGrade.StudentId);
            return View(studentGrade);
        }

        // GET: StudentGrades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGrade studentGrade = db.StudentGrades.Find(id);
            if (studentGrade == null)
            {
                return HttpNotFound();
            }
            return View(studentGrade);
        }

        // POST: StudentGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentGrade studentGrade = db.StudentGrades.Find(id);
            db.StudentGrades.Remove(studentGrade);
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
