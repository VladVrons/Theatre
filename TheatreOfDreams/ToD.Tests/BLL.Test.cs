using BLL.Servises;
using BLL.Struct;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;

namespace ToD.Tests
{
    public class BLLTest
    {
        //public ShowContext db = new ShowContext("Connection");

        [Theory]
        [InlineData(1, 3)]
        public void BookTicket_GetsIdandSeat_TakesStatus(int showid, int Seat)
        {
           
            IUnitOfWork uow = new EFUnitOfWork("Connection1");
            IOrderService orderService = new OrderService(uow);
            var showDto = orderService.GetShow(showid);
            orderService.BookTicket(showDto.id, Seat);

            showDto.Tickets = (IEnumerable<DAL.Entities.Ticket>)uow.Tickets.GetFrom1Show1(showid);
            var t = showDto.Tickets.Where(x => x.Seat == Seat).First();
            Assert.Equal(1,t.Status);
        }

        [Theory]
        [InlineData(1, 3)]
        public void BuyTicket_GetsIdandSeat_TakesStatus(int showid, int Seat)
        {

            IUnitOfWork uow = new EFUnitOfWork("Connection1");
            IOrderService orderService = new OrderService(uow);
            var showDto = orderService.GetShow(showid);
            orderService.BookTicket(showDto.id, Seat);

            showDto.Tickets = (IEnumerable<DAL.Entities.Ticket>)uow.Tickets.GetFrom1Show1(showid);
            var t = showDto.Tickets.Where(x => x.Seat == Seat).First();
            Assert.Equal(1, t.Status);
        }
    }
}
