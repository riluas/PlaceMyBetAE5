using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

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
        internal List<EventoDTO> Retrieve() 
        {

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                List<EventoDTO> eventos = context.Eventos.Select(p => ToDTO(p)).ToList();
                return eventos;
            }
        }

        /*internal List<EventoDTO> Retrieve2()
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                List<EventoDTO> eventos = context.Eventos.Select(p => ToDTO(p)).ToList();
                return eventos;
            }
        }*/

        internal static EventoDTO ToDTO(Evento e)
        {
            return new EventoDTO(e.Fecha, e.Equipo_local, e.Equipo_visitante);
            
        }

        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(e);
            context.SaveChanges();

        }

        internal void Edit(int id, Evento evento)
        {
 
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                var updateEvento = context.Eventos
                    .Where(b => b.EventoId == id)
                    .FirstOrDefault();

                if (evento.Equipo_local != null)
                {
                    updateEvento.Equipo_local = evento.Equipo_local;
                }

                if (evento.Equipo_visitante != null)
                {
                    updateEvento.Equipo_visitante = evento.Equipo_visitante;
                }

                Debug.WriteLine("evento valor " + id);
                Debug.WriteLine("evento valor " + updateEvento.EventoId);
                Debug.WriteLine("evento valor " + updateEvento.Equipo_local);
                Debug.WriteLine("evento valor " + updateEvento.Equipo_visitante);
                Debug.WriteLine("evento valor " + evento.Equipo_local);
                Debug.WriteLine("evento valor " + evento.Equipo_visitante);
                context.SaveChanges();
            }


        }

        internal void eRemove(int id)
        {

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                var removeEvento = context.Eventos
                    .Where(b => b.EventoId == id)
                    .FirstOrDefault();

                context.Eventos.Remove(removeEvento);
                context.SaveChanges();
            }
        }
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
    }
}