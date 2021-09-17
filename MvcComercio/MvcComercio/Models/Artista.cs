using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcComercio.Models
{
    public class Artista
    {
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(20, ErrorMessage ="Este campo debe tener un mínimo de 3 caracteres y un máximo de 20", MinimumLength =3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage ="El nombre debe empezar por mayúscula y no tener números.")]
        public string Nombre
        {
            get; set;
        }

        [Required(ErrorMessage = "El apellido es un campo obligatorio.")]
        [StringLength(20, ErrorMessage = "Este campo debe tener un mínimo de 3 caracteres y un máximo de 20", MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "El apellido debe empezar por mayúscula y no tener números.")]
        public string Apellidos
        {
            get; set;
        }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaNacimiento
        {
            get; set;
        }

        [Required(ErrorMessage = "La nacionalidad es un campo obligatorio.")]
        [StringLength(30, ErrorMessage = "Este campo debe tener un mínimo de 3 caracteres y un máximo de 30.", MinimumLength =3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "El nombre debe empezar por mayúscula y no tener números.")]
        public string Nacionalidad
        {
            get; set;
        }

        // Relación Uno
        [Display(Name = "Género musical")]
        public int GeneroMusucalId
        {
            get;set;
        }
        public GeneroMusical GeneroMusical
        {
            get; set;
        }

        // Relación Muchos
        public ICollection<Disco> Discos
        {
            get; set;
        }
    }
}
