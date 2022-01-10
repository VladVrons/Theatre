using DAL.EF;
using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System.Data.Entity;

namespace ToD.Tests
{
    public class DALTest
    {
        public ShowContext db = new ShowContext("DefaultConnection");
        public DALTest() { }

        [Theory]
        [InlineData(1)]
        public void TakesId_ShouldReturnName(int id)
        {
          
            ShowRepository showrepo= new ShowRepository(db);
            Show show = showrepo.Get(id);
            Assert.Equal("Hamlet", show.Name);
        }

        [Fact]
        public void ShowRepo_CreatesNewShow()
        {
           
            ShowRepository showrepo = new ShowRepository(db);
            Show show = new Show
            {
                id = 7,
                Name = "Christmas Show",
                Genre = "Comedy",
            };
            showrepo.Create(show);
            Assert.Equal("Christmas Show", showrepo.Get(7).Name);
        }

        [Fact]
        public void ShowRepo_UpdateShowINDatabase()
        {
            ShowRepository showrepo = new ShowRepository(db);
            Show show = showrepo.Get(3);
            show.Author = "Me";
            showrepo.Update(show);
            db.SaveChanges();
            Assert.Equal("Me", showrepo.Get(3).Author);
        }

        [Fact]
        public void ShowRepo_GetAllShows()
        {            
            ShowRepository showrepo = new ShowRepository(db);
            var shows = showrepo.GetAll();
            //List<Ticket> t = tickets.ToList();
            Assert.Equal(4, shows.Count());
        }

        [Fact]
        public void TicketRepo_GetAllTickets()
        {
           
            TicketRepository ticketrepo = new TicketRepository(db);

            //List<Ticket> t = tickets.ToList();
            db.Dispose();
            Assert.Equal(0,ticketrepo.GetAll().Count());
        }

        [Fact]
        public void CreateNewTicket()
        {
           
            TicketRepository ticketrepo = new TicketRepository(db);
            ticketrepo.Create(new Ticket { showid = 1, Price = 200, Seat = 2, Status = 2 });

            Assert.Equal(2, ticketrepo.GetAll().Count());
        }

        [Fact]
        public void ShowRepo_GetAllTicketsFrom1Show()
        {
            TicketRepository showrepo = new TicketRepository(db);
            var tickets = showrepo.GetFrom1Show1(1);
            List<Ticket>t = tickets.ToList();
            
            Assert.Equal(3, tickets.Count());
        }

    }
}
