using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebAppCine.Models
{
    public class Pelicula
    {
        [DisplayName("Código")]
        public int pelicula_id { get; set; }
        [DisplayName("Nombre")]
        public String nombre { get; set; }
        [DisplayName("Imagen")]
        public String imagen { get; set; }
        [DisplayName("Sinopsis")]
        public String sinopsis { get; set; }
        [DisplayName("Duración")]
        public int duracion { get; set; }
        [DisplayName("Director")]
        public Director DirectorPelicula { get; set; }
        [DisplayName("Género")]
        public Genero GeneroPelicula { get; set; }
        [DisplayName("Formato")]
        public Formato FormatoPelicula { get; set; }
        [DisplayName("Clasificación")]
        public Clasificacion ClasificacionPelicula { get; set; }
        [DisplayName("Sede")]
        public Sede SedePelicula { get; set; }
    }
}