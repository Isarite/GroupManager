
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
        public ActionResult Details(int id)
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
        public ActionResult Create([Bind(Include = "Title,Director,Description,Country")] Book book)
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
        public ActionResult Edit(int id)
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
        public ActionResult Edit([Bind(Include = "Title,Director,Description,Country")] Book book)
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
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Reserve(int id)
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
                return RedirectToAction("Index");
            }
            else
                return HttpNotFound();
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
		
		public void Extend(  )
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
