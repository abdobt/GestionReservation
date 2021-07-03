using GestionReservation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionReservation.UC
{
    public partial class ucHotel : UserControl
    {
        public static ReservationList DB { get; set; }
        public ucHotel()
        {
            InitializeComponent();
            DB = new ReservationList();
            foreach (Control item in this.Controls)
            {
                if (item is ucRoom)
                {
                    ucRoom room = (ucRoom)item;
                    room.ShowStatus(dtPicker.Value);
                }

            }
        }

        private void dtPicker_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is ucRoom)
                {
                    ucRoom room = (ucRoom)item;
                    room.ShowStatus(dtPicker.Value);
                }

            }
        }
        public static void update()
        {
            DB = new ReservationList();
        }
    }
}
