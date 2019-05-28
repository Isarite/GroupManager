using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
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

            return File(Encoding.UTF8.GetBytes(GenerateProtocolText(protocol)),
                 "text/plain",
                  string.Format("protocol_{0}.txt", protocol.Date));
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
                foreach (Solution s in protocol.Solutions)
                    s.Type = "normal";
                foreach (Solution s in solutions)               
                    protocol.Solutions.Add(s);
                
                protocol.Participants = new List<Participant>();
                protocol.Participants.Add(new Participant { user = currentUser(), Date = protocol.Date, Role = "Protokolinikas" });
                List<User> users = db.Users.Where(u => newParticipants.Contains(u.Id)).ToList();
                foreach (User u in users)
                    protocol.Participants.Add(new Participant { user = u, Date = protocol.Date, Role = "Dalyvis" });
                db.Protocols.Add(protocol);
                db.SaveChanges();
                string protocolText = GenerateProtocolText(protocol);
                return File(Encoding.UTF8.GetBytes(protocolText),
                 "text/plain",
                  string.Format("protocol_{0}.txt", protocol.Date));
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

        public string GenerateProtocolText(Protocol protocol)
        {
            string result = "";
            result += string.Format("Valdybos, susirinkusios {0}\r\n\r\n            PROTOKOLAS\r\n",protocol.Date.ToShortDateString());
            result += "\r\n";
            User protocoller = protocol.Participants.Where(p => p.Role == "Protokolinikas").First().user;
            result += string.Format("Posėdžio pirmininkas: {0} {1}\r\n", protocoller.name, protocoller.surname);
            result += "\r\n";
            result += "Posėdžio dalyviai:\r\n";
            result += "\r\n";
            int i = 1;
            foreach (Participant participant in protocol.Participants)
            {
                if (participant.Role == "Dalyvis")
                {
                    string Role = "";
                    switch (participant.user.status)
                    {
                        case Status.Supervisor:
                            Role = "Valdybos narys";
                            break;
                        case Status.Member:
                            Role = "Narys";
                            break;
                        case Status.Newbie:
                            Role = "Naujas narys";
                            break;
                        case Status.Candidate:
                            Role = "Kandidatas";
                            break;
                    }
                    result += string.Format("   {0}. {1} {2} - {3}\r\n", i,participant.user.name, participant.user.surname, Role);
                }
                else if (participant.Role != "Protokolinikas")
                    result += string.Format("   {0}. {1} {2} - {3}\r\n", i,participant.user.name, participant.user.surname, participant.Role);
                i++;
            }
            result += "\r\n";
            result += protocol.Quorum ? "Kvorumas yra, sprendimai galiojantys.\r\n" : "Kvorumo nėra, sprendimai negaliojantys.\r\n";
            result += "\r\n";
            result += "KLAUSIMAI:\r\n";
            result += "\r\n";
            i = 1;
            foreach (Question question in protocol.Questions)
            {
                result += i +". "  + question.Content  + "\r\n";
                i++;
            }
            result += "\r\n";
            result += "SPRENDIMAI:\r\n";
            result += "\r\n";
            i = 1;
            List<Solution> added = protocol.Solutions.Where(s => s.Description.Equals("Pridėti nariai:")).ToList();
            List<Solution> removed = protocol.Solutions.Where(s => s.Description.Equals("Pašalinti nariai:")).ToList();
            List<Solution> changed = protocol.Solutions.Where(s => s.Description.Equals("Keistas nario statusas:")).ToList();
            List<Solution> rest = protocol.Solutions.Where(s => !s.Description.Equals("Keistas nario statusas:")
            && !s.Description.Equals("Pridėti nariai:") && !s.Description.Equals("Pašalinti nariai:")).ToList();
            int j = 1;
            if (added.Count > 0)
            {
                result += i + ". " + "Pridėti nauji nariai į klubą:\r\n";
                result += "\r\n";
                foreach (Solution s in added)
                {
                    foreach (User u in s.affected_users)
                    {
                        result += "     "+i + "." + j + ". " + string.Format("{0} {1}\r\n", u.name, u.surname);
                        j++;
                    }
                }
                i++;
                result += "\r\n";
            }
            if (changed.Count > 0 || removed.Count > 0)
            {
                result += i + ". " + "Patvirtinti pokyčiai narių sąraše (ar pereikšti įspėjimai):\r\n";
                result += "\r\n";
                i++;
                j = 0;

                foreach (Solution s in changed)
                {
                    foreach (User u in s.affected_users)
                    {
                        result += "     " + i + "." + j + ". " + string.Format("{0} {1} - {2}\r\n", u.name, u.surname, Enum.GetName(typeof(Status), u.status));
                        j++;
                    }
                }
                foreach (Solution s in removed)
                {
                    foreach (User u in s.affected_users)
                    {
                        result += "     " + i + "." + j + ". " + string.Format("{0} {1} – pašalintas iš klubo veiklos\r\n", u.name, u.surname);
                        j++;
                    }
                }
                result += "\r\n";
            }
            foreach (Solution s in rest)
            {
                result += i + ". " + s.Description + "\r\n";
                result += "\r\n";
                if (s.affected_users!=null)
                    foreach (User u in s.affected_users)
                    {
                        result += "     " + string.Format("{0} {1}\r\n", u.name, u.surname);
                    }
                i++;
            }
            return result;
        }
    }
}
