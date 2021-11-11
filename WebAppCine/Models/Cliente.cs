using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppCine.Models
{
    public class Cliente
    {
        [DisplayName("Código")]
        public int cliente_id { get; set; }
        [DisplayName("DNI")]
        public string dni { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Apellido paterno")]
        public string apellido_paterno { get; set; }
        [DisplayName("Apellido materno")]
        public string apellido_materno { get; set; }
        [DisplayName("Fecha nacimiento")]
        public DateTime fecha_nacimiento { get; set; }
        [DisplayName("Correo")]
        public string correo { get; set; }
        [DisplayName("Tarjeta")]
        public string tarjeta { get; set; }
        [DisplayName("CVV")]
        public string cvv { get; set; }

    }
}