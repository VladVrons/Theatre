using BLL.Servises;
using BLL.Struct;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using System.Web.Mvc;
using Xunit;

namespace ToD.Tests
{
    public class BLLTest
    {
        [Theory]
        [InlineData(1, 5)]
        public void BookTicket_AndCheck_UnitOfWork(int showid, int Seat)
        {
            IUnitOfWork uow = new EFUnitOfWork("Connection");
            IOrderService orderService = new OrderService(uow);
            var showDto = orderService.GetShow(showid);
            orderService.BookTicket(showDto.id, Seat);
           
            Assert.Equal(1,showDto.id);
        }
    }
}
