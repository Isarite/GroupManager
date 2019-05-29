using Microsoft.AspNet.Identity.EntityFramework;
using Invensa.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

namespace Invensa.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<InventoryItem> InventoryItems { get; set; }
        //public DbSet<ServiceItem> ServiceItems { get; set; }

        //public DbSet<InventoryItemCategory> InventoryItemCategories { get; set; }

        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<Invoice> Invoices { get; set; }

        //public DbSet<OrderedInventoryItem> OrderedInventoryItems { get; set; }
        //public DbSet<OrderedServiceItem> OrderedServiceItems { get; set; }

        //public DbSet<MM_InventoryItem_Category> MmInventoryItemCategories { get; set; }

        //public DbSet<Country> Countries { get; set; }

        //public DbSet<Discount> Discounts { get; set; }
        //public DbSet<Feedback> Feedback { get; set; }

        //public DbSet<Report> Reports { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Company> Companies { get; set; }
        //public DbSet<File> Files { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<User> Users{ get; set; }

        public ApplicationDbContext() : base("ApplicationDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Feedback>()
            //    .HasKey(k => new { k.ItemId, k.UserId });
            //modelBuilder.Entity<MM_InventoryItem_Category>()
            //    .HasKey(k => new { k.InventoryItemId, k.UserId });
            //modelBuilder.Entity<OrderedInventoryItem>()
            //    .HasKey(k => new { k.CartId, k.ItemId });
            //modelBuilder.Entity<OrderedServiceItem>()
            //    .HasKey(k => new { k.CartId, k.ServiceId });
            //modelBuilder.Entity<Cart>()
            //    .HasMany(o => o.OrderedServiceItems)
            //    .WithOne(o => o.Cart);
            //modelBuilder.Entity<Cart>()
            //    .HasMany(o => o.OrderedInventoryItems)
            //    .WithOne(o => o.Cart);
            
            modelBuilder.Entity<Company>().HasKey(k => k.Title);
            modelBuilder.Entity<Participant>().HasKey(k => k.Id);
            modelBuilder.Entity<Protocol>().HasKey(k => k.Date);
            modelBuilder.Entity<Question>().HasKey(k => k.Id);
            modelBuilder.Entity<Questionnaire>().HasKey(k => k.Id);
            modelBuilder.Entity<Report>().HasKey(k => k.Id);
            modelBuilder.Entity<Reservation>().HasKey(k => k.Id);
            modelBuilder.Entity<Review>().HasKey(k => k.Id);
            modelBuilder.Entity<Solution>().HasKey(k => k.Id);
            modelBuilder.Entity<User>().HasKey(k => k.Id);
            modelBuilder.Entity<Book>().HasKey(k => k.Title);


            modelBuilder.Entity<Solution>().HasMany(o => o.affected_users).WithMany(o => o.Solutions);






            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}