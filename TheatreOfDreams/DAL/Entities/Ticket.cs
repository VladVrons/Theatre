using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Ticket
    {
        [Key]
        public int showid { get; set; }
        public int Price { get; set; }
        public int Seat { get; set; }
        public int Status { get; set; }
    }
}
