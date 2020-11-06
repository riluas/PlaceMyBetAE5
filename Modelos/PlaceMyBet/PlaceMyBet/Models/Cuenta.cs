using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Cuenta
    {
        public Cuenta(int cuentaId, string nombre_banco, double num_tarjeta, double saldo, string usuarioID)
        {
            CuentaId = cuentaId;
            Nombre_banco = nombre_banco;
            Num_tarjeta = num_tarjeta;
            Saldo = saldo;
            UsuarioID = usuarioID;
        }

        public int CuentaId { get; set; }
        public string Nombre_banco { get; set; }
        public double Num_tarjeta { get; set; }
        public double Saldo { get; set; }


        public string UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}