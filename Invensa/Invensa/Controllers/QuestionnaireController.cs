using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Invensa.Data;
using Invensa.Models;
using System.Web.UI;

namespace Invensa.Controllers
{
    public class QuestionnaireController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Questionnaire
        public ActionResult Index()
        {
            return View(db.Questionnaires.ToList());
        }

        // GET: Questionnaire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        // GET: Questionnaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questionnaire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AcademicGroup,Reason,Answers,User")] Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                questionnaire.Date = DateTime.Now;
                questionnaire.user.status = Status.Candidate;
                db.Questionnaires.Add(questionnaire);
                db.Users.Add(questionnaire.user);
                db.SaveChanges();
                TempData["message"] = "Anketa išsiųsta sėkmingai";


                return RedirectToAction("Index");
            }

            ViewBag.User = new User();

            return View(questionnaire);
        }


        // GET: Questionnaire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        // POST: Questionnaire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AcademicGroup,Reason,Answers,Date")] Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionnaire);
        }

        // GET: Questionnaire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        // POST: Questionnaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            db.Questionnaires.Remove(questionnaire);
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

    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
}
