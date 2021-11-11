using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppCine.Models
{
    public class Funcion
    {
        [DisplayName("Código")]
        public int funcion_id { get; set; }
        [DisplayName("Película")]
        public Pelicula PeliculaFuncion { get; set; }
        [DisplayName("Fecha")]
        public DateTime fecha_funcion { get; set; }
        [DisplayName("H.Inicio")]
        public DateTime hora_inicio { get; set; }
        [DisplayName("H.Fin")]
        public DateTime hora_fin { get; set; }
        [DisplayName("Sala")]
        public int numero_sala { get; set; }
        [DisplayName("Sede")]
        public Sede SedeFuncion { get; set; }
    }
}