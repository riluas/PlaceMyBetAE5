using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int mercadoId, double overUnder, double cuota_over, double cuota_under, double apostado_over, double apostado_under, int id_evento)
        {
            MercadoId = mercadoId;
            OverUnder = overUnder;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Apostado_over = apostado_over;
            Apostado_under = apostado_under;
            Id_evento = id_evento;

        }

        public int MercadoId { get; set; }
        public double OverUnder { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        public double Apostado_over { get; set; }
        public double Apostado_under { get; set; }
        public int Id_evento { get; set; }

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
}