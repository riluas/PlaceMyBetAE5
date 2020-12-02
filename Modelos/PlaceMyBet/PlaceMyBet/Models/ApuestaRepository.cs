using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {
        /*private MySqlConnection Connect()
        {
            string connString = "Server =127.0.0.1;Port=3306;Database=placemybet1;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }*/
        internal List<ApuestaDTO> Retrieve()
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                List<ApuestaDTO> apuestas = context.Apuestas.Select(p => ToDTO(p)).ToList();
                return apuestas;
            }

        }

        internal static ApuestaDTO ToDTO(Apuesta a)
        {
            return new ApuestaDTO(a.Cuota, a.Tipo_apuesta, a.Dinero_apostado, a.UsuarioEmail, a.MercadoID);

        }

        /*internal List<MercadoDTO> Retrieve()
        {

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                // List<Mercado> mercados = context.Mercados.Include(p => p.Evento).ToList();
                List<MercadoDTO> mercados = context.Mercados.Select(p => ToDTO(p)).ToList();
                return mercados;
            }
        }

        internal static MercadoDTO ToDTO(Mercado m)
        {
            return new MercadoDTO(m.OverUnder, m.Apostado_over, m.Apostado_under);

        }*/

        internal Apuesta Retrieve2(int id)
        {
            Apuesta apuesta;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas
                    .Where(b => b.ApuestaId == id)
                    .FirstOrDefault();
            }
            return apuesta;
        }


        /*   internal ApuestaDTO Retrieve()
       {
          // MySqlConnection con = Connect();
          // MySqlCommand command = con.CreateCommand();
          // command.CommandText = "SELECT * FROM apuesta";
           //try { 
           //con.Open();
          // MySqlDataReader res = command.ExecuteReader();

           ApuestaDTO a = null;
           //if (res.Read())
          // {
           //    Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetDouble(2) + " " + res.GetString(3) + " " + res.GetDouble(4) + res.GetInt32(5) + " " + res.GetString(6));
          //     a = new ApuestaDTO(res.GetString(1), res.GetDouble(2), res.GetString(3), res.GetDouble(4), res.GetInt32(5), res.GetString(6));
          // }
          // con.Close();
           return a;
          // }
          // catch (MySqlException a)
         //  {

          //     Debug.WriteLine("Se ha producido un error de conexión");
               return null;

           //}
       }*/

        internal List<ApuestaUsu> GetApuestaUsu(string eUsu, double tipoM)
        {

           // MySqlConnection con = Connect();
           // MySqlCommand command = con.CreateCommand();
           // command.CommandText = "SELECT m.overunder, m.id_evento , a.tipo_apuesta, a.cuota, a.dinero_apostado, a.email_usuario FROM mercado m join apuesta a ON a.id_mercado = m.id WHERE overunder = @Mtipo && email_usuario = @Eusu";
           // command.Parameters.AddWithValue("@Eusu", eUsu);
           // command.Parameters.AddWithValue("@Mtipo", tipoM);

           // con.Open();
           // MySqlDataReader res = command.ExecuteReader();

            ApuestaUsu apuestaUsu = null;
            List<ApuestaUsu> uApu = new List<ApuestaUsu>();

            //while (res.Read())
            // {


            // apuestaUsu = new ApuestaUsu(res.GetInt32(1), res.GetString(2), res.GetDouble(3), res.GetDouble(4));
            // uApu.Add(apuestaUsu);
            //  }

            // return uApu;
            return null;

        }

        internal List<ApuestaMUsu> GetApuestaMUsu(double tipoEm, string emUsu)
        {

           // MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
           // command.CommandText = "SELECT m.overunder, a.tipo_apuesta, a.cuota, a.dinero_apostado, a.email_usuario FROM mercado m join apuesta a ON a.id_mercado = m.id WHERE overunder = @tipoEm && email_usuario = @emUsu";
           // command.Parameters.AddWithValue("@EmUsu", emUsu);
            //command.Parameters.AddWithValue("@TipoEm", tipoEm);

            //con.Open();
           // MySqlDataReader res = command.ExecuteReader();

            ApuestaMUsu apuestaMUsu = null;
            List<ApuestaMUsu> uMApu = new List<ApuestaMUsu>();

            // while (res.Read())
            // {


            //   apuestaMUsu = new ApuestaMUsu(res.GetDouble(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3));
            //   uMApu.Add(apuestaMUsu);
            //}

            //return uMApu;
            return null;

        }



        internal double Cuota(ApuestaDTO apuesta)
        {
            // MySqlConnection con = Connect();
            // MySqlCommand command = con.CreateCommand();
            // if (apuesta.Tipo_apuesta == "over")
            //  {
            //  command.CommandText = "SELECT cuota_over FROM mercado";
            //  }
            //  else if (apuesta.Tipo_apuesta == "under")
            // {
            //  command.CommandText = "SELECT cuota_under FROM mercado";
            // }

            // try
            // {
            //  con.Open();
            //  MySqlDataReader res = command.ExecuteReader();

            //  double cuota = 0;
            // if (res.Read())
            //  {
            //     cuota = res.GetDouble(0);
            //  }
            // con.Close();
            // return cuota;
            //}
            // catch (MySqlException a)
            //  {

            //     Debug.WriteLine("Se ha producido un error de conexión");
            //     return 0;

            // }
            return 0;
        }
        internal void Save(Apuesta apuesta)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Apuestas.Add(apuesta);
            context.SaveChanges();

        }


//internal void Save(ApuestaDTO apuesta, double tipo)
       // {
            //MySqlConnection con = Connect();
            // MySqlCommand command = con.CreateCommand();
            //command.CommandText = "INSERT INTO Apuesta(cuota, tipo_apuesta, dinero_apostado, id_mercado, email_usuario) VALUES('" + tipo.ToString(CultureInfo.CreateSpecificCulture("us-US")) + "','" + apuesta.Tipo_apuesta + "','" + apuesta.Dinero_apostado + "','" + apuesta.Id_mercado + "','" + apuesta.Email_usuario + "');";


            // Debug.WriteLine("comando " + command.CommandText);
            //try
            // {
            //     con.Open();
            //     command.ExecuteNonQuery();
            //     con.Close();
            // }
            // catch (MySqlException a)
            // {

            //  Debug.WriteLine("Se ha producido un error de conexión");

            //}
            
       // }
    }
}