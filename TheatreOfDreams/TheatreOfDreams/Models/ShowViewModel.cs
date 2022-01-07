using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class ShowViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }
    }
}
