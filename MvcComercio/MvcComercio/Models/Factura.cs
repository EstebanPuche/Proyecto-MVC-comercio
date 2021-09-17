using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcComercio.Models
{
    public class Factura
    {
        public int Id
        {
            get; set;
        }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de compra")]
        public DateTime FechaCompra
        {
            get; set;
        }

        // Relación Muchos
        public ICollection<DetalleFactura> DetalleFacturas
        {
            get; set;
        }

        // Relación Uno 
        [Display(Name ="Cliente")]
        public int ClienteId
        {
            get; set;
        }
        public Cliente Cliente
        {
            get; set;
        }
    }
}
