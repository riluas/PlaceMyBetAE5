using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Globalization;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server =127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal ApuestaDTO Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM apuesta";
            try { 
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            ApuestaDTO a = null;
            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetDouble(2) + " " + res.GetString(3) + " " + res.GetDouble(4) + res.GetInt32(5) + " " + res.GetString(6));
                a = new ApuestaDTO(res.GetString(1), res.GetDouble(2), res.GetString(3), res.GetDouble(4), res.GetInt32(5), res.GetString(6));
            }
            con.Close();
            return a;
            }
            catch (MySqlException a)
            {

                Debug.WriteLine("Se ha producido un error de conexión");
                return null;

            }
        }

        internal double Cuota(ApuestaDTO apuesta)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            if (apuesta.Tipo_apuesta == "over")
            {
                command.CommandText = "SELECT cuota_over FROM mercado";
            }
            else if (apuesta.Tipo_apuesta == "under")
            {
                command.CommandText = "SELECT cuota_under FROM mercado";
            }
            
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                double cuota = 0;
                if (res.Read())
                {
                    cuota = res.GetDouble(0);
                }
                con.Close();
                return cuota;
            }
            catch (MySqlException a)
            {

                Debug.WriteLine("Se ha producido un error de conexión");
                return 0;

            }

        }


        internal void Save(ApuestaDTO apuesta, double tipo)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "INSERT INTO Apuesta(cuota, tipo_apuesta, dinero_apostado, id_mercado, email_usuario) VALUES('" + tipo.ToString(CultureInfo.CreateSpecificCulture("us-US")) + "','" + apuesta.Tipo_apuesta + "','" + apuesta.Dinero_apostado + "','" + apuesta.Id_mercado + "','" + apuesta.Email_usuario + "');";
            
                
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException a)
            {

                Debug.WriteLine("Se ha producido un error de conexión");

            }
        }
    }
}