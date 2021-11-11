using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppCine.Models
{
    public class Formato
    {
        [DisplayName("Código")]
        public int formato_id { get; set; }
        [DisplayName("Nombre")]
        public String nombre { get; set; }
    }
}