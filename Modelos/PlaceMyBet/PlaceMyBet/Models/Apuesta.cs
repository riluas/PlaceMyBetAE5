using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int apuestaId, string fecha, double cuota, string tipo_apuesta, double dinero_apostado, int mercadoID, string usuarioEmail)
        {
            ApuestaId = apuestaId;
            Fecha = fecha;
            Cuota = cuota;
            Tipo_apuesta = tipo_apuesta;
            Dinero_apostado = dinero_apostado;
            MercadoID = mercadoID;
            UsuarioEmail = usuarioEmail;
        }

        public int ApuestaId { get; set; }
        public string Fecha { get; set; }
        public double Cuota { get; set; }
        public string Tipo_apuesta { get; set; }
        public double Dinero_apostado { get; set; }

        public int MercadoID { get; set; }
        public Mercado Mercado { get; set; }

        public string UsuarioEmail { get; set; }
        public Usuario Usuario { get; set; }

    }

    public class ApuestaDTO
    {
        public ApuestaDTO(string fecha, double cuota, string tipo_apuesta, double dinero_apostado, int id_mercado, string usuarioEmail)
        {
            Fecha = fecha;
            Cuota = cuota;
            Tipo_apuesta = tipo_apuesta;
            Dinero_apostado = dinero_apostado;
            Id_mercado = id_mercado;
            Email_usuario = usuarioEmail;
        }

        public string Fecha { get; set; }
        public double Cuota { get; set; }
        public string Tipo_apuesta { get; set; }
        public double Dinero_apostado { get; set; }
        public int Id_mercado { get; set; }
        public string Email_usuario { get; set; }
    }

    public class ApuestaUsu
    {
        public ApuestaUsu(int evento, string tipo_apuesta, double cuota, double dinero_apostado)
        {
            Evento = evento;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
        }


        public int Evento { get; set; }
        public string Tipo_apuesta { get; set; }
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }

    }

    public class ApuestaMUsu
    {
        public ApuestaMUsu(double overunder, string tipo_apuesta, double cuota, double dinero_apostado)
        {
            Tipo_mercado= overunder;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
        }


        public double Tipo_mercado { get; set; }
        public string Tipo_apuesta { get; set; }
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }

    }

}
