using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcComercio.Models
{
    public class DetalleFactura
    {
        public int Id
        {
            get; set;
        }

        //Relación Uno
        [Display(Name = "Disco")]
        public int DiscoId
        {
            get; set;
        }
        public Disco Disco
        {
            get; set;
        }

        //Relación Uno
        [Display(Name ="Factura")]
        public int FacturaId
        {
            get; set;
        }
        public Factura Factura
        {
            get; set;
        }
        //! El valor total lo puedo sacar en la View correspondiente llamando a 
        // "<h3>Cantidad Total : @Model.Sum(c => c.Precio) </h3>"
    }
}
