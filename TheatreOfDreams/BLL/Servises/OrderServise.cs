using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Servises
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void BookTicket(int showId, int seat)
        {
            Show show = Database.Shows.Get(showId);
           
            if (show == null)
                throw new ValidationException("Шоу не найдено", "");
            
            show.Tickets = Database.Tickets.GetFrom1Show1(showId);
            var ticket = show.Tickets.Where(x => x.Seat == seat).First();
            if (ticket.Status == 1)
                throw new ValidationException("Шоу уже забронировано", "");
            ticket.Status = 1;
            Database.Tickets.Update(ticket);
            Database.Save();
        }

        public IEnumerable<ShowDTO> GetShows()
        {
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Show, ShowDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Show>, List<ShowDTO>>(Database.Shows.GetAll());
        }
        
        public ShowDTO GetShow(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id ", "");
            var show = Database.Shows.Get(id.Value);
            if (show == null)
                throw new ValidationException("Шоу не найдено", "");

            return new ShowDTO { Author = show.Author, id = show.id, Genre = show.Genre, Name = show.Name, Size = show.Size };
        }
        public void BuyTicket(int showId, int seat)
        {
            Show show = Database.Shows.Get(showId);

            if (show == null)
                throw new ValidationException("Шоу не найдено", "");

            show.Tickets = Database.Tickets.GetFrom1Show1(showId);
            var ticket = show.Tickets.Where(x => x.Seat == seat).First();
            if (ticket.Status == 2)
                throw new ValidationException("Шоу уже куплено ", "");
            ticket.Status = 2;
            Database.Tickets.Update(ticket);
            Database.Save();
        }

        public IEnumerable<TicketDTO> GetTickets(int? showid)
        {
            int showID = (int)showid;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.Tickets.GetFrom1Show1(showID));
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        
    }
}
