using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.EF
{
    public class ShowContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        static ShowContext()
        {
            Database.SetInitializer<ShowContext>(new ShowDbInitializer());
        }
        public ShowContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class ShowDbInitializer : DropCreateDatabaseIfModelChanges<ShowContext>
    {
        protected override void Seed(ShowContext db)
        {
            db.Shows.Add(new Show { id = 1, Name = "Hamlet", Author = "W.Shakespeare", Genre = "Drama", Date = new DateTime(2008, 3, 1, 7, 0, 0), Size = 400 }); ;
            db.Shows.Add(new Show { id = 2, Name = "Romeo and Juliet", Author = "W.Shakespeare", Genre = "Tragedy", Date = new DateTime(2008, 3, 1, 7, 0, 0), Size = 400 });
            db.Shows.Add(new Show { id = 3, Name = "The Nutcracker", Author = "E.Hofman", Genre = "Drama", Date = new DateTime(2008, 3, 1, 7, 0, 0), Size = 400 });
            db.Shows.Add(new Show { id = 4, Name = "Inferno", Author = "R.Castellucci ", Genre = "Drama", Date = new DateTime(2008, 3, 1, 7, 0, 0), Size = 400});
            db.Tickets.Add(new Ticket { showid = 1, Seat = 5, Price = 200, Status = 0 });
            db.SaveChanges();
        }
    }
}
