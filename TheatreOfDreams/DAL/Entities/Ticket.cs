using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Ticket
    {
        
        public int showid { get; set; }
        public int Price { get; set; }

        [Key]
        public int Seat { get; set; }
        public int Status { get; set; }
        public Ticket()
        {

        }
    }
}
