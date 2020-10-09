using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Globalization;

namespace PlaceMyBet.Models
{
    public class MercadoRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server =127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal void calc(Mercado cUpdate, ApuestaDTO apuesta)
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            


                double pOver = cUpdate.Apostado_over/ (cUpdate.Apostado_over + cUpdate.Apostado_under);
                double pUnder = cUpdate.Apostado_under / (cUpdate.Apostado_over + cUpdate.Apostado_under);

            Debug.WriteLine("Update over: " + cUpdate.Apostado_over);
            Debug.WriteLine("Update under: " + cUpdate.Apostado_under);

            Debug.WriteLine("pro: " + pOver);
                Debug.WriteLine("under: " + pUnder);

            double cOver = 0.95;
            double cUnder = 0.95;

            if (pOver != 0)
            {
                cOver = 1 / pOver * 0.95;
            }

            if (pUnder != 0)
            {
                cUnder = (1 / pUnder) * 0.95;
            }

                double overDoble = Math.Round((double)Convert.ToDouble(cOver), 2);
                double underDoble = Math.Round((double)Convert.ToDouble(cUnder), 2);

            con.Open();

                command.CommandText = "UPDATE mercado SET cuota_over = " + overDoble.ToString(CultureInfo.CreateSpecificCulture("us-US")) + " , cuota_under = " + underDoble.ToString(CultureInfo.CreateSpecificCulture("us-US")) + "WHERE id = " + cUpdate.MercadoId + ";";

            

                Debug.WriteLine("cOver: " + cOver);
                Debug.WriteLine("cUnder: " + cUnder);
            command.ExecuteNonQuery();
        }

        internal void dineroUpdate(ApuestaDTO apuesta)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            con.Open();


            if (apuesta.Tipo_apuesta == "over")
            {
                command.CommandText = "UPDATE mercado SET apostado_over = apostado_over + " + apuesta.Dinero_apostado + " WHERE id = " + apuesta.Id_mercado + ";";
            }
            else if (apuesta.Tipo_apuesta == "under")
            {
                command.CommandText = "UPDATE mercado SET apostado_under = apostado_under + " + apuesta.Dinero_apostado + " WHERE id = " + apuesta.Id_mercado + ";";
            }
            command.ExecuteNonQuery();

        }

        internal Mercado cuotaUpdate()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM mercado";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Mercado cUpdate = null;
            if (res.Read())
            {

                Debug.WriteLine("Recuperado: " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3));
                cUpdate = new Mercado(res.GetInt32(0),res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
            }
            return cUpdate;

        }

        internal MercadoDTO Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM mercado";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            MercadoDTO m = null;
            if (res.Read())
            {

                Debug.WriteLine("Recuperado: " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3));
                m = new MercadoDTO(res.GetDouble(1), res.GetDouble(2), res.GetDouble(3));
            }
            return m;
        }
    }
}