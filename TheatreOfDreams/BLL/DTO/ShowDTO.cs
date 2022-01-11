using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ShowDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }
        public IEnumerable<Ticket> Tickets;
    }
}
