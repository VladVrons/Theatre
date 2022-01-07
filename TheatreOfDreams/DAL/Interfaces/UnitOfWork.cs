using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Show> Shows { get; }
        IRepository<Ticket> Tickets { get; }
        void Save();
    }
}
