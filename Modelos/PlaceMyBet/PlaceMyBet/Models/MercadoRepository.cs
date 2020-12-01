using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PlaceMyBet.Models
{
    public class MercadoRepository
    {
       /* private MySqlConnection Connect()
        {
            string connString = "Server =127.0.0.1;Port=3306;Database=placemybet1;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }*/

        internal void Save(Mercado mercado)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Mercados.Add(mercado);
            context.SaveChanges();

        }

            internal void dineroUpdate(Apuesta apuesta)
            {
            Mercado mercado;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
               {
                
                mercado = context.Mercados
                        .Where(m => m.MercadoId == apuesta.MercadoID)
                        .FirstOrDefault();

                if (apuesta.Tipo_apuesta == "over") 
                {
                    mercado.Apostado_over += apuesta.Dinero_apostado; 
                }
                else if(apuesta.Tipo_apuesta == "under")
                {
                    mercado.Apostado_under += apuesta.Dinero_apostado;
                }
                context.SaveChanges();
            }
        }
        internal void cuotaUpdate(Apuesta apuesta)
        {
            Mercado mercado;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(m => m.MercadoId == apuesta.MercadoID)
                    .FirstOrDefault();

                //Over
                double proOver = mercado.Apostado_over / (mercado.Apostado_over + mercado.Apostado_under);
                if (proOver != 0)
                {
                    double cOver = 1 / proOver * 0.95;
                    mercado.Cuota_over = Math.Round((double)Convert.ToDouble(cOver), 2);
                }

                //Under
                double proUnder = mercado.Apostado_under / (mercado.Apostado_under + mercado.Apostado_over);
                if (proUnder != 0)
                {
                    double cUnder = 1 / proUnder * 0.95;
                    mercado.Cuota_under = Math.Round((double)Convert.ToDouble(cUnder), 2);
                }
                context.SaveChanges();
            }

        }

        internal List<Mercado> Retrieve()
        {
            
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                List<Mercado> mercados = context.Mercados.Include(p => p.Evento).ToList();
                return mercados;
            }
            
            // MySqlConnection con = Connect();
            // MySqlCommand command = con.CreateCommand();
            //command.CommandText = "SELECT * FROM mercado";

            // con.Open();
            //MySqlDataReader res = command.ExecuteReader();


            //if (res.Read())
            //  {

            // Debug.WriteLine("Recuperado: " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3));
            //  m = new MercadoDTO(res.GetDouble(1), res.GetDouble(2), res.GetDouble(3));
            //  }
            // return m;
        }
        internal Mercado Retrieve2(int id)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(b => b.MercadoId == id)
                    .FirstOrDefault();
            }
            return mercado;
        }

            internal Mercado Mget(int id, double tipo)
    {
       // MySqlConnection con = Connect();

        //MySqlCommand command = con.CreateCommand();

        //command.CommandText = "SELECT * FROM mercado where id_evento = @Eid && overunder = @Mtipo";
            //command.Parameters.AddWithValue("@Eid", id);
           // command.Parameters.AddWithValue("@Mtipo", tipo);



   
            //con.Open();
           // MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
          // if (res.Read())
           // {
              //  Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
              //  m = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));

             //   }
            //return m;
            return null;


        }
    }
}