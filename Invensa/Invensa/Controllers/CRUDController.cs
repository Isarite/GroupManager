
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Invensa.Data;
using Invensa.Models;
/**
* @(#) CRUD.cs
*/
namespace Invensa.Library.Controllers
{
    

    public class CRUDController:Controller
	{
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Author,Quantity,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Title,Author,Quantity,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Comment(string id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookId = id;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment([Bind(Include = "Text")] Review review, string bookId)
        {
            review.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                Book book = db.Books.First(b => b.Title == bookId);
                if (book.reviews == null)
                    book.reviews = new List<Review>();
                book.reviews.Add(review);
                db.Entry(book).State = EntityState.Modified;
                User user = db.Users.First();
                if (user.Reviews == null)
                    user.Reviews = new List<Review>();
                user.Reviews.Add(review);
                db.SaveChanges();
                TempData["message"] = "Sėkmingai išsaugotas komentaras";
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Reserve(string id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            int count = book.Quantity;
            if (count > 0)
            {
                Reservation reservation = new Reservation();
                reservation.Date = DateTime.Now;
                reservation.ReturnDate = DateTime.Now.AddMonths(1);
                reservation.IsReturned = false;
                if (book.reservations == null)
                    book.reservations = new List<Reservation>();
                book.reservations.Add(reservation);
                User user = db.Users.FirstOrDefault();
                if (user.Reservations == null)
                    user.Reservations = new List<Reservation>();
                user.Reservations.Add(reservation);
                book.Quantity--;
                db.SaveChanges();
                TempData["message"] = "Sėkmingai rezervuota knyga";
                return RedirectToAction("Index");
            }
            else
                return HttpNotFound();
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Extend(string id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            User user = db.Users.FirstOrDefault();
            if (user.Reservations != null)
            {
                List<Reservation> reservations = book.reservations.ToList();
                Reservation reservation = user.Reservations.Where(r => reservations.Contains(r)).First();
                if (reservation == null)
                    return HttpNotFound();
                reservation.Date.AddMonths(1);
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Sėkmingai pratęsta rezervacija";
                return RedirectToAction("Index");
            }
             return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public void OpenBookList(  )
		{
			
		}
		
		public void OpenReview(  )
		{
			
		}
		
		public void SubmitReview(  )
		{
			
		}
		
		public void CheckAvailableBooksCount(  )
		{
			
		}

		
		public void OpenMoreInfo(  )
		{
			
		}
		
		public void EditBook(  )
		{
			
		}
		
		public void SubmitChangedInfo(  )
		{
			
		}
		
		public void ClickCreateBook(  )
		{
			
		}
		
		public void CheckInfo(  )
		{
			
		}
		
		public void DeleteBook(  )
		{
			
		}
		
	}
	
}
