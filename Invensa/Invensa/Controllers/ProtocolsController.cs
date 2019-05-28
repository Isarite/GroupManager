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

namespace Invensa.Controllers
{
    public class ProtocolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Protocols
        public ActionResult Index()
        {
            return View(db.Protocols.ToList());
        }

        // GET: Protocols/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protocol protocol = db.Protocols.Find(id);
            if (protocol == null)
            {
                return HttpNotFound();
            }
            return View(protocol);
        }

        // GET: Protocols/Create
        public ActionResult Create()
        {
            Protocol protocol = new Protocol();
            protocol.Questions = new List<Question>();
            protocol.Solutions = new List<Solution>();
            protocol.Participants = new List<Participant>();
            protocol.Date = DateTime.Now;
            ViewBag.Users = db.Users;

            return View(protocol);
        }

        // POST: Protocols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,Quorum,Participants,Solutions,Questions")] Protocol protocol, ICollection<int> newParticipants)
        {
            if (ModelState.IsValid)
            {
                var solutions = db.Solutions.Where(s => s.protocol == null).ToList();
                if (protocol.Solutions == null)
                    protocol.Solutions = new List<Solution>();
                foreach (Solution s in solutions)
                    protocol.Solutions.Add(s);
                protocol.Participants = new List<Participant>();
                protocol.Participants.Add(new Participant { user = currentUser(), Date = protocol.Date, Role = "Protokolinikas" });
                List<User> users = db.Users.Where(u => newParticipants.Contains(u.Id)).ToList();
                foreach (User u in users)
                    protocol.Participants.Add(new Participant { user = u, Date = protocol.Date, Role = "Dalyvis" });
                db.Protocols.Add(protocol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(protocol);
        }

        User currentUser()
        {
            return db.Users.FirstOrDefault();
        }

        public PartialViewResult ListQuestions()
        {           
            return PartialView("ListQuestions", db.Questions.Where(s => s.protocol == null).ToList());
        }

        // GET: Protocols/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protocol protocol = db.Protocols.Find(id);
            if (protocol == null)
            {
                return HttpNotFound();
            }
            return View(protocol);
        }

        // POST: Protocols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,Quorum")] Protocol protocol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protocol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(protocol);
        }

        // GET: Protocols/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protocol protocol = db.Protocols.Find(id);
            if (protocol == null)
            {
                return HttpNotFound();
            }
            return View(protocol);
        }

        // POST: Protocols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            Protocol protocol = db.Protocols.Find(id);
            db.Protocols.Remove(protocol);
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

        public void OpenProtocolCreation()
        {

        }

        public void GenerateProtocol()
        {

        }

        public void GenerateProtocolText()
        {

        }
    }
}
