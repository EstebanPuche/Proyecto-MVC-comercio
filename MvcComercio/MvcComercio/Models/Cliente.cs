using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcComercio.Models
{
    public class Cliente
    {
        public int Id
        {
            get; set;
        }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="El nombre del cliente es un campo obligatorio.")]
        [StringLength(20,ErrorMessage ="Este campo debe tener un mínimo de 3 caracteres y un máximo de 20", MinimumLength =3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "El nombre debe empezar por mayúscula y no tener números.")]
        public string NombreCliente
        {
            get; set;
        }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido del cliente es un campo obligatorio.")]
        [StringLength(20, ErrorMessage = "Este campo debe tener un mínimo de 3 caracteres y un máximo de 20", MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "El apellido debe empezar por mayúscula y no tener números.")]
        public string ApellidoCliente
        {
            get; set;
        }

        [Display(Name ="Dirección")]
        public string Direccion
        {
            get; set;
        }

        [Display(Name ="Correo electrónico")]
        [EmailAddress(ErrorMessage ="Dirección de correo no valida")]
        public string CorreoElectronico
        {
            get; set;
        }

        [Display(Name ="Teléfono")]
        [RegularExpression(@"(\+34|0034|34)?[ -]*(6|7|9)[ -]*([0-9][ -]*){8}", ErrorMessage ="El número de teléfono debe ser nacional")]
        public string Telefono
        {
            get; set;
        }

        [Required(ErrorMessage ="La nacionalidad es un campo obligatorio.")]
        [Display(Name ="País")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "El país debe empezar por mayúscula y no tener números.")]
        public string Pais
        {
            get; set;
        }

        [Required(ErrorMessage ="La ciudad es un campo obligatorio.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "La ciudad debe empezar por mayúscula.")]
        public string Ciudad
        {
            get; set;
        }

        public ICollection<Factura> Facturas
        {
            get; set;
        }
    }
}
