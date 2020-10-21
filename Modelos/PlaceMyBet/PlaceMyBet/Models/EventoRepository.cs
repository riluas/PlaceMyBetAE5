using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventoRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server =127.0.0.1;Port=3306;Database=placemybet1;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal EventoDTO Retrieve() 
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM evento";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            EventoDTO e = null;
            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3));
                e = new EventoDTO(res.GetString(1), res.GetString(2), res.GetString(3));
            }
            return e;
        }

    }

}