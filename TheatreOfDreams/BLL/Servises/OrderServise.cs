using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
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
            show.Tickets = (List<Ticket>)Database.Tickets.GetFrom1Show1(showId);
            show.Tickets[seat].Status = 1;
            
            Database.Tickets.Update(show.Tickets[seat]);
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
            
            show.Tickets[seat].Status = 2;
            
            Database.Tickets.Update(show.Tickets[seat]);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
