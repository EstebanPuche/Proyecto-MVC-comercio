using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcComercio.Models
{
    public class Disco
    {
        public int Id
        {
            get; set; 
        }

        [Required(ErrorMessage = "El título del disco es un campo obligatorio")]
        [Display(Name = "Título disco")]
        public string NombreDisco
        {
            get; set;
        }
        /**
         Poner descripción del disco aquí...
         */
        [Display(Name = "Fecha de publicación")]
        [DataType(DataType.Date)]
        public DateTime? FechaPublicacion
        {
            get; set;
        }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio
        {
            get; set;
        }

        public string ImagenPortada
        {
            get; set;
        }
        // Relación Uno
        [Display(Name = "Artista")]
        public int ArtistaId
        {
            get; set;
        }
        public Artista Artista
        {
            get; set;
        }

        // Relación Muchos
        public ICollection<Cancion> Canciones
        {
            get; set;
        }
        public ICollection<DetalleFactura> DetalleFacturas
        {
            get; set;
        }
    }
}
