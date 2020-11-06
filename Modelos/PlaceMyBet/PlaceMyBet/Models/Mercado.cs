using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int mercadoId, double overUnder, double cuota_over, double cuota_under, double apostado_over, double apostado_under, int eventoID)
        {
            MercadoId = mercadoId;
            OverUnder = overUnder;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Apostado_over = apostado_over;
            Apostado_under = apostado_under;
            EventoID = eventoID;

        }

        public int MercadoId { get; set; }
        public double OverUnder { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        public double Apostado_over { get; set; }
        public double Apostado_under { get; set; }

        public int EventoID { get; set; }
        public Evento Evento { get; set; }

        public List<Apuesta> Apuestas { get; set; }
    }

    public class MercadoDTO
    {
        public MercadoDTO(double overUnder, double cuota_over, double cuota_under)
        {

            OverUnder = overUnder;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;

        }

        public double OverUnder { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
    }

    public class MercadoCuota
    {
        public MercadoCuota(int mercadoId, double apostado_over, double apostado_under)
        {
            MercadoId = mercadoId;
            Apostado_over = apostado_over;
            Apostado_under = apostado_under;

        }

        public int MercadoId { get; set; }
        public double Apostado_over { get; set; }
        public double Apostado_under { get; set; }
    }
}