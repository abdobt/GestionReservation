using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservation.Model
{
    public class Reservation
    {
        public int Num { get; set; }
        public DateTime DateRes { get; set; }

        public Reservation()
        {

        }

        public Reservation(int num, DateTime dt)
        {
            this.Num = num;
            this.DateRes = dt;
        }

    }
}
