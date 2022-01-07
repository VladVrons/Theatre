using BLL.DTO;
using BLL.Servises;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using Xunit;

namespace ToD.Tests
{
    public class DALTest
    {

        public DALTest() { }

        [Theory]
        [InlineData(1)]
        public void TakesIdShouldReturnName(int id)
        {
            ShowContext db = new ShowContext("DefaultConnection");
            ShowRepository showrepo= new ShowRepository(db);
            Show show = showrepo.Get(id);
            Assert.Equal("Hamlet", show.Name);
        }

        [Fact]
        public void tetstest()
        {
            Assert.Equal("1", "1");
        }

       

    }
}
