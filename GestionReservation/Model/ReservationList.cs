using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace GestionReservation.Model
{
    public class ReservationList
    {
        public List<Reservation> ListRes { get; set; }


        public ReservationList()
        {
            var cs = "Host=localhost;Username=postgres;Password=;Database=hotel";

            var con = new NpgsqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM reservation";
            var cmd = new NpgsqlCommand(sql, con);

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            ListRes = new List<Reservation>();
            while (rdr.Read())
            {
                Reservation res1 = new Reservation(rdr.GetInt32(1),(DateTime) rdr.GetDate(2));
                ListRes.Add(res1);
            }
        }


    }
}
