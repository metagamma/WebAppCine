using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppCine.Models
{
    public class Empleado
    {
        [DisplayName("Código")]
        public int empleado_id { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Apellido paterno")]
        public string apellido_paterno { get; set; }
        [DisplayName("Apellido materno")]
        public string apellido_materno { get; set; }
        [DisplayName("Usuario")]
        public string usuario { get; set; }
        [DisplayName("Clave")]
        public string clave { get; set; }
        [DisplayName("Sede")]
        public Sede SedeEmpleado { get; set; }
    }
}