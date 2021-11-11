using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppCine.Models
{
    public class OrdenVenta
    {
        [DisplayName("Código")]
        public int orden_venta_id { get; set; }
        [DisplayName("Reserva")]
        public string codigo_reserva { get; set; }
        [DisplayName("Asiento")]
        public int asiento { get; set; }
        [DisplayName("Fila")]
        public string fila { get; set; }
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }
        [DisplayName("Monto")]
        public decimal monto { get; set; }
        [DisplayName("Cliente")]
        public Cliente ClienteOrdenVenta { get; set; }
        [DisplayName("Empleado")]
        public Empleado EmpleadoOrdenVenta { get; set; }
        [DisplayName("Función")]
        public Funcion FuncionOrdenVenta { get; set; }
    }
}