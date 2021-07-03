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
using Npgsql;
namespace GestionReservation.UC
{
    public partial class ucRoom : UserControl
    {
        public int Num { get; set; }
        public DateTime dt { get; set; }
        public void ShowStatus(DateTime dateRes) {
            dt = dateRes;
            foreach (Reservation res in ucHotel.DB.ListRes)
            {
                if(res.Num == this.Num && res.DateRes == dateRes.Date )
                {
                    this.BackColor = Color.Red;
                    return;
                }
            }
            this.BackColor = Color.Yellow;
        }
        public ucRoom()
        {
            InitializeComponent();
        }

        private void ucRoom_Load(object sender, EventArgs e)
        {
            lbNum.Text = Num.ToString();
        }

        private void libérerMenuItem_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User Id=postgres;Password=;host=localhost;database=hotel;");
            var sql = "Delete from reservation where num=@num and dt=@dt";
            var cmd = new NpgsqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("num", Num);
            cmd.Parameters.AddWithValue("dt", dt.Date);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            ucHotel.update();
            ShowStatus(dt);
        }

        private void réserverMenuItem_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User Id=postgres;Password=;host=localhost;database=hotel;");
            var sql = "INSERT INTO reservation(num, dt) VALUES(@num, @dt)";
            var cmd = new NpgsqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("num", Num);
            cmd.Parameters.AddWithValue("dt",dt);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            ucHotel.update();
            ShowStatus(dt);
        }
    }
}
