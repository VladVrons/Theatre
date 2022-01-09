using DAL.EF;
using DAL.Entities;
using DAL.Repositories;
using Xunit;

namespace ToD.Tests
{
    public class DALTest
    {

        public DALTest() { }

        [Theory]
        [InlineData(1)]
        public void TakesId_ShouldReturnName(int id)
        {
            ShowContext db = new ShowContext("DefaultConnection");
            ShowRepository showrepo= new ShowRepository(db);
            Show show = showrepo.Get(id);
            Assert.Equal("Hamlet", show.Name);
        }

        [Fact]
        public void ShowRepo_CreatesNewShow()
        {
            ShowContext db = new ShowContext("DefaultConnection");
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
            ShowContext db = new ShowContext("DefaultConnection");
            ShowRepository showrepo = new ShowRepository(db);
            Show show = showrepo.Get(3);
            show.Author = "Me";
            showrepo.Update(show);
            db.SaveChanges();
            Assert.Equal("Me", showrepo.Get(3).Name);
        }

    }
}
