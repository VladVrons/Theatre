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
        public ShowContext db = new ShowContext("Connection");
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
            Assert.Equal(5,ticketrepo.GetAll().Count());
        }

        [Fact]
        public void CreateNewTicket()
        {
            TicketRepository ticketrepo = new TicketRepository(db);
            Ticket ticket = new Ticket
            {
                showid = 2,
                Price = 250,
                Seat = 8,
                Status = 0
            };
            ticketrepo.Create(ticket);
            Assert.Equal(250, ticketrepo.Get(8).Price);
        }

        [Fact]
        public void ShowRepo_GetAllTicketsFrom1Show()
        {
            TicketRepository ticketrepo = new TicketRepository(db);
            Ticket ticket = new Ticket
            {
                showid = 2,
                Price = 250,
                Seat = 8,
                Status = 0
            };
            ticketrepo.Create(ticket);
            var tickets = ticketrepo.GetFrom1Show1(1);
            Assert.Equal(5, tickets.Count());
        }

    }
}
