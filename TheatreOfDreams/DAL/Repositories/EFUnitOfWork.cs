using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ShowContext db;
        private ShowRepository showRepository;
        private TicketRepository ticketRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ShowContext(connectionString);
        }
        public IRepository<Show> Shows
        {
            get
            {
                if (showRepository == null)
                    showRepository = new ShowRepository(db);
                return showRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(db);
                return ticketRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
