using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    static class Program
    {


        static void Main()
        {
            ShowContext db = new ShowContext("DefaultConnection");
            db.Dispose();
        }
    }
    
}
