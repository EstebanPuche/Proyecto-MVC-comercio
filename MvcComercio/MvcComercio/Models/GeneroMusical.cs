using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcComercio.Models
{
    public class GeneroMusical
    {
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage = "El género de música es un campo obligatorio.")]
        [StringLength(50,ErrorMessage ="El campo debe tener un mínimo de 2 caracteres y un máximo de 50", MinimumLength =2)]
        [Display(Name ="Género")]
        public string Genero
        {
            get; set;
        }

        
        public string ImagenGenero
        {
            get; set;
        }

        // Relación Muchos
        public ICollection<Artista> Artistas
        {
            get; set; 
        }
    }
}
