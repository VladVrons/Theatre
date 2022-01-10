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
    public class ShowRepository : IRepository<Show>
    {
        private ShowContext db;

        public ShowRepository(ShowContext context)
        {
            this.db = context;
            
        }

        public IEnumerable<Show> GetAll()
        {
            return db.Shows;
        }

        public Show Get(int id)
        {
            return db.Shows.Find(id);
        }

        public void Create(Show show)
        {
            db.Shows.Add(show);
        }

        public void Update(Show show)
        {
            db.Entry(show).State = EntityState.Modified;
        }
        public IEnumerable<Show> Find(Func<Show, Boolean> predicate)
        {
            return db.Shows.Include(o => o.Tickets).Where(predicate).ToList();
        }
        public void Delete(int name)
        {
            Show show = db.Shows.Find(name);
            if (show != null)
                db.Shows.Remove(show);
        }

        public IEnumerable<Ticket> GetFrom1Show1(int id)
        {
            TicketRepository trep = new TicketRepository(db);
            return trep.GetFrom1Show1(id);
        }

    }
}
