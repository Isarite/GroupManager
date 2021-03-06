﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Invensa.Data;
using Invensa.Models;

namespace Invensa.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult ListCandidates()
        {
            return View(db.Users.Where(t => t.status == Status.Candidate).ToList());
        }

        [HttpPost]
        public ActionResult GrantMembership(IEnumerable<int> candidateIds)
        {
            foreach (var item in candidateIds)
            {
                User grant = db.Users.FirstOrDefault(s => s.Id == item);
                if (grant != null)
                {
                    grant.status = Status.Member;
                    grant.password = Membership.GeneratePassword(12, 1);
                    string password = grant.password;
                    string nameTo = grant.email;
                    TempData["message"] = "Kandidatai priimti sėkmingai";
                    db.SaveChanges();
                    //SendEmail(nameTo,password);
                }
            }
            db.SaveChanges();
            CreateNewUserDecision(candidateIds);
            return RedirectToAction("Index");
        }

        void CreateNewUserDecision(IEnumerable<int> candidateIds)
        {
            Solution solution = new Solution();
            solution.Description = "Pridėti nariai:";
            if (solution.affected_users == null)
                solution.affected_users = new List<User>();
            foreach (var item in candidateIds)
            {
                User affected = db.Users.FirstOrDefault(s => s.Id == item);           
                solution.affected_users.Add(affected);
            }
            solution.Type = "Narių pridėjimas";
            db.Solutions.Add(solution);
            db.SaveChanges();
        }
        string domain= "mail.Invensa.ktu.edu";
        string credentials= "info@Invensa.ktu.edu";
        string mailPassword= "password";
        string name = "info@Invensa";

        public Task SendEmail(string nameTo, string password)
        {
            return Task.Run(() =>
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient(domain, 25);

                    smtpClient.Credentials = new System.Net.NetworkCredential(credentials, mailPassword);
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    MailMessage mail = new MailMessage();

                    //Setting From , To
                    mail.From = new MailAddress(name, "Invensa");
                    mail.To.Add(new MailAddress(nameTo));
                    mail.Body = "Sveikiname, jūs tapote Invensa grupės nariu\n Jūsų slaptažodis yra: " + password;
                    smtpClient.Send(mail);
                }
                catch (SmtpFailedRecipientException ex)
                {
                    SendEmail(nameTo, password);
                }
            });
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,surname,email,status,password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,surname,email,status,password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);           
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

        public void ViewQuestionnaires()
        {

        }

        public void ViewQuestionnaire()
        {

        }

        public void ListUsers()
        {

        }

        public void ViewUsers()
        {

        }

        public void OpenUserList()
        {

        }

        public void openQuestionnaires()
        {

        }

        public void OpenQuestionnaire()
        {

        }

        public void changeUserStatus()
        {

        }

        public void Login()
        {

        }

        public void PrintQuestionnaire()
        {

        }

        public void LogOut()
        {

        }

        public void EndSession()
        {

        }

        public void OpenCandidateList()
        {

        }

        public void GrantMembership()
        {

        }

        public void OpenQuestionnaireCreation()
        {

        }

        public void SubmitQuestionnaire()
        {

        }

        public void ValidateQuestionnaire()
        {

        }
    }
}
