using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppCine.Models
{
    public class Sede
    {
        [DisplayName("Código")]
        public int sede_id { get; set; }
        [DisplayName("Nombre")]
        public String nombre { get; set; }
        [DisplayName("Teléfono")]
        public String telefono { get; set; }
        [DisplayName("Capacidad")]
        public int capacidad { get; set; }
    }
}