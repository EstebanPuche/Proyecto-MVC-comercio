using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcComercio.Models
{
    public class Cancion
    {
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage ="El título de las canciones es un campo obligatorio.")]
        [Display(Name ="Título")]
        public string Titulo
        {
            get; set;
        }

        [Display(Name ="Duración")]
        [DataType(DataType.Time)]
        public DateTime? Duracion
        {
            get; set;
        }

        [Display(Name = "Disco")]
        public int DiscoId
        {
            get; set;
        }
        public Disco Disco
        {
            get; set;
        }
    }
}
