using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace PlaceMyBet.Models
{
    public class Evento
    {

        public Evento(int eventoId,string fecha, string equipo_local, string equipo_visitante, int goles_totales)
        {
            EventoId = eventoId;
            Fecha = fecha;
            Equipo_local = equipo_local;
            Equipo_visitante = equipo_visitante;
            Goles_totales = goles_totales;
        }

        public int EventoId { get; set; }
        public string Fecha { get; set; }
        public string Equipo_local { get; set; }
        public string Equipo_visitante { get; set; }
        public int Goles_totales { get; set; }

        public List<Mercado> Mercados { get; set; }

    }
    /*** Ejercicio 1 ***/
    public class EventoDTO
    {

        public EventoDTO(int eventoId,string fecha, string equipo_local, string equipo_visitante)
        {
            EventoId = eventoId;
            Fecha = fecha;
            Equipo_local = equipo_local;
            Equipo_visitante = equipo_visitante;
        }
        public int EventoId { get; set; }
        public string Fecha { get; set; }
        public string Equipo_local { get; set; }
        public string Equipo_visitante { get; set; }
    }
    /*** Fin Ejercicio 1 ***/
}