using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppCine.Models
{
    public class Genero
    {
        [DisplayName("Código")]
        public int genero_id { get; set; }
        [DisplayName("Nombre")]
        public String nombre { get; set; }
    }
}