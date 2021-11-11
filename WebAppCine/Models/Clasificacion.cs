using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;

namespace WebAppCine.Models
{
    public class Clasificacion
    {
        [DisplayName("Código")]
        public int clasificacion_id { get; set; }
        [DisplayName("Nombre")]
        public String nombre { get; set; }
    }
}