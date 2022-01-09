using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Show
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }
        public List<Ticket> Tickets;
        public Show()
        {
            
        }
    }
}
