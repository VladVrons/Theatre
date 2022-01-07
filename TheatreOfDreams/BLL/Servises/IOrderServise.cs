using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Servises
{
    public interface IOrderService
    {
        void BookTicket(int showId, int seat);
        void BuyTicket(int showId, int seat);
        public ShowDTO GetShow(int? id);
        public IEnumerable<ShowDTO> GetShows();
        void Dispose();
    }
}
