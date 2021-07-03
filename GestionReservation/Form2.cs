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

namespace GestionReservation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(date.Text);
            Console.WriteLine(Num.Text);
            NpgsqlConnection conn = new NpgsqlConnection("User Id=postgres;Password=;host=localhost;database=hotel;");
            var sql = "INSERT INTO reservation(num, dt) VALUES(@num, @dt)";
            var cmd = new NpgsqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("num", Int32.Parse(Num.Text));
            cmd.Parameters.AddWithValue("dt", DateTime.Parse(date.Text));
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            Console.WriteLine("row inserted");
        }

    }
}
