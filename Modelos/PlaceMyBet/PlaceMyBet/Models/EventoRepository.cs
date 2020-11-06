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

        /*private MySqlConnection Connect()
        {
            string connString = "Server =127.0.0.1;Port=3306;Database=placemybet1;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }*/
        internal List<Evento> Retrieve() 
        {
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }
            return eventos;

                //  MySqlConnection con = Connect();
                //  MySqlCommand command = con.CreateCommand();
                // command.CommandText = "SELECT * FROM evento";

                // con.Open();
                //  MySqlDataReader res = command.ExecuteReader();

               // Evento e = null;
            //  if (res.Read())
            //  {
            //      Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3));
            //     e = new EventoDTO(res.GetString(1), res.GetString(2), res.GetString(3));
            // }
            // return e;
           // return null;
        }

        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(e);
            context.SaveChanges();

        }
    }
}