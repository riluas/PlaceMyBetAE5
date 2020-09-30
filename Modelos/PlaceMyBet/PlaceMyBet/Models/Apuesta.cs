using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int apuestaId, string fecha, double cuota, string tipo_apuesta, double dinero_apostado, int id_mercado, string email_usuario)
        {
            ApuestaId = apuestaId;
            Fecha = fecha;
            Cuota = cuota;
            Tipo_apuesta = tipo_apuesta;
            Dinero_apostado = dinero_apostado;
            Id_mercado = id_mercado;
            Email_usuario = email_usuario;
        }

        public int ApuestaId { get; set; }
        public string Fecha { get; set; }
        public double Cuota { get; set; }
        public string Tipo_apuesta { get; set; }
        public double Dinero_apostado { get; set; }
        public int Id_mercado { get; set; }
        public string Email_usuario { get; set; }
    }
}