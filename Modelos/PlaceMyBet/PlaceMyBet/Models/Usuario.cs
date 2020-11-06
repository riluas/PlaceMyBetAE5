using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        public Usuario(string email, string nombre, string apellidos, int edad)
        {
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
        }
        [System.ComponentModel.DataAnnotations.Key]
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public List<Apuesta> Apuestas { get; set; }

        public Cuenta Cuenta { get; set; }
    }
}