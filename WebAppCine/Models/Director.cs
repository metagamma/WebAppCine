using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppCine.Models
{
    public class Director
    {
        [DisplayName("Código")]
        public int director_id { get; set; }
        [DisplayName("Nombre")]
        public String nombre { get; set; }
        [DisplayName("Apellido")]
        public String apellido { get; set; }
    }
}