using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private ShowContext db;

        public TicketRepository(ShowContext context)
        {
            this.db = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets;
        }

        

        public Ticket Get(int seat)
        {
            
            return db.Tickets.Find(seat);
        }

        public void Create(Ticket ticket)
        {
            db.Tickets.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
        }

        public IEnumerable<Ticket> Find(Func<Ticket, Boolean> predicate)
        {
            return db.Tickets.Where(predicate).ToList();
        }

        public void Delete(int seat)
        {
            Ticket ticket = db.Tickets.Find(seat);
            if (ticket != null)
                db.Tickets.Remove(ticket);
        }

        public IEnumerable<Ticket> GetFrom1Show1(int id)
        {
            /*IEnumerable<Ticket> tickets
            = from ticket in db.Tickets
              where ticket.showid == id
              select ticket;*/

            var tickets = db.Tickets.Where(x => x.showid == id);
            return tickets;
        }

    }
}
